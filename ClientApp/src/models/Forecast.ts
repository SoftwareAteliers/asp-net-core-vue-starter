export class Forecast {
  constructor(
    public date: Date,
    public temperatureC: number,
    public temperatureF: number,
    public summary: string,
  ) {}
}
