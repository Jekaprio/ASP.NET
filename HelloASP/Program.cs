var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var path = context.Request.Path;
    var fullpath = $"html/{path}";
    var response = context.Response;

    response.ContentType = "text/html; charset=utf-8";
    if (File.Exists(fullpath))
        await response.SendFileAsync(fullpath);
    else
    {
        response.StatusCode = 404;
        await context.Response.WriteAsync("Page not found");
    }
});

app.Run();