import { assertPlain, expectArray, expectString } from "src/app/shared/validation";
import { AnswerSubmission, validateAnswerSubmission } from "./answer-submission.model";

export interface QuizSubmission {
  quizId: string;
  answerSubmissions: AnswerSubmission[];
}

export function validateQuizSubmission(value: any): QuizSubmission {
  assertPlain(value);
  return {
      quizId: expectString(value["id"]),
      answerSubmissions: expectArray(value["answerSubmissions"]).map(validateAnswerSubmission)
  };
}
