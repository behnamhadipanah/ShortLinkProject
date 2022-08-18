using shortid;
using shortid.Configuration;
using ShortLink.Application.Contract;
using ShortLink.Application.Contract.UrlSchema;
using ShortLink.Domain.UrlSchemaAgg;
using ShortLink.Framework.Application;
using ShortLink.Framework.Infrastructure;

namespace ShortLink.Application.UrlSchemaService.Command;

public class CreateUrlSchemaCommand:IRequestWrapper<CreateUrlSchemaViewModel>
{
    public UrlSchema UrlSchema{ get; set; }
    public CreateUrlSchemaViewModel SchemaViewModel { get; set; }
    public CreateUrlSchemaCommand(CreateUrlSchemaViewModel model)
    {
        var options = new GenerationOptions(useSpecialCharacters: false,useNumbers:true,length:9);

        model.ShortUrl = ShortId.Generate(options);
        UrlSchema = new UrlSchema(model.LongUrl, model.ShortUrl);
        SchemaViewModel = model;
    }
}

public class CreateUrlSchemaCommandHandler : IHandlerWrapper<CreateUrlSchemaCommand, CreateUrlSchemaViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUrlSchemaRepository _urlSchemaRepository;

    public CreateUrlSchemaCommandHandler(IUnitOfWork unitOfWork, IUrlSchemaRepository urlSchemaRepository)
    {
        _unitOfWork = unitOfWork;
        _urlSchemaRepository = urlSchemaRepository;
    }
    public async Task<Response<CreateUrlSchemaViewModel>> Handle(CreateUrlSchemaCommand request,
        CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        _urlSchemaRepository.Add(request.UrlSchema);
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<CreateUrlSchemaViewModel>("Success Get UrlSchema",request.SchemaViewModel));

        return await Task.FromResult(Response.Fail<CreateUrlSchemaViewModel>("UrlSchema Not Registered", request.SchemaViewModel));

    }
}
