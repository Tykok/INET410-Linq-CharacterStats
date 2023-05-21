using System.Net;
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
        string? name = null,
        string? classType = null,
        Role? role = null,
        string? tier = null,
        double? score = null,
        double? trend = null,
        double? winPercentage = null,
        double? rolePercentage = null,
        double? pickPercentage = null,
        double? banPercentage = null,
        double? kda = null
    )
    {
        return Ok(LolRequest.Search(name, classType, role, tier, score, trend, winPercentage, rolePercentage, pickPercentage, banPercentage, kda));
    }
    

}