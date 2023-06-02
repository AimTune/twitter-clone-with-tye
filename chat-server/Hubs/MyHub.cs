using System.Security.Claims;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

[Authorize]
public class MyHub : Hub
{
    private IConfigurationRoot ConfigRoot;
    public MyHub(IConfiguration configRoot)
    {
        ConfigRoot = (IConfigurationRoot)configRoot;
    }
    public override async Task OnConnectedAsync()
    {

        if (Context.User?.Identity?.IsAuthenticated ?? false)
        {
            await Clients.Client(Context.ConnectionId).SendAsync("authenticated", true);
            var username = Context.User?.Claims?.FirstOrDefault(x => x.Type == "preferred_username");
            if (username != null)
                await Clients.Client(Context.ConnectionId).SendAsync("username", username.Value);

            await base.OnConnectedAsync();
            return;
        }
        await Clients.Client(Context.ConnectionId).SendAsync("authenticated", false);
        Context.Abort();
    }

    public async Task Ping()
    {
        var backendUri = ConfigRoot.GetConnectionString("chat-server-backend");

        using var channel = GrpcChannel.ForAddress(backendUri!);
        var client = new GRPCChatServerUser.ChatServerUser.ChatServerUserClient(channel);

        var headers = new Metadata();
        headers.Add("Authorization", $"Bearer {Context.GetHttpContext()?.Request.Query["access_token"]!}");

        var username = Context.User?.Claims?.FirstOrDefault(x => x.Type == "sid")!.Value;


        var reply = await client.GetUserAsync(
                          new GRPCChatServerUser.UserRequest { Id = username }, headers);
        await Clients.Client(Context.ConnectionId).SendAsync("user", reply);
        await Clients.Client(Context.ConnectionId).SendAsync("pong", DateTime.Now);
    }
}