using Microsoft.AspNetCore.Mvc;
using NatrolitePlacesWebApi.Models;

namespace NatrolitePlacesWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class Test2Controller : ControllerBase
{
    private readonly ILogger<Test2Controller> _logger;
    private readonly Random _random;

    public Test2Controller(ILogger<Test2Controller> logger, Random random)
    {
        _logger = logger;
        _random = random;
    }

    [Produces("application/json")]
    [HttpGet(nameof(GetTherapy))]
    public async Task<ActionResult<TherapyAnswer>> GetTherapy()
    {
        await Task.Delay(_random.Next(1000));

        var therapyAnswers = new List<string>()
        {
            "Aha, I see...",
            "This is not important.",
            "That's awful!",
            "Not my problem.",
            "Try to do it differently.",
            "Ok.",
            "No.",
            "That's the spirit."
        };

        var therapyAnswer = new TherapyAnswer()
        {
            Answer = therapyAnswers[_random.Next(therapyAnswers.Count())]
        };
        return Ok(therapyAnswer);
    }
}
