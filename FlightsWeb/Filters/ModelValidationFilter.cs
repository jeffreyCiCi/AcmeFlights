using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FlightsWeb.ViewModels;

namespace FlightsWeb.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            CheckFlightsViewModel vm;
            if( context.ActionArguments.ContainsKey("vm"))
            {
                vm = (CheckFlightsViewModel)context.ActionArguments["vm"];

                // Validate input argument
                if(vm.StartDate <= DateTime.Now)
                {
                    context.Result = new BadRequestObjectResult(
                        new {message="start date cannot be earlier than current date."}); 
                }
                else if(vm.EndDate >= DateTime.Now.AddMonths(3))
                {
                    context.Result = new BadRequestObjectResult(
                        new {message="End date cannot be later than 3 months from now."}); 
                }
                else if(vm.EndDate < vm.StartDate)
                {
                    context.Result = new BadRequestObjectResult(
                        new {message="End date cannot be earlier than start date."}); 
                }   
            }
        }
    }
}