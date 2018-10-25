using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationAssistt.Domain.Entity;
using EvaluationAssistt.Domain.Dto;

namespace EvaluationAssistt.Service.Services
{
    public class MessagesService
    {
        private static IUnitOfWork _unitOfWork;
        private static IRepository<Messages> _messagesRepository;
        private static IRepository<MessagesAgents> _messagesAgentsRepository;

        public MessagesService()
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = UnityHelper.Container.Resolve<IUnitOfWork>();
            }
            if (_messagesRepository == null)
            {
                _messagesRepository = _unitOfWork.Messages;
            }
            if (_messagesAgentsRepository == null)
            {
                _messagesAgentsRepository = _unitOfWork.MessagesAgents;
            }
        }

        public void SendMessage(string subject, string content, int fromId, List<int> toIds)
        {
            var entity = new Messages()
            { Subject = subject,
                Content = content,
                Date = DateTime.Now
            };

            _messagesRepository.Insert(entity);

            _unitOfWork.Save();


            foreach (var item in toIds)
            {
                _messagesAgentsRepository.Insert(new MessagesAgents()
                {
                    FromId = fromId,
                    ToId = item,
                    MessageId = entity.Id
                });
            }

            _unitOfWork.Save();
        }

        public int GetUnreadMessagesCount(int userId)
        {
            return _messagesAgentsRepository.Find(x => x.ToId == userId && x.IsRead == false).Count();
        }

        public IQueryable<MessagesDto> GetMessagesReceivedByUserId(int userId)
        {
            var result = _messagesAgentsRepository.Find(x => x.ToId == userId)
                            .Select(x => new MessagesDto()
                            {
                                MessageId = x.Messages.Id,
                                FromId = x.FromId,
                                Sender = x.Agents.FirstName + " " + x.Agents.LastName,
                                Subject = x.Messages.Subject,
                                Content = x.Messages.Content,
                                Date = x.Messages.Date,
                                IsRead = x.IsRead
                            });

            return result;
        }

        public string GetMessageById(int messageId)
        {
            return _messagesRepository.FindById(messageId).Content;
        }

        public void MarkMessageAsRead(int toId, int messageId)
        {
            var entity = _messagesAgentsRepository.Find(x => x.ToId == toId && x.MessageId == messageId).FirstOrDefault();

            if (entity == null)
            {
                return;
            }
            entity.IsRead = true;

            _unitOfWork.Save();
        }

        public IQueryable<MessagesDto> GetMessagesSentByUserId(int userId)
        {
            var result = _messagesAgentsRepository.Find(x => x.FromId == userId)
                            .Select(x => new MessagesDto()
                            {
                                MessageId = x.Messages.Id,
                                ToId = x.ToId,
                                To = x.Agents1.FirstName + " " + x.Agents1.LastName,
                                Subject = x.Messages.Subject,
                                Content = x.Messages.Content,
                                Date = x.Messages.Date,
                                IsRead = x.IsRead
                            });

            return result;
        }
    }
}
