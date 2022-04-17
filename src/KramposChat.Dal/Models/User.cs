namespace KramposChat.Dal.Models;

public class User
{
	#region Properties
	public List<Chat> Chats
	{
		get;
		init;
	}

	public Guid Id
	{
		get;
		init;
	}

	public string Name
	{
		get;
		init;
	} = null!;
	#endregion
}
