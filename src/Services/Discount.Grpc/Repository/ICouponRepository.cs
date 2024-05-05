using Discount.Grpc.Models;

namespace Discount.Grpc.Repository
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(string productId);
        Task<bool>CreateCoupon(Coupon coupon);
        Task<bool>UpdateCoupon(Coupon coupon);
        Task<bool>DeleteCoupon(string productId);
    }
}
