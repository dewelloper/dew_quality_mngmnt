using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Service.Services
{
    public class CallsEvaluatedService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<CallsEvaluated> _callsEvaluatedRepository;

        public CallsEvaluatedService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_callsEvaluatedRepository == null)
            {
                _callsEvaluatedRepository = _unitOfWork.CallsEvaluated;
            }
        }

        public Tuple<bool, string> GetIfAnswerExists(int formCallId, int questionId, int answerId)
        {
            var entity = _callsEvaluatedRepository.Find(x => x.FormCallId == formCallId && x.QuestionId == questionId && x.AnswerId == answerId).FirstOrDefault();

            if (entity == null)
            {
                return new Tuple<bool, string>(false, null);
            }
            return new Tuple<bool, string>(true, entity.Comment);
        }
    }
}
