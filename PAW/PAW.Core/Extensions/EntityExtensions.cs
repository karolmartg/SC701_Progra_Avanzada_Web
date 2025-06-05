using PAW.Models.Enums;
using PAW.Models.PAWModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Core.Extensions
{
    public static class EntityExtensions
    {
        public static void AddAudit(this IEntity entity, string user)
        {
            if (entity.IsDirty ?? false)
            {
                // si NO ha sido modificado
                if (entity.TempID <= 0)
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = user;
                }
                else
                {
                    entity.ModifiedDate = DateTime.Now;
                    entity.ModifiedBy = user;
                }
            }

        }

        public static void AddLogging(this IEntity entity, LoggingType loggingType)
        {
            if (loggingType == LoggingType.Create)
            {
                Debug.WriteLine("Creating Object");
                return;
            }
            if (loggingType == LoggingType.Update)
            {
                Debug.WriteLine("Updating Object");
                return;
            }
            if (loggingType == LoggingType.Delete)
            {
                Debug.WriteLine("Deleting Object");
                return;
            }
            if (loggingType == LoggingType.Read)
            {
                Debug.WriteLine("Reading Object");
                return;
            }
        }
    }
}
