using Microsoft.AspNetCore.Mvc;
using Veda.ExceptionBase;

namespace Veda.Controllers
{
    public class BaseController : Controller
    {
        protected int GetTypeId()
        {
            try
            {
                string user = Request.Headers["TypeId"];
                int typeId = int.Parse(user);
                return typeId;
            }
            catch
            {
                throw new ValidationException("กรุณาใส่ Headers TypeId");
            }
        }
    }
}
