using Microsoft.AspNetCore.SignalR;

namespace NatrolitePlacesWebApi.Hubs;

public interface IMessageHubClient
{
    Task ReceiveMessage(string message);
}

public interface IMessageHub
{
    Task SendMessage(string message);
}

public class MessageHub : Hub<IMessageHubClient>, IMessageHub
{
    public static string Url = "/Message";
    private static ICollection<string> messages = new List<string>();

    private readonly ILogger<MessageHub> logger;

    public MessageHub(ILogger<MessageHub> logger)
    {
        this.logger = logger;
    }

    public async Task SendMessage(string message)
    {
        messages.Add(message);
        await Clients.All.ReceiveMessage(message);

        logger.LogInformation($"The user {Context.ConnectionId} wrote: {message}");
    }

    public async override Task OnConnectedAsync()
    {
        foreach (var message in messages)
        {
            await Clients.Caller.ReceiveMessage(message);
        }
        await Clients.All.ReceiveMessage("A new user joined!");

        foreach (var message in messages)
        {
            logger.LogInformation($"messages contains: {message}");
        }
        logger.LogInformation($"A user entered: {Context.ConnectionId}");
    }

    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.ReceiveMessage("A user left!");
        logger.LogInformation($"A user left: {Context.ConnectionId}");
    }
}
