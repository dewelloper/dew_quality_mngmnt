using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Domain.Dto
{
    public class TeamCallsDto
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

        private int _agentId = 0;

        public int AgentId
        {
            get
            {
                return _agentId;
            }
            set
            {
                _agentId = value;
            }
        }

        private double _avarageScore = 0;

        public double AvarageScore
        {
            get
            {
                return _avarageScore;
            }
            set
            {
                _avarageScore = value;
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

        private int _callCount = 0;

        public int CallCount
        {
            get
            {
                return _callCount;
            }
            set
            {
                _callCount = value;
            }
        }

        private string _agentIdIP = string.Empty;

        public string AgentIdIP
        {
            get
            {
                return _agentIdIP;
            }
            set
            {
                _agentIdIP = value;
            }
        }
    }
}
