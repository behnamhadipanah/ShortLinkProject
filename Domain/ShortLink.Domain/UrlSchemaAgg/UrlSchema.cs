using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShortLink.Framework.Domain;

namespace ShortLink.Domain.UrlSchemaAgg;
public class UrlSchema:DomainBase
{
    #region Properties
    
    public string LongUrl { get; private set; }
    public string ShortUrl { get; private set; }
    public DateTime CreationDate { get; private set; }
    #endregion


    #region Constructor

    protected UrlSchema()
    {
        
    }

    public UrlSchema(string longUrl,string shortUrl)
    {
        Validate(longUrl, shortUrl);
        LongUrl=longUrl;
        ShortUrl=shortUrl;
        CreationDate=DateTime.Now;
    }

    #endregion

    #region Method
    private void Validate(string longUrl, string shortUrl)
    {
        if (string.IsNullOrWhiteSpace(longUrl))
            throw new ArgumentNullException("longUrl is Nulled");

        if (string.IsNullOrWhiteSpace(shortUrl))
            throw new ArgumentNullException("shortUrl is Nulled");
    }



    #endregion
}
