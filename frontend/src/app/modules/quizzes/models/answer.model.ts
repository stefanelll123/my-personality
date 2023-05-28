import { assertPlain, expectNumber, expectString } from "src/app/shared/validation";

export interface Answer {
  id: string;
  description: string;
  numberOfPoints: number;
}

export function validateAnswer(value: any): Answer {
  assertPlain(value);
  return {
      id: expectString(value["id"]),
      description: expectString(value["description"]),
      numberOfPoints: expectNumber(value["numberOfPoints"])
  };
}
