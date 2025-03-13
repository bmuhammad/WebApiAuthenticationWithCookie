﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApiAuthentication.ClientWithAPI.ApiControllers;

/// <summary>
/// Decorate to authorize session. Do this on controller also
/// </summary>
[Authorize]
[Route("api/claims")]
[ApiController]
public class ClaismsApiController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Claim>> GetClaims()
    {
        var claims = User.Claims.Select(c => new
        {
            c.Type,
            c.Value
        }).ToList();

        return Ok(claims);
    }
}
