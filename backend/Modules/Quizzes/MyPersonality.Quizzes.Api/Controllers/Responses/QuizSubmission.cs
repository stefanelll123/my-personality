using System;
using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record QuizSubmission(Guid Id, Guid QuizId, List<AnswerSubmissionResponse> AnswerSubmissions);
