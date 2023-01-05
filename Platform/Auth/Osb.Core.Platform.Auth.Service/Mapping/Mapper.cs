using System;
using System.Reflection;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class Mapper
    {
        public T UpdateMap<T>(object request, object entity)
        {
            T objT = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in objT.GetType().GetProperties())
            {
                if (request.GetType().GetProperty(propertyInfo.Name) == null)
                    continue;

                if ((request.GetType().GetProperty(propertyInfo.Name).GetValue(request)) != null)
                    objT.GetType()
                        .GetProperty(propertyInfo.Name)
                        .SetValue(objT, request.GetType().GetProperty(propertyInfo.Name).GetValue(request));
                else
                    objT.GetType()
                        .GetProperty(propertyInfo.Name)
                        .SetValue(objT, entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity));
            }

            return objT;
        }
    }
}