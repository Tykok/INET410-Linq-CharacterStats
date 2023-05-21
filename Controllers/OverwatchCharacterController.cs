using Microsoft.AspNetCore.Mvc;
using INET410.Entity;
using INET410.Request;

namespace INET410;


[ApiController]
[Route("api/overwatch2")]
public class OverwatchCharacterController: ControllerBase
{

    [HttpGet]
    public ActionResult<List<Overwatch2Statistics>> Get() => Ok(OverwatchRequests.GetAll());

    [HttpGet("search")]
    public ActionResult<List<Overwatch2Statistics>> Search(
        [FromQuery] string? hero,
        [FromQuery] string? skillTier,
        [FromQuery] double? kdaRatio,
        [FromQuery] double? pickRatePercentage,
        [FromQuery] double? winRatePercentage,
        [FromQuery] double? eliminationsPer10min,
        [FromQuery] double? objectiveKillsPer10min,
        [FromQuery] int? objectiveTimePer10min,
        [FromQuery] int? damagePer10min,
        [FromQuery] int? healingPer10min,
        [FromQuery] double? deathsPer10min
    )
    {
        var results = OverwatchRequests.Search(
            hero,
            skillTier,
            kdaRatio,
            pickRatePercentage,
            winRatePercentage,
            eliminationsPer10min,
            objectiveKillsPer10min,
            objectiveTimePer10min,
            damagePer10min,
            healingPer10min,
            deathsPer10min
        );
        return Ok(results);
    }

}