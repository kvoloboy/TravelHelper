using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BusinessLayer.AgencyManagement.Queries;
using BusinessLayer.CategoryManagement.Queries;
using BusinessLayer.LocationsManagement.Queries;
using BusinessLayer.Shared.Constants;
using MediatR;
using TravelHelper.Web.Factories.Interfaces;
using TravelHelper.Web.Models.Shared;
using TravelHelper.Web.Models.Tours.Filters;

namespace TravelHelper.Web.Factories
{
    public class FilterViewModelFactory : IViewModelFactory<FilterSelectedOptionsViewModel, FilterViewModel>
    {
        private readonly IMediator _mediator;

        public FilterViewModelFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<FilterViewModel> CreateAsync(FilterSelectedOptionsViewModel input)
        {
            var selectionData = new FilterSelectionDataViewModel
            {
                SortOptions = SetupSortOptions(input.SortOption),
                Agencies = await SetupAgencies(input.Agencies),
                Categories = await SetupCategories(input.Categories),
                DestinationPoints = await SetupDestinationPoints(input.DestinationPointId)
            };

            var filterViewModel = new FilterViewModel
            {
                Source = selectionData,
                Selected = input
            };

            return filterViewModel;
        }

        private IEnumerable<ListItem<string>> SetupSortOptions(string selectedSort)
        {
            var sortOptions = GetFieldValues(typeof(SortOptions));
            var listItems = sortOptions.Select(option => new ListItem<string>
            {
                Key = option,
                Value = option,
                IsSelected = selectedSort == option
            });

            return listItems;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupAgencies(IEnumerable<int> selectedAgencies)
        {
            var query = new GetAgenciesQuery();
            var agencyDtos = await _mediator.Send(query);
            var listItems = agencyDtos.Select(agency => new ListItem<int>
            {
                Key = agency.Name,
                Value = agency.Id,
                IsSelected = selectedAgencies?.Contains(agency.Id) ?? false
            });

            return listItems;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupCategories(IEnumerable<int> selectedCategories)
        {
            var query = new GetCategoriesQuery();
            var categoryDtos = await _mediator.Send(query);
            var listItems = categoryDtos.Select(agency => new ListItem<int>
            {
                Key = agency.Name,
                Value = agency.Id,
                IsSelected = selectedCategories?.Contains(agency.Id) ?? false
            });

            return listItems;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupDestinationPoints(int selectedPoint)
        {
            var query = new GetLocationsQuery();
            var locationDtos = await _mediator.Send(query);
            var listItems = locationDtos.Select(location => new ListItem<int>
            {
                Key = location.Name,
                Value = location.Id,
                IsSelected = selectedPoint == location.Id
            });

            return listItems;
        }

        private static IEnumerable<string> GetFieldValues(IReflect targetType)
        {
            var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.Static);
            var constants = fields.Where(fi => fi.IsLiteral && !fi.IsInitOnly);
            var values = constants.Select(f => f.GetValue(null)?.ToString()).ToArray();

            return values;
        }
    }
}
