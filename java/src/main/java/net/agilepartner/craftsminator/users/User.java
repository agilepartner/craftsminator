package net.agilepartner.craftsminator.users;


import net.agilepartner.craftsminator.trips.Trip;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.UUID;

public class User {
    private UUID id;
    private List<Trip> trips;
    private List<User> friends;
    private String firstName;
    private String lastName;

    public User(UUID id, String lastName, String firstName) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.trips = new ArrayList<>();
        this.friends = new ArrayList<>();
    }

    public UUID getId() {
        return id;
    }

    public List<Trip> getTrips() {
        return trips;
    }

    public List<User> getFriends() {
        return friends;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void addFriend(User user) {
        this.friends.add(user);
    }

    public void addTrip(Trip trip) {
        this.trips.add(trip);
    }

    public void setTrips(List<Trip> trips) {
        this.trips = trips;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        User user = (User) o;
        return Objects.equals(id, user.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, trips, friends, firstName, lastName);
    }
}
