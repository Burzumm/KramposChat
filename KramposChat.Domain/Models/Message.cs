namespace KramposChatDomain.Models;

public class Message
{
	#region .ctor
	public Message(User user, string text)
	{
		Author = user ?? throw new ArgumentNullException(nameof(user));
		if (string.Equals(text, string.Empty))
		{
			throw new ArgumentException(nameof(text));
		}

		Text = text;
	}
	#endregion

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
