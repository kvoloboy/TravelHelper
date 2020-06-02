﻿using BusinessLayer.Helpers;
using MediatR;

namespace BusinessLayer.AgencyManagement.Commands
{
    public class DeleteAgencyCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}