using MediatR;

namespace WebTest.Applicationn.IQueries
{
    internal interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
