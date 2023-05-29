using INET410.Utils;
using Microsoft.AspNetCore.Mvc;

namespace INET410;

[ApiController]
[Route("api/overwatch2")]
public class OverwatchCharacterController : ControllerBase
{

    [HttpGet]
    public ActionResult<List<Overwatch2Statistics>> Get()
    {
        return Ok(OverwatchRequests.GetAll());
    }

    [HttpGet("search")]
    public ActionResult<List<Overwatch2Statistics>> Search(
        [FromQuery] string? hero,
        [FromQuery(Name = "heroIsNot")] string? heroIsNot,
        [FromQuery] string? skillTier,
        [FromQuery(Name = "skillTierIsNot")] string? skillTierNot,
        [FromQuery(Name = "kdaRatioIsHigherThan")] double? kdaRatioHigher,
        [FromQuery(Name = "kdaRatioIsLowerThan")] double? kdaRatioLower,
        [FromQuery(Name = "pickRatePercentageIsHigherThan")] double? pickRatePercentageHigher,
        [FromQuery(Name = "pickRatePercentageIsLowerThan")] double? pickRatePercentageLower,
        [FromQuery(Name = "winRatePercentageIsHigherThan")] double? winRatePercentageHigher,
        [FromQuery(Name = "winRatePercentageIsLowerThan")] double? winRatePercentageLower,
        [FromQuery(Name = "eliminationsPer10MinIsHigherThan")] double? eliminationsPer10MinHigher,
        [FromQuery(Name = "eliminationsPer10MinIsLowerThan")] double? eliminationsPer10MinLower,
        [FromQuery(Name = "objectiveKillsPer10MinIsHigherThan")] double? objectiveKillsPer10MinHigher,
        [FromQuery(Name = "objectiveKillsPer10MinIsLowerThan")] double? objectiveKillsPer10MinLower,
        [FromQuery(Name = "objectiveTimePer10MinIsHigherThan")] int? objectiveTimePer10MinHigher,
        [FromQuery(Name = "objectiveTimePer10MinIsLowerThan")] int? objectiveTimePer10MinLower,
        [FromQuery(Name = "damagePer10MinIsHigherThan")] int? damagePer10MinHigher,
        [FromQuery(Name = "damagePer10MinIsLowerThan")] int? damagePer10MinLower,
        [FromQuery(Name = "healingPer10MinIsHigherThan")] int? healingPer10MinHigher,
        [FromQuery(Name = "healingPer10MinIsLowerThan")] int? healingPer10MinLower,
        [FromQuery(Name = "deathsPer10MinIsHigherThan")] double? deathsPer10MinHigher,
        [FromQuery(Name = "deathsPer10MinIsLowerThan")] double? deathsPer10MinLower,
        [FromQuery] string sortBy = "hero",
        [FromQuery] SortOrder sortOrder = SortOrder.ASC
    )
    {

        var results = new List<Overwatch2Statistics>();

        try
        {
            if(hero != null && heroIsNot != null && hero == heroIsNot) throw new Exception("Cannot search for hero and heroIsNot at the same time");
            if(skillTier != null && skillTierNot != null && skillTier == skillTierNot) throw new Exception("Cannot search for skillTier and skillTierNot at the same time");

            results = OverwatchRequests.GetAll();
            OverwatchRequests.GetByHero(ref results, hero);
            OverwatchRequests.GetByHero(ref results, heroIsNot, true);
            OverwatchRequests.GetBySkillTier(ref results, skillTier);
            OverwatchRequests.GetBySkillTier(ref results, skillTierNot, true);

            OverwatchRequests.GetByKdaRatio(ref results, kdaRatioHigher, kdaRatioLower);
            OverwatchRequests.GetByPickRatePercentage(ref results, pickRatePercentageHigher, pickRatePercentageLower);
            OverwatchRequests.GetByWinRatePercentage(ref results, winRatePercentageHigher, winRatePercentageLower);
            OverwatchRequests.GetByEliminationsPer10Min(ref results, eliminationsPer10MinHigher, eliminationsPer10MinLower);
            OverwatchRequests.GetByObjectiveKillsPer10Min(ref results, objectiveKillsPer10MinHigher, objectiveKillsPer10MinLower);
            OverwatchRequests.GetByObjectiveTimePer10Min(ref results, objectiveTimePer10MinHigher, objectiveTimePer10MinLower);
            OverwatchRequests.GetByDamagePer10Min(ref results, damagePer10MinHigher, damagePer10MinLower);
            OverwatchRequests.GetByHealingPer10Min(ref results, healingPer10MinHigher, healingPer10MinLower);
            OverwatchRequests.GetByDeathsPer10Min(ref results, deathsPer10MinHigher, deathsPer10MinLower);
            OverwatchRequests.Order(ref results, sortOrder, sortBy);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(results);
    }
}