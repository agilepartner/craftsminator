using System;
using System.Collections.Generic;
using Craftsminator.Trips;

namespace Craftsminator.Users
{
    public class User
    {
        private readonly List<Trip> trips;
        private readonly List<User> friends;

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public IReadOnlyCollection<User> Friends
        {
            get { return friends.AsReadOnly(); }
        }

        public IReadOnlyCollection<Trip> Trips
        {
            get { return trips.AsReadOnly(); }
        }

        public User(
            Guid id,
            string lastName,
            string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;

            trips = new List<Trip>();
            friends = new List<User>();
        }

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
        }

        public void SetTrips(Trip [] newTrips)
        {
            trips.Clear();
            trips.AddRange(newTrips);
        }
    }
}
