using System.Threading.Tasks;
using MyPersonality.Quizzes.Api.Extensions;
using MyPersonality.Quizzes.Application.Services;
using MyPersonality.Infrastructure.FunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonality.Quizzes.Api.Controllers.Requests;

namespace MyPersonality.Quizzes.Api.Controllers;

[ApiController]
[Route("quizzes/v1/quizSubmissions")]
public sealed class QuizSubmissionsController : ControllerBase
{
    private readonly IQuizSubmissionsService _service;

    public QuizSubmissionsController(IQuizSubmissionsService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Create([FromBody] QuizSubmissionRequest quizSubmission)
    {
        var result = await _service.AddQuizSubmission(quizSubmission.ToQuizSubmission());
        return result.IsSuccess
            ? Created($"{Request.Path.Value}/{result.Value}", result.Value)
            : result.Error.ToHttpResponse();
    }
}