import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-side-navigation-widget',
  templateUrl: './side-navigation-widget.component.html',
  styleUrls: ['./side-navigation-widget.component.scss']
})

export class SideNavigationWidgetComponent implements OnInit {
  
  public menuState: boolean;

  constructor() { }

  ngOnInit() {
    this.menuState = false;
  }
}
