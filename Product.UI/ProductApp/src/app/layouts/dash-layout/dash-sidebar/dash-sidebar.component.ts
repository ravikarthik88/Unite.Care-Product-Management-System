import { Component, OnInit } from '@angular/core';
import $ from 'jquery';
@Component({
  selector: 'app-dash-sidebar',
  templateUrl: './dash-sidebar.component.html',
  styles: ``
})
export class DashSidebarComponent implements OnInit{
  ngOnInit(): void {
    $("#sidebarToggle, #sidebarToggleTop").on('click', function(e) {
      $("body").toggleClass("sidebar-toggled");
      $(".sidebar").toggleClass("toggled");
      if ($(".sidebar").hasClass("toggled")) {
        $('.sidebar .collapse').addClass('hide');
      };
    });
  }
}
