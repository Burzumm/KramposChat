using KramposChatDomain.Models;
using Microsoft.AspNetCore.SignalR;

namespace KramposChat.Service.SignalRHub;

public class ChatHub : Hub
{
	#region Public
	public async Task AddUser(string userName, Chat chat)
	{
		var newUser = new User(Guid.NewGuid(), userName);
		chat.AddUser(newUser);
		await Clients.All.SendAsync("addUser", chat);
	}

	public async Task CreateChat(string chatName)
	{
		var chat = new Chat(Guid.NewGuid(), chatName);
		await Clients.All.SendAsync("createChat", chat);
	}

	public async Task SendMessage(string userName, string message, Chat chat)
	{
		if (chat.Users.Exists(user => user.Name == userName))
		{
			var userChat = chat.Users.SingleOrDefault(user => user.Name == userName);
		}

		var user = new User(Guid.NewGuid(), userName);
		chat.AddMessage(user, message);
		await Clients.All.SendAsync("sendMessage", chat);
	}
	#endregion
}
