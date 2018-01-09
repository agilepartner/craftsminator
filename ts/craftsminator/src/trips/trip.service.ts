import { Trip, TripRepository } from './';
import { User, UserRepository } from '../users';
import { List } from 'linqts';

export class TripService {
    private maximumNumberOfTheMinimumTrips = 3;
    public loggedUser: User;
    private tripRepository: TripRepository;

    constructor() {
        this.tripRepository = new TripRepository();
    }


    public async getTripsForUser(user: User): Promise<List<Trip>> {
        if (this.loggedUser == null) {
            throw new Error("User is not logged in");
        }

        if(!user.friends.Any(u => u.id == this.loggedUser.id)) {
            throw new Error("Users are not friends");
        }
        return await this.tripRepository.getTripsByUser(user);
    }

    public async connect(userId: string): Promise<void>
    {
        let user = await new UserRepository().getUser(userId);

        if (user)
        {
            this.loggedUser = user;
        }
    }        
}