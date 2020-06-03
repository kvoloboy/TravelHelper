using System.Collections.Generic;
using BusinessLayer.TourManagement.DTO;
using MediatR;
using TravelHelper.Domain.Models;
using TravelHelper.Domain.Models.Enums;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetToursQuery : IRequest<List<TourDto>>
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Name { get; set; }
        public TimeOfTheYear? TimeOfTheYear { get; set; }
        public int SourcePointId { get; set; }
        public int DestinationPointId { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public IEnumerable<int> Agencies { get; set; }
        public string SortOption { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
