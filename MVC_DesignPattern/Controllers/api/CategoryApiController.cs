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
        private CategoryRepository _categoryRepository;
        public CategoryApiController()
        {
            if (_categoryRepository == null)
                _categoryRepository = new CategoryRepository("ChienHM");
        }
        [HttpGet]
        public List<Category> GetAll(int pIndex, int pSize)
        {
            return _categoryRepository.GetPaging(orderBy: c => c.OrderBy(a => a.Id), pIndex: pIndex, pSize: pSize).ToList();
        }
        [HttpGet]
        public Category GetById(int cateId)
        {
            return _categoryRepository.GetById(cateId);
        }
        [HttpPost]
        public Category Create(Category category)
        {
            return _categoryRepository.Create(category);
        }
        [HttpPut]
        public Category Edit(int categoryId, Category category)
        {
            return _categoryRepository.Edit(categoryId, category);
        }
        [HttpPost]
        public bool Delete(int categoryId)
        {
            return _categoryRepository.Delete(_categoryRepository.GetById(categoryId));
        }
    }
}
