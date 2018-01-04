using Craftsminator.Exceptions;
using Craftsminator.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Craftsminator.Trips
{
    public sealed class TripService
    {
        private const short maximumNumberOfTheMinimumTrips = 3;

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

            Trip[] list = await TripRepository.GetTripsByUser(user);

            // DO NOT TOUCH  !!! Added to save the project on the demand of the PO
            return list.Count() < maximumNumberOfTheMinimumTrips ? list : new Trip[0];
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