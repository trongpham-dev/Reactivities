using Domain;
using MediatR;
using Persistence;

namespace Application.Actitvities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken) => await this._context.Activities.FindAsync(request.Id);
        }
    }
}