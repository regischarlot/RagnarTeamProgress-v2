import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNavigationWidgetComponent } from './side-navigation-widget.component';

describe('SideNavigationWidgetComponent', () => {
  let component: SideNavigationWidgetComponent;
  let fixture: ComponentFixture<SideNavigationWidgetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SideNavigationWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNavigationWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
