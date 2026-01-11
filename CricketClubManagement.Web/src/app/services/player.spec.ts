import { Player } from './player.model';

describe('Player model', () => {
  it('should create a valid player object', () => {
    const player: Player = {
      playerId: 1,
      playerName: 'Virat Kohli',
      playerAge: 35,
      roleId: 1
    };

    expect(player.playerName).toBe('Virat Kohli');
    expect(player.playerAge).toBeGreaterThan(0);
  });
});
