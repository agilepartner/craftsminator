import { Trip } from './trip';
import { User } from '../users';
import { List } from 'linqts';

export class TripRepository {
    private tripsByUserId: Map<string, List<Trip>>;

    constructor() {
        this.tripsByUserId = new Map<string, List<Trip>>();
        this.tripsByUserId.set('6690DEB8-B5C6-46AB-A597-229F2608695B', new List([new Trip('Hawaï', 25), new Trip('Paris', 10), new Trip('Fort-de-France', 20)]));
        this.tripsByUserId.set('279FE4CE-5355-4C7F-ACDF-D69B017ABD87', new List([new Trip('Toronto', 12), new Trip('London', 10), new Trip('Acapulco', 20),  new Trip('Lima', 98)]));
        this.tripsByUserId.set('2284247F-7F72-41A1-B892-4D84CB53D9E7', new List([new Trip('Dubrovnik', 59)]));
    }
        
    // CQR
    public async getTripsByUser(user: User): Promise<List<Trip>>
    {
        return new Promise<List<Trip>>((resolve, reject) => {
            var trips = this.tripsByUserId.get(user.id);
            user.setTrips(trips);

            resolve(trips);
        });
    }
}