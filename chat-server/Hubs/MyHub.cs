using System.Threading.Tasks;
using Grpc.Net.Client;
using GRPCChatServerUser;


using Microsoft.AspNetCore.SignalR;

public class MyHub : Hub
{
    private IConfigurationRoot ConfigRoot;
    public MyHub(IConfiguration configRoot)
    {
        ConfigRoot = (IConfigurationRoot)configRoot;
    }

    public async Task Ping()
    {
        var backendUri = ConfigRoot.GetServiceUri("chat-server-backend");

        using var channel = GrpcChannel.ForAddress(backendUri?.OriginalString ?? "");
        var client = new GRPCChatServerUser.ChatServerUser.ChatServerUserClient(channel);
        var reply = await client.GetUserAsync(
                          new GRPCChatServerUser.UserRequest { Id = 1 });
        await Clients.Client(Context.ConnectionId).SendAsync("user", reply);
        await Clients.Client(Context.ConnectionId).SendAsync("pong", DateTime.Now);
    }
}