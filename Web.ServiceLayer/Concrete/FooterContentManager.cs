using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccessLayer.Abstract;
using Web.EntityLayer.Entities;
using Web.ServiceLayer.Abstract;

namespace Web.ServiceLayer.Concrete
{
    public class FooterContentManager : IFooterContentService
    {
        private readonly IFooterContentDAL _footerContentDAL;

        public FooterContentManager(IFooterContentDAL footerContentDAL)
        {
            _footerContentDAL = footerContentDAL;
        }

        public void TDelete(FooterContent entity)
        {
            _footerContentDAL.Delete(entity);
        }

        public List<FooterContent> TGetAll()
        {
            var data = _footerContentDAL.GetAll();
      
            return data;
        }

        public FooterContent TGetById(int id)
        {
           var datum=_footerContentDAL.GetById(id);
       
            return datum;
        }

        public void TInsert(FooterContent entity)
        {
            _footerContentDAL.Insert(entity);
        }

        public void TUpdate(FooterContent entity)
        {
          _footerContentDAL.Update(entity);
        }
    }
}
