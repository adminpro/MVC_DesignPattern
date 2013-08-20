using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models.Interface;

namespace Core.Models.Repository
{
    public class NewsRepository:BaseRepository<int,News>, INewsRepository<int>
    {
        public NewsRepository(string userName):base(userName)
        {

        }
    }
}
