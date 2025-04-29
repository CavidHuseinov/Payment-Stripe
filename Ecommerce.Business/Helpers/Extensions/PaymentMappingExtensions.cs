
using Ecommerce.Business.Helpers.DTOs.Payment;
using Ecommerce.Core.Entities;

namespace Ecommerce.Business.Helpers.Extensions
{
    public static class PaymentMappingExtensions
    {
        // Payment entity -> PaymentDetailDto
        public static PaymentDetailDto ToDetailDto(this Payment payment)
        {
            return new PaymentDetailDto
            {
                Id = payment.Id,
                Status = payment.Status,
                Amount = payment.Amount,
                Currency = payment.Currency,
                CardHolderName = payment.CardHolderName,
                LastFourDigits = payment.LastFourDigits,
                PaymentMethod = payment.PaymentMethod,
                Is3DSecure = payment.Is3DSecure,
                CreatedAt = payment.CreatedAt,
                CompletedAt = payment.CompletedAt,
                StripePaymentIntentId = payment.StripePaymentIntentId
            };
        }

        // Payment entity -> PaymentListItemDto
        public static PaymentListItemDto ToListItemDto(this Payment payment)
        {
            return new PaymentListItemDto
            {
                Id = payment.Id,
                Status = payment.Status,
                Amount = payment.Amount,
                Currency = payment.Currency,
                CreatedAt = payment.CreatedAt,
                CardHolderName = payment.CardHolderName,
                LastFourDigits = payment.LastFourDigits
            };
        }

        // IEnumerable<Payment> -> IEnumerable<PaymentListItemDto>
        public static IEnumerable<PaymentListItemDto> ToListItemDtos(this IEnumerable<Payment> payments)
        {
            return payments.Select(p => p.ToListItemDto());
        }

        // PaymentResult -> PaymentResponseDto
        public static PaymentResponseDto ToResponseDto(this PaymentResultDto result)
        {
            return new PaymentResponseDto
            {
                Success = result.IsSuccess,
                PaymentId = result.PaymentIntentId,
                Requires3DSecure = result.RequiresAction,
                RedirectUrl = result.NextActionUrl,
                ClientSecret = result.ClientSecret,
                ErrorMessage = result.ErrorMessage
            };
        }

        // Payment filtreleme
        public static IQueryable<Payment> ApplyFilter(this IQueryable<Payment> query, PaymentFilterDto filter)
        {
            if (filter == null)
                return query;

            if (filter.StartDate.HasValue)
                query = query.Where(p => p.CreatedAt >= filter.StartDate.Value);

            if (filter.EndDate.HasValue)
                query = query.Where(p => p.CreatedAt <= filter.EndDate.Value);

            if (!string.IsNullOrEmpty(filter.Status))
                query = query.Where(p => p.Status == filter.Status);

            if (filter.MinAmount.HasValue)
                query = query.Where(p => p.Amount >= filter.MinAmount.Value);

            if (filter.MaxAmount.HasValue)
                query = query.Where(p => p.Amount <= filter.MaxAmount.Value);

            if (!string.IsNullOrEmpty(filter.PaymentMethod))
                query = query.Where(p => p.PaymentMethod == filter.PaymentMethod);

            if (filter.Is3DSecure.HasValue)
                query = query.Where(p => p.Is3DSecure == filter.Is3DSecure.Value);

            return query;
        }
    }
}
