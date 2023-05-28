using System;
using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Requests;

public record QuizSubmissionRequest(Guid QuizId, List<AnswerSubmissionRequest> AnswerSubmissions);

public record AnswerSubmissionRequest(Guid QuestionId, Guid AnswerId);