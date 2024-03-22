var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMethods("/", ["OPTIONS"], (ctx) =>
{
    string? webhookRequestOrigin = ctx.Request.Headers["WebHook-Request-Origin"];
    
    ctx.Response.Headers.Append("webhook-allowed-rate", "120");
    ctx.Response.Headers.Append("webhook-allowed-origin", webhookRequestOrigin ?? "*");
    ctx.Response.StatusCode = 200;
    return Task.CompletedTask;
});

app.MapMethods("/", ["POST"], async ctx =>
{
    var request = await ctx.Request.ReadFromJsonAsync<Events>();
    var response = new
    {
        validationResponse = request.First().Data.ValidationCode
    };

    ctx.Response.StatusCode = 200;
    await ctx.Response.WriteAsJsonAsync(response);
});

app.Run();

public class Events : List<EventGridEvent> { }

public class EventGridEvent
{
    public EventGridEventData Data { get; set; }
}

public class EventGridEventData
{
    public string ValidationCode { get; set; }
}