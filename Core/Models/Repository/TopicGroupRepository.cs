using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models.LessionLearn;

namespace Core.Models.Repository
{
    public class TopicGroupRepository : BaseRepository<int, TopicGroup>
    {
        public TopicGroupRepository(string userName)
            : base(userName)
        {

        }
    }
}
