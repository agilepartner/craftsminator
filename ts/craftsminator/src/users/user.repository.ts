import { User } from '../users';
import { List } from 'linqts';

export class UserRepository {
    private users: List<User>;

    constructor() {
        this.users = new List<User>();
        
        var simpson = new User('6690DEB8-B5C6-46AB-A597-229F2608695B', 'Simpson', 'Homer');
        var griffin = new User('279FE4CE-5355-4C7F-ACDF-D69B017ABD87', 'Griffin', 'Peter');
        var smith = new User('2284247F-7F72-41A1-B892-4D84CB53D9E7', 'Smith', 'Stan');

        simpson.addFriend(smith);
        simpson.addFriend(griffin);
        griffin.addFriend(simpson);
        griffin.addFriend(smith);
        smith.addFriend(simpson);
        smith.addFriend(griffin);

        this.users.Add(simpson);
        this.users.Add(griffin);
        this.users.Add(smith);
    }

    public async getUser(userId: string): Promise<User> {
        return new Promise<User>((resolve, reject) => {
            let foundUser = this.users.SingleOrDefault(u => u.id == userId);

            if(foundUser){
                resolve(foundUser);
            }
            else {
                reject('No user found for the given id');
            }
        });
    }
}