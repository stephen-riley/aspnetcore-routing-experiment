using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RouteTest1.Stuff
{
    public sealed class RequiredFromQueryAttribute : FromQueryAttribute, IActionConstraint, IParameterModelConvention
    {
        private string? parameterName;

        public void Apply(ParameterModel parameter)
        {
            if (parameter.Action.Selectors != null && parameter.Action.Selectors.Any())
            {
                parameterName = parameter.BindingInfo?.BinderModelName ?? parameter.ParameterName;
                parameter.Action.Selectors.Last().ActionConstraints.Add(this);
            }
        }

        public int Order => 999;

        public bool Accept(ActionConstraintContext context)
        {
            if (!context.RouteContext.HttpContext.Request.Query.ContainsKey(parameterName))
            {
                return false;
            }

            return true;
        }
    }
}