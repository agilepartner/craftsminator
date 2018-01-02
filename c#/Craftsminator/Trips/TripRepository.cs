using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Craftsminator.Users;

namespace Craftsminator.Trips
{
    public static class TripRepository
    {
        private static IDictionary<Guid, Trip[]> tripsByUserId =
            new Dictionary<Guid, Trip[]>
            {
                {
                    Guid.Parse("6690DEB8-B5C6-46AB-A597-229F2608695B"),
                    new Trip[]
                    {
                        new Trip { Destination = "Hawaï", Duration = TimeSpan.FromDays(25) },
                        new Trip { Destination = "Paris", Duration = TimeSpan.FromDays(10) },
                        new Trip { Destination = "Fort-de-France", Duration = TimeSpan.FromDays(20) }
                    }
                },
                {
                    Guid.Parse("279FE4CE-5355-4C7F-ACDF-D69B017ABD87"),
                    new Trip[]
                    {
                        new Trip { Destination = "Toronto", Duration = TimeSpan.FromDays(12) },
                        new Trip { Destination = "London", Duration = TimeSpan.FromDays(10) },
                        new Trip { Destination = "Acapulco", Duration = TimeSpan.FromDays(20) },
                        new Trip { Destination = "Lima", Duration = TimeSpan.FromDays(98) }
                    }
                },
                {
                    Guid.Parse("2284247F-7F72-41A1-B892-4D84CB53D9E7"),
                    new Trip[]
                    {
                        new Trip { Destination = "Dubrovnik", Duration = TimeSpan.FromDays(59) }
                    }
                }
            };

        // CQR
        public static Task<Trip[]> GetTripsByUser(User user)
        {
            var trips = tripsByUserId[user.Id];
            user.SetTrips(trips);

            return Task.FromResult(trips);
        }
    }
}