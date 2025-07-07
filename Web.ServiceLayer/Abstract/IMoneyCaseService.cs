using Web.EntityLayer.Entities;

namespace Web.ServiceLayer.Abstract
{
  public  interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TGetTotalCaseAmount();
    }
}
