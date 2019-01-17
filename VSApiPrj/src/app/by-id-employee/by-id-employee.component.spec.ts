import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ByIdEmployeeComponent } from './by-id-employee.component';

describe('ByIdEmployeeComponent', () => {
  let component: ByIdEmployeeComponent;
  let fixture: ComponentFixture<ByIdEmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ByIdEmployeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ByIdEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
