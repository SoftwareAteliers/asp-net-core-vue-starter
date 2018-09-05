export class Forecast {
  constructor(
    public dateFormatted: Date,
    public temperatureC: number,
    public temperatureF: number,
    public summary: string,
  ) {}
}
