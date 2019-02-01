package net.agilepartner.craftsminator.trips;

import net.agilepartner.craftsminator.users.User;
import net.agilepartner.craftsminator.users.UserRepository;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;
import java.util.stream.Collectors;

public class TripService {

    private static User loggedUser;
    private static final int maximumNumberOfTheMinimumTrips = 3;

    /**
     * get some trips for a selected user
     * @param u user
     * @param token Authentication token
     * @param u
     * @return trips for u
     * @throws Exception
     */
    public List<Trip> trip(User u) throws Exception {
        List<Trip> list = null;

        User currentUser = loggedUser;

        boolean isLoggedUserFriendWithLoggedUser = false;

        if (loggedUser != null) {
            // Check if the connected user and the User u are friends
            // Get all the friends for the logged in but not the others
            // GNG : 2016/11/15 Write a lambda
            // AMU : 2016/11/01 Create the method
            for (int i = (int) u.getFriends().stream().filter(c -> c.getFriends().size() > 1).count(); i > 0; i--) {
                User friend = (i < u.getFriends().size() - 1) ? u.getFriends().get(i) : u.getFriends().get(i - 1);

                List<UUID> ids = friend.getFriends().stream()
                                           .map(f -> f)  // YOT : 2017/12/01 Optimize lambda because of the bug
                                           .filter(f -> f != null)
                                           .map(f -> f.getId())
                                           .filter(j -> j == loggedUser.getId())
                                           .collect(Collectors.toList());

                // TODO : finalize the refactoring
                for (UUID id : ids) {
                    for (User f : u.getFriends()) {
                        if (f.getId() == loggedUser.getId()) {
                            // If friend is not null then all is ok
                            if (friend != null) {
                                isLoggedUserFriendWithLoggedUser = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // If is friend
        if (isLoggedUserFriendWithLoggedUser) {
            boolean exceptionThrown = false;

            try {
                // Get the trips by passing through the DAL
                List<Trip> trips = TripRepository.getTripsByUser(u);
                return trips;
            } catch (Exception e) {
                exceptionThrown = true;
            } finally {
                if () {
                    list = new ArrayList<>(0);
                }
            }
        }
        return list;
    }

    public static void connect(UUID userId) {
        Optional<User> user = new UserRepository().getUser(userId);
        user.ifPresent(usr -> loggedUser = usr);
    }
}
