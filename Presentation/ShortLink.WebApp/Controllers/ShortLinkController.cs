using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.UrlSchemaService.Query;

namespace ShortLink.WebApp.Controllers;

public class ShortLinkController : Controller
{
    private IMediator _mediator;

    public ShortLinkController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public IActionResult Index(string shortUrl)
    {
        Uri uriResult;
        var response = _mediator.Send(new GetUrlSchemaQuery(shortUrl)).Result;
        if (!response.Error)
        {

            bool result = Uri.TryCreate(response.Data.LongUrl, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result) return Redirect(response.Data.LongUrl);
        }
        return RedirectToPage("/Index", new { ShortUrl = "لینک مورد نظر معتبر نمی باشد", IsError = true });

    }

}