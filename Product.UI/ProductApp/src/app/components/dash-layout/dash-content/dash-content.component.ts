import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DashTopbarComponent } from "../dash-topbar/dash-topbar.component";
import { DashFooterComponent } from "../dash-footer/dash-footer.component";

@Component({
    selector: 'app-dash-content',
    standalone: true,
    templateUrl: './dash-content.component.html',
    styles: ``,
    imports: [RouterOutlet, DashTopbarComponent, DashFooterComponent]
})
export class DashContentComponent {

}
