using MediatR;

namespace WebTest.Applicationn.IQueries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
