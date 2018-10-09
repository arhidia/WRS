using System;
using System.Reflection;
using WashingtonRedskins.Validation;
using Grapevine.Interfaces.Server;
using System.Web;
using System.ComponentModel;
using System.Collections.Specialized;

namespace WashingtonRedskins.Controllers
{
    public class BaseController
    {
        public static T getUserInput<T>(IHttpContext context, ValidationCollection validation)
             where T : class, IHasBasicIndexer
        {
            NameValueCollection data;
            dynamic target = (T)Activator.CreateInstance(typeof(T));
            if (context.Request.HttpMethod == Grapevine.Shared.HttpMethod.GET)
            {
                data = context.Request.QueryString;
            }
            else 
            {
                data = Parsers.parseURLEncoded(context.Request.Payload);
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            var res = HttpUtility.ParseQueryString(context.Request.Payload);
            foreach (PropertyInfo property in properties)
            {
                if (validation.rows.ContainsKey(property.Name))
                {
                    foreach (validateDelegate del in validation.rows[property.Name])
                    {
                        if (!del.Invoke(data[property.Name]))
                        {
                            return null;
                        }
                    }

                    Type currentType = property.PropertyType;

                    if (data[property.Name] != null)
                    {
                        var converter = TypeDescriptor.GetConverter(currentType);
                        var val = converter.ConvertFromString(data[property.Name]);
                        property.SetValue(target, val, null);
                    }
                }
            }
            return target;
        }
    }
}
