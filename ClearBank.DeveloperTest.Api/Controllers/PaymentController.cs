using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClearBank.DeveloperTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(PaymentRequest), StatusCodes.Status200OK)]
        public IActionResult Post(PaymentRequest paymentRequest)
        {
            try
            {
                var paymentResult = _paymentService.MakePayment(paymentRequest);
                return Ok(paymentResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured when trying to make payment", ex);
                throw;
            }
        }
    }
}