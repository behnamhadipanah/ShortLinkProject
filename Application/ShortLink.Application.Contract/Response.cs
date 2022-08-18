namespace ShortLink.Framework.Application;

public static class Response
{
    public static Response<T> Fail<T>(string message, T data = default) =>
        new Response<T>(data, message, true);
    public static Response<T> Fail<T>(string message) =>
        new Response<T>(message, true);
    public static Response<T> Ok<T>(string message, T data = default) =>
        new Response<T>(data, message, false);
    public static Response<T> Ok<T>(string message) =>
        new Response<T>(message, false);

}

public class Response<T>
{


    public T Data { get; set; }

    public string Message { get; set; }

    public bool Error { get; set; }

    public Response(T data, string message, bool error)
    {
        Data = data;
        Message = message;
        Error = error;
    }
    public Response(string message, bool error)
    {
        Message = message;
        Error = error;
    }
}