using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith.Modules.Speakers.Api.Controllers;

[ApiController]
[Route(BasePath + "/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected const string BasePath = "speakers-module";
}