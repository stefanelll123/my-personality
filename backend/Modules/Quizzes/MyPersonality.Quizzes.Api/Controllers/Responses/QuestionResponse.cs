using System;
using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record QuestionResponse(Guid Id, string Description, List<AnswerResponse> Answers);
