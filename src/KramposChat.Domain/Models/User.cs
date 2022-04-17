namespace KramposChatDomain.Models;

/// <summary>
/// Представялет модель пользователя.
/// </summary>
public class User
{
	#region .ctor
	public User(Guid id, string name)
	{
		Id = id;
		Name = name ?? throw new ArgumentNullException();
	}
	#endregion

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
	}
	#endregion
}
