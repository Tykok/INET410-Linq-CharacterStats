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
        [FromQuery(Name = "kdaRatioIsLessThan")] double? kdaRatioLess,
        [FromQuery(Name = "pickRatePercentageIsHigherThan")] double? pickRatePercentageHigher,
        [FromQuery(Name = "pickRatePercentageIsLessThan")] double? pickRatePercentageLess,
        [FromQuery(Name = "winRatePercentageIsHigherThan")] double? winRatePercentageHigher,
        [FromQuery(Name = "winRatePercentageIsLessThan")] double? winRatePercentageLess,
        [FromQuery(Name = "eliminationsPer10MinIsHigherThan")] double? eliminationsPer10MinHigher,
        [FromQuery(Name = "eliminationsPer10MinIsLessThan")] double? eliminationsPer10MinLess,
        [FromQuery(Name = "objectiveKillsPer10MinIsHigherThan")] double? objectiveKillsPer10MinHigher,
        [FromQuery(Name = "objectiveKillsPer10MinIsLessThan")] double? objectiveKillsPer10MinLess,
        [FromQuery(Name = "objectiveTimePer10MinIsHigherThan")] int? objectiveTimePer10MinHigher,
        [FromQuery(Name = "objectiveTimePer10MinIsLessThan")] int? objectiveTimePer10MinLess,
        [FromQuery(Name = "damagePer10MinIsHigherThan")] int? damagePer10MinHigher,
        [FromQuery(Name = "damagePer10MinIsLessThan")] int? damagePer10MinLess,
        [FromQuery(Name = "healingPer10MinIsHigherThan")] int? healingPer10MinHigher,
        [FromQuery(Name = "healingPer10MinIsLessThan")] int? healingPer10MinLess,
        [FromQuery(Name = "deathsPer10MinIsHigherThan")] double? deathsPer10MinHigher,
        [FromQuery(Name = "deathsPer10MinIsLessThan")] double? deathsPer10MinessL,
        [FromQuery] string sortBy = "hero",
        [FromQuery] SortOrder sortOrder = SortOrder.ASC
    )
    {

        var results = new List<Overwatch2Statistics>();

        try
        {
            if(hero != null && heroIsNot != null) throw new Exception("Cannot search for hero and heroIsNot at the same time");
            if(skillTier != null && skillTierNot != null) throw new Exception("Cannot search for skillTier and skillTierNot at the same time");

            results = OverwatchRequests.GetAll();
            if(hero != null) OverwatchRequests.GetByHero(ref results, hero);
            if(heroIsNot != null) OverwatchRequests.GetByHero(ref results, heroIsNot, true);
            if(skillTier != null) OverwatchRequests.GetBySkillTier(ref results, skillTier);
            if(skillTierNot != null) OverwatchRequests.GetBySkillTier(ref results, skillTierNot, true);

            OverwatchRequests.GetByKdaRatio(ref results, kdaRatioHigher, kdaRatioLess);
            OverwatchRequests.GetByPickRatePercentage(ref results, pickRatePercentageHigher, pickRatePercentageLess);
            OverwatchRequests.GetByWinRatePercentage(ref results, winRatePercentageHigher, winRatePercentageLess);
            OverwatchRequests.GetByEliminationsPer10Min(ref results, eliminationsPer10MinHigher, eliminationsPer10MinLess);
            OverwatchRequests.GetByObjectiveKillsPer10Min(ref results, objectiveKillsPer10MinHigher, objectiveKillsPer10MinLess);
            OverwatchRequests.GetByObjectiveTimePer10Min(ref results, objectiveTimePer10MinHigher, objectiveTimePer10MinLess);
            OverwatchRequests.GetByDamagePer10Min(ref results, damagePer10MinHigher, damagePer10MinLess);
            OverwatchRequests.GetByHealingPer10Min(ref results, healingPer10MinHigher, healingPer10MinLess);
            OverwatchRequests.GetByDeathsPer10Min(ref results, deathsPer10MinHigher, deathsPer10MinessL);
            OverwatchRequests.Sort(ref results, sortOrder, sortBy);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(results);
    }
}