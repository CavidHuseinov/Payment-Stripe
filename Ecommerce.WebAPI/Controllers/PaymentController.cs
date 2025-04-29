using Ecommerce.Business.Helpers.DTOs.Payment;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class PaymentController:ApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<ActionResult<PaymentResultDto>> ProcessPayment([FromBody] CreatePaymentDto paymentDto)
        {
            var result = await _paymentService.ProcessPaymentAsync(paymentDto);

            if (result.IsSuccess)
            {
                return Ok(new
                {
                    success = true,
                    paymentId = result.PaymentIntentId
                });
            }
            else if (result.RequiresAction)
            {
                return Ok(new
                {
                    requiresAction = true,
                    clientSecret = result.ClientSecret,
                    redirectUrl = result.NextActionUrl
                });
            }
            else
            {
                // Global exception handler bunu yakalayacak
                return result;
            }
        }

        [HttpGet("confirm/{paymentIntentId}")]
        public async Task<IActionResult> ConfirmPayment(string paymentIntentId)
        {
            // 3D Secure doğrulaması sonrası dönüşte bu endpoint'e gelir
            var result = await _paymentService.ConfirmPaymentAsync(paymentIntentId);

            if (result.IsSuccess)
            {
                return Ok(new { success = true, paymentId = result.PaymentIntentId });
            }

            return BadRequest(new { success = false, status = result.Status });
        }
    }
}
