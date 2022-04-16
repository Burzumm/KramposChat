using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KramposChat.Service.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class ErrorModel : PageModel
{
	#region Data
	#region Fields
	private readonly ILogger<ErrorModel> _logger;
	#endregion
	#endregion

	#region .ctor
	public ErrorModel(ILogger<ErrorModel> logger) => _logger = logger;
	#endregion

	#region Properties
	public string? RequestId
	{
		get;
		set;
	}

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	#endregion

	#region Public
	public void OnGet()
	{
		RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
	}
	#endregion
}
