using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController //We created this.
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
	{
		List<AppUser> users = await context.Users.ToListAsync();
		return Ok(users);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersById(int id)
	{
		AppUser user = await context.Users.FindAsync(id) ?? Array.Empty<AppUser>().First();

		if (user == null) return NotFound();

		return Ok(user);
	}
}
