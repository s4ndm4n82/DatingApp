﻿using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController //We created this.
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
	{
		var users = await userRepository.GetMembersAsync();

		return Ok(users);
	}

	[HttpGet("{username}")]
	public async Task<ActionResult<MemberDto>> GetUser(string username)
	{
		var user = await userRepository.GetMemberAsync(username);

		if (user == null) return NotFound();

		return user;
	}
}
