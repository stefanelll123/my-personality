import { assertPlain, expectString } from "src/app/shared/validation";

export interface QuizSubmissionPlacement {
  value: string;
}

export function validateQuizSubmissionPlacement(value: any): QuizSubmissionPlacement {
  assertPlain(value);
  return {
    value: expectString(value["value"])
  };
}
