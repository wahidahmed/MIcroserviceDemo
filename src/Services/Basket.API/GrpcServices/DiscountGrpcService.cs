using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            this.discountProtoService = discountProtoService;
        }

        public async Task<CouponRequest>GetDiscount(string productId)
        {
            var getDiscountRequest = new GetDiscountRequest() { ProductId = productId };
           return await discountProtoService.GetDiscountAsync(getDiscountRequest);
        }
    }
}
