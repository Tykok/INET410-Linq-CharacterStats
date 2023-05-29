using INET410.Utils;
using Microsoft.AspNetCore.Mvc;

namespace INET410;

[ApiController]
[Route("api/leagueoflegends")]
public class LolStatsController : ControllerBase
{

    [HttpGet]
    public ActionResult<List<LolStatistics>> Get()
    {
        return Ok(LolRequest.GetCharacters());
    }

    [HttpGet("search")]
    public ActionResult<List<LolStatistics>> Search(
        [FromQuery] string? name = null,
        [FromQuery] string? nameIsNot = null,
        [FromQuery] string? classType = null,
        [FromQuery] string? classTypeIsNot = null,
        [FromQuery] string? role = null,
        [FromQuery] string? roleIsNot = null,
        [FromQuery] string? tier = null,
        [FromQuery] string? tierIsNot = null,
        [FromQuery] double? scoreIsHigherThan = null,
        [FromQuery] double? scoreIsLowerThan = null,
        [FromQuery] double? trendIsHigherThan = null,
        [FromQuery] double? trendIsLowerThan = null,
        [FromQuery] double? winPercentageIsHigherThan = null,
        [FromQuery] double? winPercentageIsLowerThan = null,
        [FromQuery] double? rolePercentageIsHigherThan = null,
        [FromQuery] double? rolePercentageIsLowerThan = null,
        [FromQuery] double? pickPercentageIsHigherThan = null,
        [FromQuery] double? pickPercentageIsLowerThan = null,
        [FromQuery] double? banPercentageIsHigherThan = null,
        [FromQuery] double? banPercentageIsLowerThan = null,
        [FromQuery] double? kdaIsHigherThan = null,
        [FromQuery] double? kdaIsLowerThan = null,
        [FromQuery] string? sortProperty = "name",
        [FromQuery] SortOrder? sortOrder = SortOrder.ASC
    )
    {
        var result = new List<LolStatistics>();

        try
        {
            if(name != null && nameIsNot != null && name == nameIsNot) throw new Exception("Cannot have both name and nameIsNot.");
            if(classType != null && classTypeIsNot != null && classType == classTypeIsNot) throw new Exception("Cannot have both classType and classTypeIsNot.");
            if(role != null && roleIsNot != null && role == roleIsNot) throw new Exception("Cannot have both role and roleIsNot.");
            if(tier != null && tierIsNot != null && tier == tierIsNot) throw new Exception("Cannot have both tier and tierIsNot.");

            result = LolRequest.GetCharacters();
            LolRequest.GetByName(ref result, name);
            LolRequest.GetByName(ref result, nameIsNot, true);
            LolRequest.GetByClassType(ref result, classType);
            LolRequest.GetByClassType(ref result, classTypeIsNot, true);
            LolRequest.GetByRole(ref result, role);
            LolRequest.GetByRole(ref result, roleIsNot, true);
            LolRequest.GetByTier(ref result, tier);
            LolRequest.GetByTier(ref result, tierIsNot, true);
            LolRequest.GetByScore(ref result, scoreIsHigherThan, scoreIsLowerThan);
            LolRequest.GetByTrend(ref result, trendIsHigherThan, trendIsLowerThan);
            LolRequest.GetByWinPercentage(ref result, winPercentageIsHigherThan, winPercentageIsLowerThan);
            LolRequest.GetByRolePercentage(ref result, rolePercentageIsHigherThan, rolePercentageIsLowerThan);
            LolRequest.GetByPickPercentage(ref result, pickPercentageIsHigherThan, pickPercentageIsLowerThan);
            LolRequest.GetByBanPercentage(ref result, banPercentageIsHigherThan, banPercentageIsLowerThan);
            LolRequest.GetByKdaRatio(ref result, kdaIsHigherThan, kdaIsLowerThan);
            LolRequest.Order(ref result, sortOrder ?? SortOrder.ASC, sortProperty ?? "name");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(result);
    }
}