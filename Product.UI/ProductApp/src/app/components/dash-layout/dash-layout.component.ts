import { Component } from '@angular/core';
import { DashSidebarComponent } from "./dash-sidebar/dash-sidebar.component";
import { DashContentComponent } from "./dash-content/dash-content.component";

@Component({
    selector: 'app-dash-layout',
    standalone: true,
    templateUrl: './dash-layout.component.html',
    styles: ``,
    imports: [DashSidebarComponent, DashContentComponent]
})
export class DashLayoutComponent {

}
