using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Utils;
using BusinessLayer.Utils.DTO;
using MediatR;
using TravelHelper.Domain.Abstractions;
using TravelHelper.Domain.Models.Identity;

namespace BusinessLayer.UserManagement.Queries
{
    public class GetUSerByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IReadonlyRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUSerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = unitOfWork.GetRepository<User>();
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindSingleAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return Result.Fail<UserDto>($"Not found user with id: {request.Id}");
            }

            var dto = _mapper.Map<User, UserDto>(user);

            return Result.Ok(dto);
        }
    }
}
