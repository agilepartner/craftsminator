using Craftsminator.Trips;
using Craftsminator.Users;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Craftsminator.Tests
{
    public class TripServiceTest
    {
        private Guid connectedUser;

        public TripServiceTest()
        {
            connectedUser = UsersForTests.Griffin;
            TripService.Connect(connectedUser);
        }

        [Fact]
        public async Task TestService()
        {
            var userDal = new UserRepository();
            User aFriendOfTheConnectedUser = null;
            userDal.TryGetUser(UsersForTests.Smith, out aFriendOfTheConnectedUser);
            var service = new TripService();

            var trips = await service.Trip(aFriendOfTheConnectedUser);

            trips.Should().HaveCount(1);
            trips.Single().Destination
                 .Should()
                 .Be("Dubrovnik");
        }
    }
}
