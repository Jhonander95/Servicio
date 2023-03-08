import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogClienteEditComponent } from './dialog-cliente-edit.component';

describe('DialogClienteEditComponent', () => {
  let component: DialogClienteEditComponent;
  let fixture: ComponentFixture<DialogClienteEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogClienteEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DialogClienteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
