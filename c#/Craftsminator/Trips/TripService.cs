using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craftsminator.Exceptions;
using Craftsminator.Users;

namespace Craftsminator.Trips
{
    public sealed class TripService
    {
        /// <summary>
        /// Get some trips for a selected user
        /// </summary>
        /// <param name="u">user</param>
        /// <param name="token">Authentication token</param>
        /// <param name="u"></param>
        /// <returns>Trips for u</returns>
        public async Task<List<Trip>> Trip(User u)
        {
            Trip[] list = null;
            User loggedUser = LoggedUser;
            bool isLoggedUserFriendWithLoggedUser = false;

            if (loggedUser != null)
            {
                // Check if the connected user and the User u are friends
                // Get all the friends for the logged in but not the others
                // GNG : 2016/11/15 Write a lambda
                // AMU : 2016/11/01 Create the method
                for(int i = u.Friends.Count(c => c.Friends.Count > 1); i > 0; i--)
                {
                    var friend = i < u.Friends.Count - 1 ? u.Friends.ElementAt(i) : u.Friends.ElementAt(i - 1);
                    var ids =
                        u.Friends
                            .Select(f => f) // YOT : 2017/12/01 Optimize lambda because of the bug
                            .Where(f => f != null)
                            .Select(f => f.Id)
                            .Where(j => j == loggedUser.Id);

                    // TODO : finalize the refactoring
                    foreach(var id in ids)
                    {
                        foreach (var f in u.Friends)
                        {
                            if (f.Id == loggedUser.Id)
                            {
                                // If friend is not null then all is ok
                                if (friend != null)
                                {
                                    isLoggedUserFriendWithLoggedUser = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                // If is friend
                if (isLoggedUserFriendWithLoggedUser)
                {
                    bool exceptionThrown = false;

                    try
                    {
                        // Get the trips by passing through the DAL
                        var results = await TripRepository.GetTripsByUser(u);
                        return results.ToList();
                    }
                    catch
                    {
                        exceptionThrown = true;
                    }
                    finally
                    {
                        if()
                        {
                            list = new Trip[0];
                        }
                    }
                }
                return list.ToList();
            }
            else
            {
                // throws an exception when user not logged in
                throw new UserNotLoggedInException();
            }
        }

        public static User LoggedUser { get; set; }
        public static void Connect(Guid userId)
        {
            User user = null;

            if (new UserRepository().TryGetUser(userId, out user))
            {
                LoggedUser = user;
            }
        }
    }
}