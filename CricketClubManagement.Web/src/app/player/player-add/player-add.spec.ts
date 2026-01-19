import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerAdd } from './player-add';

describe('PlayerAdd', () => {
  let component: PlayerAdd;
  let fixture: ComponentFixture<PlayerAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlayerAdd]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
