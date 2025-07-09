using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.DataTransferObject.BasketDTO;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EFBasketDAL : GenericRepository<Basket>, IBasketDAL
    {
        public EFBasketDAL(ApplicationContext context) : base(context)
        {
        }

        public List<ResultBasketDto> GetBasketByTableId(int id)
        {
            using var context = new ApplicationContext();

            var values = context.Baskets
                .AsNoTracking()
                .Where(x => x.RestaurantTableId == id)
                .Include(src => src.Food)
                .Include(src => src.RestaurantTable)
                .Select(z => new ResultBasketDto
                {
                    BasketId = z.BasketId,
                    Price = z.Price,
                    Count = z.Count,
                    TotalPrice = z.TotalPrice,
                    FoodId = z.FoodId,
                    FoodName = z.Food.FoodName,
                    RestaurantTableId = z.RestaurantTableId,
                    TableNumber = z.RestaurantTable.TableNumber
                })
                .ToList();

            return values;
        }

    }
}
