import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountDetailsListComponent } from './account-details-list.component';

describe('AccountDetailsListComponent', () => {
  let component: AccountDetailsListComponent;
  let fixture: ComponentFixture<AccountDetailsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountDetailsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountDetailsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
