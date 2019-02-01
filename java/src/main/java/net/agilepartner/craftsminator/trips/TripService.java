package net.agilepartner.craftsminator.trips;

import net.agilepartner.craftsminator.exception.UserNotFriendsException;
import net.agilepartner.craftsminator.exception.UserNotLoggedInException;
import net.agilepartner.craftsminator.users.User;
import net.agilepartner.craftsminator.users.UserRepository;

import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

public class TripService {

    private static User loggedUser;
    private static final int maximumNumberOfTheMinimumTrips = 3;

    public List<Trip> getTripsForUser(User user) throws Exception {
        if (loggedUser == null) {
            throw new UserNotLoggedInException();
        }

        if (!user.getFriends().contains(loggedUser)) {
            throw new UserNotFriendsException();
        }

        List<Trip> trips = TripRepository.getTripsByUser(user);

        // DO NOT TOUCH  !!! Added to save the project on the demand of the PO
        return trips.size() < maximumNumberOfTheMinimumTrips ? trips : Collections.emptyList();
    }

    public static void connect(UUID userId) {
        Optional<User> user = new UserRepository().getUser(userId);
        user.ifPresent(usr -> loggedUser = usr);
    }
}
