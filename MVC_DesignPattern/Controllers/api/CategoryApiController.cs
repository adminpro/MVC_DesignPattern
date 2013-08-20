using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Models;
using Core.Models.Repository;


namespace MVC_DesignPattern.Controllers.api
{
    public class CategoryApiController : ApiController
    {
        private NewsRepository _newsRepository;
        public CategoryApiController()
        {
            if (_newsRepository == null)
                _newsRepository = new NewsRepository("ChienHM");
        }

        public List<News> GetAll(int pIndex, int pSize)
        {
            return _newsRepository.GetPaging(pIndex: pIndex, pSize: pSize).ToList();
        }
    }
}
