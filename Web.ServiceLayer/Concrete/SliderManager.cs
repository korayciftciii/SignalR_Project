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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDAL _sliderDAL;

        public SliderManager(ISliderDAL sliderDAL)
        {
            _sliderDAL = sliderDAL;
        }

        public void TDelete(Slider entity)
        {
           _sliderDAL.Delete(entity);
        }

        public int TGetActiveSliderCount()
        {
            return _sliderDAL.GetActiveSliderCount();
        }

        public List<Slider> TGetAll()
        {
            var data = _sliderDAL.GetAll();
         
            return data;
        }

        public Slider TGetById(int id)
        {
           var datum = _sliderDAL.GetById(id);
          
            return datum;   
        }

        public int TGetInActiveSliderCount()
        {
            return _sliderDAL.GetInactiveSliderCount();
        }

        public int TGetSliderCount()
        {
            return _sliderDAL.GetSliderCount();
        }

        public void TInsert(Slider entity)
        {
           _sliderDAL.Insert(entity);
        }

        public void TUpdate(Slider entity)
        {
           _sliderDAL.Update(entity);
        }
    }
}
