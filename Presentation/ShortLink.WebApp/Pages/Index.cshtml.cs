using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShortLink.Application.Contract.UrlSchema;
using ShortLink.Application.UrlSchemaService.Command;

namespace ShortLink.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private IMediator _mediator;
        public string ShortUrl="";
        public bool IsError=false;
        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public void OnGet(string shortUrl,bool isError)
        {
            ShortUrl = shortUrl;
            IsError = isError;
        }

        public RedirectToPageResult OnPost(CreateUrlSchemaViewModel command)
        {
            var response = _mediator.Send(new CreateUrlSchemaCommand(command)).Result;
            if (!response.Error)
            {
                ShortUrl = response.Data.ShortUrl;
                return RedirectToPage("./Index", new { ShortUrl = GetBaseUrl() + "/" + ShortUrl, IsError = false });
            }
            return RedirectToPage("./Index", new { ShortUrl = GetBaseUrl() + "/" + ShortUrl, IsError = true });

        }

        public string GetBaseUrl()
        {
            var request = HttpContext.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";
        }
    }
}