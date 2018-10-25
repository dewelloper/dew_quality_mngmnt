using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationAssistt.Web
{
    public partial class TestWOMaster : System.Web.UI.Page, IAgentManagementView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var presenter = new AgentManagementPresenter(this);

            presenter.GetAgentsAll();

            Response.Write("HELLO WORLD!");
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LoginId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FirstName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LastName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string RegisterNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string IPPhone
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int? TeamId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int AgentTypeId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Linq.IQueryable<Domain.Dto.TeamsDto> Teams
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Linq.IQueryable<Domain.Dto.AgentsDto> Agents
        {
            set
            {
                value.ToList();
            }
        }

        public System.Linq.IQueryable<Domain.Dto.AgentTypesDto> AgentTypes
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Linq.IQueryable<Domain.Dto.PagesDto> Pages
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Linq.IQueryable<Domain.Dto.PagesAgentsDto> PagesAgents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Domain.Dto.AgentsDto Dto
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public bool AllGroupsAccess
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
