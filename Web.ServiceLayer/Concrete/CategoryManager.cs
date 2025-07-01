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
   public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void TDelete(Category entity)
        {
            _categoryDAL.Delete(entity);
                }

        public List<Category> TGetAll()
        {
            var data = _categoryDAL.GetAll();
           
            return data;
        }

        public Category TGetById(int id)
        {
            var datum=_categoryDAL.GetById(id);
       
            return datum;
        }

        public void TInsert(Category entity)
        {
            _categoryDAL.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDAL.Update(entity);
        }
    }
}
