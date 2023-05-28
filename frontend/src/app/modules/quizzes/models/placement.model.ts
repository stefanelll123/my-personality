import { assertPlain, expectNumber, expectString } from "src/app/shared/validation";

export interface Placement {
  id: string;
  description: string;
  minScore: number;
  maxScore: number;
}

export function validatePlacement(value: any): Placement {
  assertPlain(value);
  return {
      id: expectString(value["id"]),
      description: expectString(value["description"]),
      minScore: expectNumber(value["minScore"]),
      maxScore: expectNumber(value["maxScore"]),
  };
}
