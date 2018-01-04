using Craftsminator.Exceptions;
using Craftsminator.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Craftsminator.Trips
{
    public sealed class TripService
    {
        public async Task<Trip[]> GetTripsForUser(User user)
        {
            if (LoggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            if(!user.Friends.Any(u => u.Id == LoggedUser.Id))
            {
                throw new UserNotFriendsException();
            }
            return await TripRepository.GetTripsByUser(user);
        }

        public static User LoggedUser { get; private set; }
        
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