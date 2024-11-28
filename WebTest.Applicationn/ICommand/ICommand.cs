using MediatR;

namespace WebTest.Applicationn.ICommand
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<out TResult> : IRequest<TResult>
    {

    }
}
