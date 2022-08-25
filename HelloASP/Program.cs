var builder = WebApplication.CreateBuilder();
// Ветки
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time",
    HandleTimeRequest
    );

app.Run(async(context) =>
    {
        await context.Response.WriteAsync("hello asp");
});

app.Run();

void HandleTimeRequest(IApplicationBuilder appBuilder)
{
    appBuilder.Use(async (context, next) =>
    {
        var time = DateTime.Now.ToShortTimeString();
        Console.WriteLine($"Time:{time}");
        await next();
    });
}