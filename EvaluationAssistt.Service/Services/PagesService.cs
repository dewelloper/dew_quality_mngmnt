using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class PagesService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Pages> _pagesRepository;
        private static IRepository<PagesAgents> _pagesAgentsRepository;

        public PagesService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_pagesRepository == null)
            {
                _pagesRepository = _unitOfWork.Pages;
            }
            if (_pagesAgentsRepository == null)
            {
                _pagesAgentsRepository = _unitOfWork.PagesAgents;
            }
        }

        public IQueryable<PagesAgentsDto> GetPagesByAgentId(int agentId)
        {
            var result = _pagesAgentsRepository.Find(x => x.AgentId == agentId)
                            .Select(x => new PagesAgentsDto()
                            {
                                Id = x.Id,
                                PageId = x.PageId,
                                PageName = x.Pages.Name,
                                PageDescription = x.Pages.Description
                            });

            return result;
        }

        public IQueryable<PagesAgentsDto> GetPagesBookmarkedByAgentId(int agentId)
        {
            var result = _pagesAgentsRepository.Find(x => x.AgentId == agentId && x.IsBookmarked == true)
                            .Select(x => new PagesAgentsDto()
                            {
                                Id = x.Id,
                                PageId = x.PageId,
                                PageName = x.Pages.Name,
                                PageDescription = x.Pages.Description,
                                IsBookmarked = x.IsBookmarked
                            });

            return result;
        }

        public IQueryable<PagesDto> GetPagesNameValueCollection()
        {
            var result = _pagesRepository.All()
                            .Select(x => new PagesDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description
                            });

            return result;
        }

        public void UpdateAgentPagesByAgentId(int agentId, IQueryable<PagesAgentsDto> pages)
        {
            var listToDelete = _pagesAgentsRepository.Find(x => x.AgentId == agentId).ToList();

            foreach (var item in listToDelete)
            {
                _pagesAgentsRepository.Delete(item, true);
            }

            foreach (var item in pages)
            {
                _pagesAgentsRepository.Insert(new PagesAgents()
                {
                    AgentId = agentId,
                    PageId = item.PageId,
                    IsBookmarked = false
                });
            }

            _unitOfWork.Save();
        }

        public void BookmarkPage(int agentId, string pageName)
        {
            var entity = _pagesAgentsRepository.Find(x => x.AgentId == agentId && x.Pages.Name == pageName).FirstOrDefault();

            entity.IsBookmarked = true;

            _unitOfWork.Save();
        }

        public List<string> GetPageNamesByAgentId(int agentId)
        {
            var result = _pagesAgentsRepository.Find(x => x.AgentId == agentId)
                            .Select(x => x.Pages.Name).ToList();

            return result;
        }

        public void UpdateBookmarkedPages(int agentId, IQueryable<PagesAgentsDto> pages)
        {
            var pagesAgent = _pagesAgentsRepository.Find(x => x.AgentId == agentId);

            foreach (var item in pagesAgent)
            {
                item.IsBookmarked = false;
            }

            foreach (var item in pages)
            {
                var page = pagesAgent.Where(x => x.PageId == item.PageId).FirstOrDefault();
                page.IsBookmarked = true;
            }

            _unitOfWork.Save();
        }
    }
}
