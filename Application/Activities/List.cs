using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Actitvities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {
        }

        //handler class
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this._context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}