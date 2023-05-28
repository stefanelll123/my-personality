import { assertPlain, expectString } from "src/app/shared/validation";

export interface AnswerSubmission {
  questionId: string;
  answerId: string;
}

export function validateAnswerSubmission(value: any): AnswerSubmission {
  assertPlain(value);
  return {
    questionId: expectString(value["questionId"]),
    answerId: expectString(value["answerId"])
  };
}
