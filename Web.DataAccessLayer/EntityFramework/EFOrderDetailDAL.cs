using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.Repositories;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.EntityFramework
{
    public class EFOrderDetailDAL : GenericRepository<OrderDetail>, IOrderDetailDAL
    {
        public EFOrderDetailDAL(ApplicationContext context) : base(context)
        {
        }
    }
}
