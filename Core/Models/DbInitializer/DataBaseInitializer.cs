using Core.Models;
using System.Data.Entity;

namespace SqlDatabase.DbInitializer
{
    public class DataBaseInitializer : IDatabaseInitializer<BaseContext>
    {
        public void InitializeDatabase(BaseContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
