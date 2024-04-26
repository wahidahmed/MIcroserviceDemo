using Dapper;
using Discount.API.Models;
using Npgsql;

namespace Discount.API.Repository
{
    public class CouponRepository : ICouponRepository
    {
        IConfiguration _configuration;
        public CouponRepository(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected = await connection.ExecuteAsync("insert into Coupon(ProductId,ProductName,Description,Amount) Values(@ProductId,@ProductName,@Description,@Amount)", new { ProductId=coupon.ProductId,ProdcutName=coupon.ProductName,Description=coupon.Description,Amount=coupon.Amount});
            if (affected > 0)
            {
                return true;
            }
           return false;
        }

        public async Task<bool> DeleteCoupon(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected = await connection.ExecuteAsync("delete from Coupon where ProductId=@Productid", new { Productid = productId });
            if (affected > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Coupon> GetDiscount(string productId)
        {
            //var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            //string sql = string.Format("select * from \"Coupon\" where \"ProductId\"='{0}'",productId);
            //var coupon =await connection.QueryFirstAsync<Coupon>
            //            (sql);
            //if (coupon == null)
            //{
            //    return new Coupon() { Amount = 0, ProductName = "No Discount" };
            //}
            //return coupon;

            var dd = _configuration.GetConnectionString("DiscountDB");
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductId=@ProductId", new { ProductId = productId });
            if (coupon == null)
            {
                return new Coupon() { Amount = 0, ProductName = "No Discount" };
            }
            return coupon;

        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected = await connection.ExecuteAsync("update Coupon set ProductId=@ProductId,ProductName=@ProductName,Description=@Description,Amount=@Amount", new { ProductId = coupon.ProductId, ProdcutName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
            if (affected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
