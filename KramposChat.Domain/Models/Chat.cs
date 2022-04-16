namespace KramposChatDomain.Models;

/// <summary>
/// Представляет модель чата.
/// </summary>
public class Chat
{
	#region .ctor
	public Chat(Guid id, string name)
	{
		Id = id;
		Name = name ?? throw new ArgumentNullException(nameof(name));
	}
	#endregion

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

	#region Public
	public void AddMessage(User user, string message)
	{
		var newMessage = new Message(user, message);
		Messages.Add(newMessage);
	}

	public void AddUser(User user)
	{
		Users.Add(user);
	}
	#endregion
}
