import { TripService } from './';
import { expect, assert } from 'chai';
import 'mocha';
import { UsersForTests, UserRepository } from '../users';
import { List } from 'linqts';

describe('Get trips', () => {

  it('should return a list of trips for the given user', async () => {
    let service = new TripService();
    service.connect(UsersForTests.Griffin);

    let userRepository = new UserRepository();
    let aFriendOfTheConnectedUser = await userRepository.getUser(UsersForTests.Smith);

    let result = await service.trip(aFriendOfTheConnectedUser);
    assert.isNotEmpty(result);
    assert.equal(result.Single().destination, 'Dubrovnik');
  });
});