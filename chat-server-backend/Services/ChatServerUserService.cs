using Grpc.Core;
using GRPCChatServerUser;

namespace GRPCChatServerUser.Services;

#region snippet
public class ChatServerUserService : ChatServerUser.ChatServerUserBase
{
    private readonly ILogger<ChatServerUserService> _logger;
    public ChatServerUserService(ILogger<ChatServerUserService> logger)
    {
        _logger = logger;
    }

    public override Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
    {
        return Task.FromResult(new UserReply
        {
            Id = 1,
            Username = "testuser"
        });
    }
}
#endregion