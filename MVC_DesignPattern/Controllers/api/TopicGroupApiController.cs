using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Models.Repository;
using Core.Models.LessionLearn;


namespace MVC_DesignPattern.Controllers.api
{
    public class TopicGroupApiController : ApiController
    {
        private TopicGroupRepository _topicGroupRepository;
        public TopicGroupApiController()
        {
            if (_topicGroupRepository == null)
                _topicGroupRepository = new TopicGroupRepository("ChienHM");
        }
        [HttpGet]
        public List<TopicGroup> GetAll(int pIndex, int pSize)
        {
            return _topicGroupRepository.GetPaging(orderBy: c => c.OrderBy(a => a.Id), pIndex: pIndex, pSize: pSize).ToList();
        }
        [HttpGet]
        public TopicGroup GetById(int topicGroupId)
        {
            return _topicGroupRepository.GetById(topicGroupId);
        }
        [HttpPost]
        public TopicGroup Create(TopicGroup topicGroup)
        {
            return _topicGroupRepository.Create(topicGroup);
        }
        [HttpPut]
        public TopicGroup Edit(int topicGroupId, TopicGroup topicGroup)
        {
            return _topicGroupRepository.Edit(topicGroupId, topicGroup);
        }
        [HttpPost]
        public bool Delete(int topicGroupId)
        {
            return _topicGroupRepository.Delete(_topicGroupRepository.GetById(topicGroupId));
        }
    }
}
