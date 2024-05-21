using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[ApiController]
[Authorize]
public abstract class ApiController : ControllerBase;
