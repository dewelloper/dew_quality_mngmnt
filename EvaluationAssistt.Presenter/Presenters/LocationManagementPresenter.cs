
using EvaluationAssistt.Presenter.Interfaces;
using EvaluationAssistt.Service.Services;

namespace EvaluationAssistt.Presenter.Presenters
{
    public class LocationManagementPresenter
    {
        private readonly ILocationManagementView view;

        private static LocationsService _locationsService;

        public LocationManagementPresenter(ILocationManagementView view)
        {
            this.view = view;

            if (_locationsService == null)
            {
                _locationsService = new LocationsService();
            }
        }

        public void GetLocationsAll()
        {
            var result = _locationsService.GetLocationsAll();

            view.Locations = result;
        }

        public void GetLocationById(int locationId)
        {
            var result = _locationsService.GetLocationById(locationId);

            view.Id = result.Id;
            view.Name = result.Name;
        }

        public void InsertLocation()
        {
            var dto = view.Dto;

            _locationsService.InsertLocation(dto);
        }

        public void UpdateLocation()
        {
            var dto = view.Dto;

            _locationsService.UpdateLocation(dto);
        }

        public void DeleteLocation(int id)
        {
            _locationsService.DeleteLocation(id);
        }
    }
}
