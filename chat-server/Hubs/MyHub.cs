using Microsoft.AspNetCore.SignalR;

public class MyHub : Hub
{
    public Task Ping()
    {
        return Clients.Client(Context.ConnectionId).SendAsync("pong", DateTime.Now);
    }
}