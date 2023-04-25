using Microsoft.AspNetCore.Mvc;
using INET410.Entity;
using INET410.Request;

namespace INET410;


[ApiController]
[Route("[controller]")]
public class OverwatchCharacterController
{
    [HttpGet(Name = "GetOverwatchCharacter")]
    public IEnumerable<Overwatch2Statistics> Get()
    {
        return OverwatchRequests.GetAll();
    }
}