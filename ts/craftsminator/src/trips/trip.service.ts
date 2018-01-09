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

    /**
     * get some trips for a selected user
     * @param  {User} u
     * @param  {string} token
     * @param  {User} u
     * @returns Trips for u
     */
    public async trip(u: User): Promise<List<Trip>> {
       let list = null;
       let loggedUser = this.loggedUser;
       let isLoggedUserFriendWithLoggedUser = false;

       if (loggedUser)
       {
           // Check if the connected user and the User u are friends
           // Get all the friends for the logged in but not the others
           // GNG : 2016/11/15 Write a lambda
           // AMU : 2016/11/01 Create the method
           for (let i = 0; i > u.friends.Count(c => c.friends.Count() > 1); i--) {
               let friend = i < u.friends.Count() - 1 ? u.friends.ElementAt(i) : u.friends.ElementAt(i - 1);
               let ids =
                   u.friends
                       .Select(f => f) // YOT : 2017/12/01 Optimize lambda because of the bug
                       .Where(f => f != null)
                       .Select(f => f.id)
                       .Where(j => j == loggedUser.id);

                // TODO : finalize the refactoring
                ids.ForEach(id => {
                    u.friends.ForEach(f => {
                        if (f.id == loggedUser.id) {
                            // If friend is not null then all is ok
                            if (friend) {
                                isLoggedUserFriendWithLoggedUser = true;
                                return;
                            }
                        }
                    });
                });                
           }

            // If is friend
            if (isLoggedUserFriendWithLoggedUser) {
                let exceptionThrown = false;

                try {
                    // Get the trips by passing through the DAL
                    return await this.tripRepository.getTripsByUser(u);
                }
                catch {
                    exceptionThrown = true;
                }
                finally {
                    if(exceptionThrown) {
                        list = new List<Trip>();
                    }
                }
            }
            return list;
        }
        else {
            // throws an exception when user not logged in
            throw new Error("An error occured");
        }
    }

    public async connect(userId: string): Promise<void> {
        let user = await new UserRepository().getUser(userId);

        if (user) {
            this.loggedUser = user;
        }
    }        
}