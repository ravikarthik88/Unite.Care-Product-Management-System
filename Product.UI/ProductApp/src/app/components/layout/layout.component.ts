import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MainHeaderComponent } from "./main-header/main-header.component";
import { MainFooterComponent } from "./main-footer/main-footer.component";

@Component({
    selector: 'app-layout',
    standalone: true,
    templateUrl: './layout.component.html',
    styles: ``,
    imports: [RouterOutlet, MainHeaderComponent, MainFooterComponent]
})
export class LayoutComponent {

}
