

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Erm.Web.Areas.En.Controllers
{
    public  class BaseController:Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override BadRequestResult BadRequest()
        {
            return base.BadRequest();
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] ModelStateDictionary modelState)
        {
            return base.BadRequest(modelState);
        }
    }
}
