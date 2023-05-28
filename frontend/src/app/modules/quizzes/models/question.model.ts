import { assertPlain, expectArray, expectString } from "src/app/shared/validation";
import { Answer, validateAnswer } from "./answer.model";

export interface Question {
  id: string;
  description: string;
  answers: Answer[];
}

export function validateQuestion(value: any): Question {
  assertPlain(value);
  return {
      id: expectString(value["id"]),
      description: expectString(value["description"]),
      answers: expectArray(value["answers"]).map(validateAnswer)
  };
}
