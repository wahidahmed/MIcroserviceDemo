using AutoMapper;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Discount.Grpc.Repository;
using Grpc.Core;
using System.Runtime.CompilerServices;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ICouponRepository couponRepository;
        private readonly ILogger<DiscountService> logger;
        private readonly IMapper mapper;

        public DiscountService(ICouponRepository couponRepository,ILogger<DiscountService> logger,IMapper mapper)
        {
            this.couponRepository = couponRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public override async Task<CouponRequest> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var data = await couponRepository.GetDiscount(request.ProductId);
            if(data == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,"Discount not found"));
            }
            logger.LogInformation("Discount is retrieved for product name:{productName},Amount:{amount}", data.ProductName, data.Amount);

          var result=  mapper.Map<CouponRequest>(data);
            return result;
            //return base.GetDiscount(request, context);
        }

        public override async Task<CouponRequest> CreateDiscount(CouponRequest request, ServerCallContext context)
        {
            var coupon=mapper.Map<Coupon>(request);
          var isSaved= await couponRepository.CreateCoupon(coupon);
           return mapper.Map<CouponRequest>(coupon);
        }
    }
}
