import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUserObjectComponent } from './create-user-object.component';

describe('CreateUserObjectComponent', () => {
  let component: CreateUserObjectComponent;
  let fixture: ComponentFixture<CreateUserObjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateUserObjectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateUserObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
