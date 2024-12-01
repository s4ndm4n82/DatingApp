using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipleExtensions
{
	public static string GetUsername(this ClaimsPrincipal user)
	{
		var username = (user.FindFirst(ClaimTypes.NameIdentifier)?.Value)
		?? throw new Exception("No user name found in token");
		return username;
	}
}
