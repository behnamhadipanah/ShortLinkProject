using MediatR;
using ShortLink.Framework.Application;

namespace ShortLink.Application.Contract;

public interface IRequestWrapper<T> : IRequest<Response<T>> { }

public interface IHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
    where TIn : IRequestWrapper<TOut>
{
}