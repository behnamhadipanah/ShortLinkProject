using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShortLink.Application.Contract;
using ShortLink.Application.Contract.UrlSchema;
using ShortLink.Domain.UrlSchemaAgg;
using ShortLink.Framework.Application;
using ShortLink.Framework.Infrastructure;

namespace ShortLink.Application.UrlSchemaService.Query;
public class UrlSchemaQuery : IRequestWrapper<UrlSchemaViewModel>
{
    public string ShortUrl { get; set; }

    public UrlSchemaQuery(string shortUrl)
    {
        ShortUrl = shortUrl;
    }
}

public class UrlSchemaQueryHandler : IHandlerWrapper<UrlSchemaQuery, UrlSchemaViewModel>
{
    private readonly IUrlSchemaRepository _urlSchemaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UrlSchemaQueryHandler(IUrlSchemaRepository urlSchemaRepository, IUnitOfWork unitOfWork)
    {
        _urlSchemaRepository = urlSchemaRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Response<UrlSchemaViewModel>> Handle(UrlSchemaQuery request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var urlSchema = _urlSchemaRepository.GetUrlSchema(request.ShortUrl);
        _unitOfWork.CommitTransaction();

        if (urlSchema != null)
            return await Task.FromResult(Response.Ok<UrlSchemaViewModel>("Success Get UrlSchema", urlSchema));

        return await Task.FromResult(Response.Ok<UrlSchemaViewModel>("UrlSchema Not Found", null));

    }
}
