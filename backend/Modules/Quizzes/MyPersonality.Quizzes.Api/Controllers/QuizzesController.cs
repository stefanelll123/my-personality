using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MyPersonality.Quizzes.Api.Controllers.Responses;
using MyPersonality.Quizzes.Api.Extensions;
using MyPersonality.Quizzes.Application.Services;
using MyPersonality.Infrastructure.FunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyPersonality.Infrastructure.Authorization;
using MyPersonality.Quizzes.Api.Controllers.Requests;
using MyPersonality.Quizzes.Domain.Aggregates;

namespace MyPersonality.Quizzes.Api.Controllers;

[ApiController]
[Route("quizzes/v1/quizzes")]
public sealed class QuizzesController : ControllerBase
{
    private readonly IQuizzesService _service;
    private readonly IMapper _mapper;

    public QuizzesController(IQuizzesService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QuizResponse[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetQuizzes();
        return result.IsSuccess ? Ok(result.Value.ToQuizResponses()) : Ok(new List<QuizResponse>());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(QuizResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetQuiz(id);
        return result.IsSuccess ? 
            Ok(result.Value.ToQuizResponse())
            : result.Error.ToHttpResponse();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(Policy = AuthorizationConstants.IsAuthorizedPolicy)]
    public async Task<IActionResult> Create([FromBody] QuizRequest quiz)
    {
        var result = await _service.AddQuiz(quiz.ToQuiz());
        return result.IsSuccess
            ? Created($"{Request.Path.Value}/{result.Value}", null)
            : result.Error.ToHttpResponse();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(Policy = AuthorizationConstants.IsAuthorizedPolicy)]
    public async Task<IActionResult> Remove(Guid id)
    {
        var result = await _service.RemoveQuiz(id);
        return result.IsSuccess
            ? NoContent()
            : result.Error.ToHttpResponse();
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(Policy = AuthorizationConstants.IsAuthorizedPolicy)]
    public async Task<IActionResult> Update(Guid id, [FromBody] JsonPatchDocument<QuizUpdateRequest> patchDocument)
    {
        // TODO: implement a custom mechanism for json patch,in order to validate the operations
        // and to ensure that invalid operations as update id are not allowed
        var quizPatchDocument = _mapper.Map<JsonPatchDocument<Quiz>>(patchDocument);
        var result = await _service.UpdateQuiz(id, quizPatchDocument);

        return result.IsSuccess
            ? Ok(result.Value)
            : result.Error.ToHttpResponse();
    }

    [HttpGet("{id:guid}/{submissionId:guid}/placement")]
    [ProducesResponseType(typeof(QuizSubmissionPlacementResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPlacement(Guid id, Guid submissionId)
    {
        var result = await _service.GetPlacement(id, submissionId);
        return result.IsSuccess ? Ok(new QuizSubmissionPlacementResponse(result.Value)) : result.Error.ToHttpResponse();
    }
}