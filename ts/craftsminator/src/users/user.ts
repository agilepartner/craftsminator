import { Trip } from '../trips';
import { List } from 'linqts';

export class User {
    public trips: List<Trip>;
    public friends: List<User>;

    public id: string;
    public firstName: string;
    public lastName: string;

    constructor(id: string,
                lastName: string,
                firstName: string) {
        this.trips = new List<Trip>();
        this.friends = new List<User>();
        this.id = id;
        this.lastName = lastName;
        this.firstName = firstName;
    }

    public addFriend(user: User): void
    {
        this.friends.Add(user);
    }

    public addTrip(trip: Trip): void
    {
        this.trips.Add(trip);
    }

    public setTrips(newTrips: List<Trip>)
    {
        this.trips = newTrips;
    }
}