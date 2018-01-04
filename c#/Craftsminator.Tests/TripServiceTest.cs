using Craftsminator.Trips;
using Craftsminator.Users;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Craftsminator.Tests
{
    public class TripServiceTest
    {
        private readonly Guid connectedUser;
        private readonly ITestOutputHelper output;

        public TripServiceTest(ITestOutputHelper output)
        {
            this.output = output;
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

            var trips = await service.GetTripsForUser(aFriendOfTheConnectedUser);

            trips.Should().HaveCount(1);
            trips.Single().Destination
                 .Should()
                 .Be("Dubrovnik");

            #region 
            output.WriteLine("Carte 54");
            #endregion
        }
    }
}
