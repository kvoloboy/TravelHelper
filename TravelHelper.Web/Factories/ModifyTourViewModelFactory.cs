using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.AgencyManagement.Queries;
using BusinessLayer.CategoryManagement.Queries;
using BusinessLayer.HotelManagement.Queries;
using MediatR;
using TravelHelper.Web.Factories.Interfaces;
using TravelHelper.Web.Models.Shared;
using TravelHelper.Web.Models.Tours;

namespace TravelHelper.Web.Factories
{
    public class ModifyTourViewModelFactory : IViewModelFactory<ModifyTourViewModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifyTourViewModelFactory(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ModifyTourViewModel> CreateAsync(ModifyTourViewModel input)
        {
            var copy = _mapper.Map<ModifyTourViewModel, ModifyTourViewModel>(input);
            copy.Agencies = await SetupAgencies(input.AgencyId);
            copy.Categories = await SetupCategories(input.CategoryId);
            copy.Hotels = await SetupHotels(input.HotelId);

            return copy;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupHotels(int selectedHotelId)
        {
            var getHotelsQuery = new GetHotelsQuery();
            var hotels = await _mediator.Send(getHotelsQuery);
            var listItems = hotels.Select(hotel => new ListItem<int>
            {
                Key = $"{hotel.City}, {hotel.Name}",
                Value = hotel.Id,
                IsSelected = hotel.Id == selectedHotelId
            });

            return listItems;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupAgencies(int selectedAgencyId)
        {
            var getAgenciesQuery = new GetAgenciesQuery();
            var agencyDtos = await _mediator.Send(getAgenciesQuery);
            var listItems = agencyDtos.Select(agency => new ListItem<int>
            {
                Key = agency.Name,
                Value = agency.Id,
                IsSelected = agency.Id == selectedAgencyId
            });

            return listItems;
        }

        private async Task<IEnumerable<ListItem<int>>> SetupCategories(int selectedCategoryId)
        {
            var getCategoriesQuery = new GetCategoriesQuery();
            var categories = await _mediator.Send(getCategoriesQuery);
            var listItems = categories.Select(category => new ListItem<int>
            {
                Key = category.Name,
                Value = category.Id,
                IsSelected = category.Id == selectedCategoryId
            });

            return listItems;
        }
    }
}
