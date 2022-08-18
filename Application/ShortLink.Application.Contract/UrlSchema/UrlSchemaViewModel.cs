namespace ShortLink.Application.Contract.UrlSchema;

public class UrlSchemaViewModel
{
    public long Id { get; set; }
    public string LongUrl { get; set; }
    public string ShortUrl { get; set; }
    public string CreationDate { get; set; }
}