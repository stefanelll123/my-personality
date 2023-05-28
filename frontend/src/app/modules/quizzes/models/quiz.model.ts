import { assertPlain, expectArray, expectString } from "src/app/shared/validation";
import { Placement, validatePlacement } from "./placement.model";
import { Question, validateQuestion } from "./question.model";

export interface Quiz {
  id: string;
  title: string;
  description: string;
  questions: Question[];
  placements: Placement[];
}

export function validateQuiz(value: any): Quiz {
  assertPlain(value);
  return {
      id: expectString(value["id"]),
      title: expectString(value["title"]),
      description: expectString(value["description"]),
      questions: expectArray(value["questions"]).map(validateQuestion),
      placements: expectArray(value["placements"]).map(validatePlacement)
  };
}
