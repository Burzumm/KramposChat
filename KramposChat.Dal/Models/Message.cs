namespace KramposChat.Dal.Models;

public class Message
{
	#region Properties
	public User Author
	{
		get;
		init;
	}

	public string Text
	{
		get;
		init;
	}
	#endregion
}
