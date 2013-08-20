using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace Core.Models
{
    public class BaseContext:DbContext
    {
        public BaseContext():base("StrConnect")
        {
            Database.SetInitializer<BaseContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }
        public override int SaveChanges()
        {
            throw new Exception("Your must be use repository of entity SaveChanges with userName argument.");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            Database.SetInitializer<BaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }


    }
}
