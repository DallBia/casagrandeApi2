import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'converterDiaSemanaParaPortugues'
})
export class ConverterDiaSemanaParaPortuguesPipe implements PipeTransform {
  diasEmPortugues: { [key: string]: string } = {
    Mon: 'SEG',
    Tue: 'TER',
    Wed: 'QUA',
    Thu: 'QUI',
    Fri: 'SEX',
    Sat: 'SÁB',
    Sun: 'DOM'
  };

  transform(value: string): string {
    return this.diasEmPortugues[value] || value;
  }
}
