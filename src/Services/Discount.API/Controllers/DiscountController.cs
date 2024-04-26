using CoreApiResponse;
using Discount.API.Models;
using Discount.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        private readonly ICouponRepository couponRepository;

        public DiscountController(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Coupon),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productId)
        {
            try
            {
                var coupon=await couponRepository.GetDiscount(productId);
                return CustomResult(coupon);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult>CreateDiscount(Coupon coupon)
        {
            try
            {
                var isSaved = await couponRepository.CreateCoupon(coupon);
                if (isSaved)
                {
                    return CustomResult("Coupon saved successfully",coupon);
                }
                else
                {
                    return CustomResult("coupon saved failed",HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(Coupon coupon)
        {
            try
            {
                var isSaved = await couponRepository.UpdateCoupon(coupon);
                if (isSaved)
                {
                    return CustomResult("Coupon saved successfully", coupon);
                }
                else
                {
                    return CustomResult("coupon update failed", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(string productId)
        {
            try
            {
                var isDeleted = await couponRepository.DeleteCoupon(productId);
                if (isDeleted)
                {
                    return CustomResult("Coupon deleted successfully");
                }
                else
                {
                    return CustomResult("coupon deleted failed", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
