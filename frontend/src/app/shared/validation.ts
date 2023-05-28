import * as moment from "moment";

export default class ValidationError extends Error {
    public override name = 'ValidationError';

    public constructor() {
        super('Validation error.');
    }
}

export function assertArray(value: unknown): asserts value is unknown[] {
    if (!(value instanceof Array)) throw new ValidationError();
}

export function expectArray(value: unknown): unknown[] {
    assertArray(value);
    return value;
}

export type Plain = { [property: string]: unknown };

export function assertPlain(value: unknown): asserts value is Plain {
    if (typeof value !== 'object' || !value) throw new ValidationError();
}

export function expectPlain(value: unknown): Plain {
    assertPlain(value);
    return value;
}

export function expectPlainOrNull(value: unknown): Plain | null {
    return !value ? null : expectPlain(value);
}

export function assertString(value: unknown): asserts value is string {
    if (typeof value !== 'string') throw new ValidationError();
}

export function expectString(value: unknown): string {
    assertString(value);
    return value;
}

export function expectStringOrNull(value: unknown): string | null {
    return !value ? null : expectString(value);
}

export function assertBoolean(value: unknown): asserts value is boolean {
    if (typeof value !== 'boolean') throw new ValidationError();
}

export function expectBoolean(value: unknown): boolean {
    assertBoolean(value);
    return value;
}

export function expectBooleanOrNull(value: unknown): boolean | null {
    return !value ? null : expectBoolean(value);
}

export function assertNumber(value: unknown): asserts value is number {
    if (typeof value !== 'number') throw new ValidationError();
}

export function expectNumber(value: unknown): number {
    assertNumber(value);
    return value;
}

export function expectNumberOrNull(value: unknown): number | null {
    return !value ? null : expectNumber(value);
}

export function expectDate(value: unknown): Date {
    return validateDateString(expectString(value));
}

export function expectDateOrNull(value: unknown): Date | null {
    return !value ? null : validateDateString(expectString(value));
}

export function expectDateTime(value: unknown): Date {
    return validateDateTimeString(expectString(value));
}

export function expectDateTimeOrNull(value: unknown): Date | null {
    return !value ? null : validateDateTimeString(expectString(value));
}

export function validateDateTimeString(value: string): Date {
    const match = /^(\d{4,})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})(?:\.(\d{1,7}))?Z?$/.exec(value);
    if (match === null) {
        throw new ValidationError();
    }
    const year = Number(match[1]);
    const month = Number(match[2]);
    const day = Number(match[3]);
    const hours = Number(match[4]);
    const minutes = Number(match[5]);
    const seconds = Number(match[6]);
    const millis = ((m) => (m === undefined ? 0 : Number(m)))(match[7]);
    return new Date(Date.UTC(year, month - 1, day, hours, minutes, seconds, millis));
}

export function validateDateString(value: string): Date {
  const match = /^(\d{2,})-(\d{2})-(\d{4})$/.exec(value);
  if (match === null) {
      throw new ValidationError();
  }
  const day = Number(match[1]);
  const month = Number(match[2]);
  const year = Number(match[3]);

  return new Date(Date.UTC(year, month - 1, day));
}

export function parseDateToStringOrNull(date: Date | null): string | null {
  return !!date ? parseDateToString(date) : null;
}

export function parseDateToString(date: Date): string {
  return moment(date).format('DD-MM-YYYY')
}
