
using Ecommerce.Business.Helpers.DTOs.Payment;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.IUO;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace Ecommerce.Business.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly string _stripeSecretKey;
        private readonly IPaymentRepo _command;
        private readonly IUnitOfWorks _work;
        private readonly IQueryRepo<Payment> _query;

        public PaymentService(
            IConfiguration config,
            IQueryRepo<Payment> query,
            IPaymentRepo command,
            IUnitOfWorks work)
        {
            _stripeSecretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _stripeSecretKey;
            _query = query;
            _command = command;
            _work = work;
        }

        public async Task<PaymentResultDto> ProcessPaymentAsync(CreatePaymentDto paymentDto)
        {
            // Stripe ile paymentIntent oluşturma
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(paymentDto.TotalPrice * 100),
                Currency = "usd",
                PaymentMethod = paymentDto.PaymentToken,
                Confirm = true,
                ReturnUrl = "https://yourdomain.com/payment-result",
                PaymentMethodOptions = new PaymentIntentPaymentMethodOptionsOptions
                {
                    Card = new PaymentIntentPaymentMethodOptionsCardOptions
                    {
                        RequestThreeDSecure = "any"
                    }
                }
            };
            var intent = await new PaymentIntentService().CreateAsync(options);

            // Entity oluşturma
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                StripePaymentIntentId = intent.Id,
                Status = intent.Status,
                Amount = (decimal)paymentDto.TotalPrice,
                Currency = intent.Currency.ToUpper(),
                CardHolderName = paymentDto.CardHolderName,
                Is3DSecure = intent.Status is "requires_action" or "requires_source_action",
                PaymentMethod = intent.PaymentMethod.ToString(),
                CreatedAt = DateTime.UtcNow,
                UserId = Guid.Empty.ToString(),
                CartId = paymentDto.CardId
            };

            // Son 4 haneyi çekme (opsiyonel)
            try
            {
                var pm = await new PaymentMethodService().GetAsync(intent.PaymentMethod.ToString()!);
                payment.LastFourDigits = pm.Card?.Last4;
            }
            catch { }

            // SAVE
            await _command.CreateAsync(payment);
            await _work.SaveChangesAsync();

            // DTO hazırlama
            var result = new PaymentResultDto
            {
                PaymentIntentId = intent.Id,
                Status = intent.Status
            };

            if (intent.Status == "succeeded")
            {
                payment.Status = "succeeded";
                payment.CompletedAt = DateTime.UtcNow;
                await _work.SaveChangesAsync();
                result.IsSuccess = true;
            }
            else if (intent.Status is "requires_action" or "requires_source_action")
            {
                result.RequiresAction = true;
                result.ClientSecret = intent.ClientSecret;
                result.NextActionUrl = intent.NextAction?.RedirectToUrl?.Url;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Ödeme durumu: {intent.Status}";
                throw new Exception($"Ödeme işlemi başarısız: {intent.Status}");
            }

            return result;
        }

        public async Task<PaymentResultDto> ConfirmPaymentAsync(string paymentIntentId)
        {
            var intent = await new PaymentIntentService().GetAsync(paymentIntentId);

            // Repository’den çek
            var payment = await _query.GetAsync(p => p.StripePaymentIntentId == paymentIntentId)
                          ?? throw new Exception("Ödeme kaydı bulunamadı");

            payment.Status = intent.Status;

            var result = new PaymentResultDto
            {
                PaymentIntentId = intent.Id,
                Status = intent.Status
            };

            if (intent.Status == "succeeded")
            {
                payment.CompletedAt = DateTime.UtcNow;
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Ödeme doğrulaması başarısız: {intent.Status}";
            }

            await _work.SaveChangesAsync();
            return result;
        }
    }

}
