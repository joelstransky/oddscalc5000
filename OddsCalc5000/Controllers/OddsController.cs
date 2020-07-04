using System;
using BreakEvenCalculator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OddsCalc5000.Controllers
{
    [Route("api/v1/[controller]")]
    public class OddsController : Controller
    {
        private AmericanOdds amOdds;
        // POST api/v1/<Odds>
        [HttpPost]
        public string Post([FromBody] Odds odds)
        {
            Object res = new object();

            if (AmericanOdds.IsValid(odds.odds_input))
            {
                amOdds = new AmericanOdds(odds.odds_input);
                res = new { status = "success", data = amOdds.GetBreakEvenPercentage() };

            }
            else
            {
                res = new { status = "fail", data = "Invalid Format" };
            }
            return JsonConvert.SerializeObject(res);
        }
    }
}
