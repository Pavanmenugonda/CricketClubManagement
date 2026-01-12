import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerList } from './player-list';
import { HttpClient } from '@angular/common/http';


describe('PlayerList', () => {
  let component: PlayerList;
  let fixture: ComponentFixture<PlayerList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlayerList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
