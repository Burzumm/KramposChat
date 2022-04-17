namespace KramposChat.Dal.Models;

/// <summary>
/// Представляет модель чата.
/// </summary>
public class Chat
{
	#region Properties
	public Guid Id
	{
		get;
		init;
	}

	public List<Message> Messages
	{
		get;
	} = new();

	public string Name
	{
		get;
		init;
	}

	public List<User> Users
	{
		get;
	} = new();
	#endregion
}
