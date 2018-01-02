using System;
using System.Collections.Generic;
using System.Linq;

namespace Craftsminator.Users
{
    public class UserRepository
    {
        private readonly List<User> users;

        public UserRepository()
        {
            users = new List<User>();

            var simpson = new User(Guid.Parse("6690DEB8-B5C6-46AB-A597-229F2608695B"), "Simpson", "Homer");
            var griffin = new User(Guid.Parse("279FE4CE-5355-4C7F-ACDF-D69B017ABD87"), "Griffin", "Peter");
            var smith = new User(Guid.Parse("2284247F-7F72-41A1-B892-4D84CB53D9E7"), "Smith", "Stan");

            simpson.AddFriend(smith);
            simpson.AddFriend(griffin);
            griffin.AddFriend(simpson);
            griffin.AddFriend(smith);
            smith.AddFriend(simpson);
            smith.AddFriend(griffin);

            users.Add(simpson);
            users.Add(griffin);
            users.Add(smith);
        }

        public bool TryGetUser(Guid userId, out User user)
        {
            user = users.SingleOrDefault(u => u.Id == userId);
            return user != null;
        }
    }
}