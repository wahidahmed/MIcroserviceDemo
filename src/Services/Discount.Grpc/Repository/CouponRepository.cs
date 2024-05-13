using Dapper;
using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Discount.Grpc.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _appDbContext;
        public CouponRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateCoupon(Coupon coupon)
        {
           
            _appDbContext.Coupon.Add(coupon);
            int result = await _appDbContext.SaveChangesAsync();

            // Check if any changes were saved
            if (result > 0)
            {
                return true; // Changes were saved successfully
            }
            else
            {
                return false; // No changes were saved
            }
        }

        public Task<bool> DeleteCoupon(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> GetDiscount(string productId)
        {
            var coupon = await _appDbContext.Coupon.FirstOrDefaultAsync(x => x.ProductId == productId);
            if(coupon == null) {
                return new Coupon() { Description = "No Discount",Amount=0,ProductId="No discount",ProductName=string.Empty };
            }
            else
            {
                return coupon;
            }
         
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            var data=await _appDbContext.Coupon.FirstOrDefaultAsync(x=>x.ProductId==coupon.ProductId);
            if (data!=null)
            {
                data.ProductName = coupon.ProductName;
                data.ProductId = coupon.ProductId;
                data.Amount = coupon.Amount;
                data.Description = coupon.Description;  
                _appDbContext.Coupon.Update(data);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public async Task<bool> DeleteCoupon(string productId)
        //{
        //    var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
        //    var affected = await connection.ExecuteAsync("delete from Coupon where ProductId=@Productid", new { Productid = productId });
        //    if (affected > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task<Coupon> GetDiscount(string productId)
        //{
        //    //var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
        //    //string sql = string.Format("select * from \"Coupon\" where \"ProductId\"='{0}'",productId);
        //    //var coupon =await connection.QueryFirstAsync<Coupon>
        //    //            (sql);
        //    //if (coupon == null)
        //    //{
        //    //    return new Coupon() { Amount = 0, ProductName = "No Discount" };
        //    //}
        //    //return coupon;

        //    var dd = _configuration.GetConnectionString("DiscountDB");
        //    var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
        //    var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
        //        ("SELECT * FROM Coupon WHERE ProductId=@ProductId", new { ProductId = productId });
        //    if (coupon == null)
        //    {
        //        return new Coupon() { Amount = 0, ProductName = "No Discount" };
        //    }
        //    return coupon;

        //}

        //public async Task<bool> UpdateCoupon(Coupon coupon)
        //{
        //    var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
        //    var affected = await connection.ExecuteAsync("update Coupon set ProductId=@ProductId,ProductName=@ProductName,Description=@Description,Amount=@Amount", new { ProductId = coupon.ProductId, ProdcutName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
        //    if (affected > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
