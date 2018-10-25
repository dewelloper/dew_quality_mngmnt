using EvaluationAssistt.Domain.Dto;
using EvaluationAssistt.Infrastructure.Enums;
using EvaluationAssistt.Infrastructure.Extensions;
using EvaluationAssistt.Infrastructure.Helpers;
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Presenter.Presenters;
using EvaluationAssistt.Web.JsHelpers;
using System;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvaluationAssistt.Web.Pages
{
    public partial class LocationManagement : EvaluationAssisttPage, ILocationManagementView
    {
        public int Id
        {
            get
            {
                if (ViewState["Id"] == null)
                {
                    ViewState["Id"] = 0;
                }

                return Convert.ToInt32(ViewState["Id"]);
            }
            set
            {
                ViewState["Id"] = value;
            }
        }

        public string Name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public IQueryable<LocationsDto> Locations
        {
            set
            {
                gridviewLocations.DataSource = value.ToList();
                gridviewLocations.DataBind();
            }
        }

        public LocationsDto Dto
        {
            get
            {
                var dto = new LocationsDto()
                { Id = Id,
                    Name = Name
                };


                return dto;
            }
        }

        private LocationManagementPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (presenter == null)
            {
                presenter = new LocationManagementPresenter(this);
            }
            presenter.GetLocationsAll();

            if (EntitySelect)
            {
                presenter.GetLocationById(EntityId);
                NewEntryUI();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                presenter.InsertLocation();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessInsert("Lokasyon"));
            }
            else
            {
                presenter.UpdateLocation();
                JsPopup.Popup(this, MessageType.Success, MessageHelper.CRUDMessage.SuccessUpdate("Lokasyon"));
            }

            presenter.GetLocationsAll();
            CancelEntryUI();
        }

        [WebMethod]
        public static void DeleteLocation(int id)
        {
            var presenter =
                new LocationManagementPresenter(HttpContext.Current.Handler as LocationManagement);

            presenter.DeleteLocation(id);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            CancelEntryUI();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            NewEntryUI();
        }

        private void NewEntryUI()
        {
            pnlRegister.Visible = true;
            btnNew.Visible = false;
        }

        private void CancelEntryUI()
        {
            pnlRegister.Clear();
            pnlRegister.Visible = false;
            btnNew.Visible = true;
            Id = 0;
        }
    }
}
