using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using Common;
namespace Core.Models
{
    public class BaseContext:DbContext, IDisposable
    {
        public BaseContext():base(Constants.ConnectionString)
        {
            Database.SetInitializer<BaseContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }
        public override int SaveChanges()
        {
            throw new Exception(Constants.SaveWarning);
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
