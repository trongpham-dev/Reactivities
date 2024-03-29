using Application.Activities;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Actitvities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>>
        {
        }

        //handler class
        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await this._context.Activities.ProjectTo<ActivityDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                return Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}