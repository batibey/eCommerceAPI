using eTrade.Application.Abstraction.Services.Configurations;
using eTrade.Application.CustomAttributes;
using eTrade.Application.DTOs.Configuration;
using eTrade.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Infastucture.Services.Configurations
{
    public class ApplicationService : IApplicationService
    {
        public List<Menu> GetAuthorizeDefinationEndpoints(Type type)
        {
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

            List<Menu> menus = new();
            if (controllers != null)
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinationAttribute)));
                    if (actions != null)
                        foreach (var action in actions)
                        {
                            var attributes = action.GetCustomAttributes(true);
                            if (attributes != null)
                            {
                                Menu menu = null;

                                var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinationAttribute)) as AuthorizeDefinationAttribute;
                                if (!menus.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
                                {
                                    menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                    menus.Add(menu);
                                }
                                else
                                    menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);

                                Application.DTOs.Configuration.Action _action = new()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                    Defination = authorizeDefinitionAttribute.Defination
                                };

                                var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttribute != null)
                                    _action.HttpType = httpAttribute.HttpMethods.First();
                                else
                                    _action.HttpType = HttpMethods.Get;

                                _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Defination.Replace(" ", "")}";

                                menu.Actions.Add(_action);
                            }
                        }
                }


            return menus;
        }
    }
}
