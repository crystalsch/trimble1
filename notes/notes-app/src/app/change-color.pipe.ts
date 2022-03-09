import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'changeColor'
})
export class ChangeColorPipe implements PipeTransform {

  transform(inter: string): string {
    return (inter) ? '-' + inter + '-' : inter;
  }

}
