using System;
using System.Reflection;

using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class Mapper
    {
        public T Map<T>(object obj)
        {
            T objT = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (objT.GetType().GetProperty(propertyInfo.Name) == null)
                    continue;

                objT.GetType()
                    .GetProperty(propertyInfo.Name)
                    .SetValue(objT, propertyInfo.GetValue(obj));
            }

            return objT;
        }

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

        public OperationResult Map(Operation operation)
        {
            return new OperationResult
            {
                OperationId = operation.OperationId
            };
        }
    }
}