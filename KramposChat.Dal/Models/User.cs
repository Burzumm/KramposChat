namespace KramposChat.Dal.Models;

public class User
{
	#region Properties
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
