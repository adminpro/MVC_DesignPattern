﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models.LessionLearn;

namespace Core.Models.Repository
{
    public class ChapterRepository : BaseRepository<int, Chapter>
    {
        public ChapterRepository(string userName)
            : base(userName)
        {

        }
    }
}
