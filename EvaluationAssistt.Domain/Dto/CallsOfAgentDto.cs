using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class CallsOfAgentDto
    {
        private int _id = 0;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private int _formId = 0;

        public int FormId
        {
            get
            {
                return _formId;
            }
            set
            {
                _formId = value;
            }
        }

        private string _question = string.Empty;

        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        private int _score = 0;

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        private int _totalScore = 0;

        public int TotalScore
        {
            get
            {
                return _totalScore;
            }
            set
            {
                _totalScore = value;
            }
        }

        private string _resultNote = string.Empty;

        public string ResultNote
        {
            get
            {
                return _resultNote;
            }
            set
            {
                _resultNote = value;
            }
        }

        private string _agentName = string.Empty;

        public string AgentName
        {
            get
            {
                return _agentName;
            }
            set
            {
                _agentName = value;
            }
        }

        private string _callId = string.Empty;

        public string CallId
        {
            get
            {
                return _callId;
            }
            set
            {
                _callId = value;
            }
        }

        private string _phone = string.Empty;

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        private string _date = string.Empty;

        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
    }
}
