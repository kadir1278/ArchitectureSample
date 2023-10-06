using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Helper;

namespace CoreLayer.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ScriptEncryptAndDecrypt(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        modelBuilder.Entity(entityType.Name)
                                    .Property(property.Name)
                                    .HasConversion(new ValueConverter<string, string>(v => EncryptionHelper.EncryptPassword(v),
                                                                                      v => EncryptionHelper.DecryptPassword(v)));
                    }
                }

            }

            return modelBuilder;
        }

    }
}
