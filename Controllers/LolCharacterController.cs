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
        return Ok(LolRequest.GetAll());
    }

    [HttpGet("search")]
    public ActionResult<List<LolStatistics>> Search(
        [FromQuery] string? name,
        [FromQuery] string? classType,
        [FromQuery] string? role,
        [FromQuery] string? tier,
        [FromQuery] double? scoreIsHigherThan,
        [FromQuery] double? scoreIsLowerThan,
        [FromQuery] double? trendIsHigherThan,
        [FromQuery] double? trendIsLowerThan,
        [FromQuery] double? winPercentageIsHigherThan,
        [FromQuery] double? winPercentageIsLowerThan,
        [FromQuery] double? rolePercentageIsHigherThan,
        [FromQuery] double? rolePercentageIsLowerThan,
        [FromQuery] double? pickPercentageIsHigherThan,
        [FromQuery] double? pickPercentageIsLowerThan,
        [FromQuery] double? banPercentageIsHigherThan,
        [FromQuery] double? banPercentageIsLowerThan,
        [FromQuery] double? kdaIsHigherThan,
        [FromQuery] double? kdaIsLowerThan,
        [FromQuery] string? sortProperty = "name",
        [FromQuery] SortOrder? sortOrder = SortOrder.ASC
    )
    {
        var result = new List<LolStatistics>();

        try
        {
            result = LolRequest.GetAll();
            LolRequest.GetByName(ref result, name);
            LolRequest.GetByClassType(ref result, classType);
            LolRequest.GetByRole(ref result, role);
            LolRequest.GetByTier(ref result, tier);
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