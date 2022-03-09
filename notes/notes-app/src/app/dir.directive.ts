import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appDir]'
})
export class DirDirective {

  constructor(private el: ElementRef) { }
  
  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('violet');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor= color;
  }

}
