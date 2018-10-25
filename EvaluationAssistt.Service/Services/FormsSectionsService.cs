using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class FormsSectionsService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<FormsSections> _formsSectionsRepository;
        private static IRepository<Sections> _sectionsRepository;

        public FormsSectionsService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_formsSectionsRepository == null)
            {
                _formsSectionsRepository = _unitOfWork.FormsSections;
            }
            if (_sectionsRepository == null)
            {
                _sectionsRepository = _unitOfWork.Sections;
            }
        }

        public void InsertFormsSections(IQueryable<FormsSectionsDto> collection)
        {
            var formId = collection.FirstOrDefault().FormId;

            var listToDelete = _formsSectionsRepository
                                                    .Find(x => x.FormId == formId);

            foreach (var item in listToDelete)
            {
                _formsSectionsRepository.Delete(item, true);
            }


            var list = collection
                                                .Select(x => new FormsSections()
            { FormId = x.FormId,
                                                    SectionId = x.SectionId
            });

            foreach (var item in list)
            {
                _formsSectionsRepository.Insert(item);
            }

            _unitOfWork.Save();
        }

        public void DeleteFormsSections(int formId)
        {
            var listToDelete = _formsSectionsRepository
                                               .Find(x => x.FormId == formId);

            foreach (var item in listToDelete)
            {
                _formsSectionsRepository.Delete(item, true);
            }

            _unitOfWork.Save();
        }

        public IQueryable<SectionsDto> GetSectionsByFormId(int formId)
        {
            var sectionIds = _formsSectionsRepository.Find(x => x.FormId == formId)
                                        .Select(x => x.SectionId).ToList();

            var result = _sectionsRepository.Find(x => sectionIds.Contains(x.Id))
                                     .Select(x => new SectionsDto()
                                     {
                                         Id = x.Id,
                                         Name = x.Name,
                                         IsDisabled = x.IsDisabled,
                                         MinimumScore = x.MinimumScore,
                                         MaximumScore = x.MaximumScore,
                                         ScoreTypeId = x.ScoreTypeId,
                                         ScoreTypeName = x.ScoreTypes.Name
                                     });

            var forOrder = new List<SectionsDto>();
            foreach (SectionsDto sdo in result)
            {
                var sec = _formsSectionsRepository.Find(k => k.SectionId == sdo.Id).FirstOrDefault();
                sdo.OrderId = sec.Id;
                forOrder.Add(sdo);
            }

            return forOrder.OrderBy(k => k.OrderId).AsQueryable();
        }
    }
}
