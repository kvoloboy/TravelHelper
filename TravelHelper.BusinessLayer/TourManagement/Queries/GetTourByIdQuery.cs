﻿using BusinessLayer.Helpers;
using BusinessLayer.Models.DTO;
using MediatR;

namespace BusinessLayer.TourManagement.Queries
{
    public class GetTourByIdQuery : IRequest<Result<TourDto>>
    {
        public int Id { get; set; }
    }
}
