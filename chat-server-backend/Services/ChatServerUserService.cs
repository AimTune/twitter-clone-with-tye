using Grpc.Core;
using GRPCChatServerUser;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace GRPCChatServerUser.Services;

#region snippet
[Authorize]
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
            Id = context.GetHttpContext().User?.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            Username = context.GetHttpContext().User?.Claims?.FirstOrDefault(x => x.Type == "preferred_username").Value
        });
    }
}
#endregion