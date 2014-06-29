using Core.Models;
using System.Data.Entity;

namespace SqlDatabase.DbInitializer
{
    public class DataBaseInitializer : IDatabaseInitializer<BaseContext>
    {
        public void InitializeDatabase(BaseContext context)
        {
            //if (context.Database.Exists())
            //    if (context.Database.Delete())
            //        context.Database.Create();
            context.Database.CreateIfNotExists();
        }
    }
}
