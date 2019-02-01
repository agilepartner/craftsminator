package net.agilepartner.craftsminator.trips;

import net.agilepartner.craftsminator.users.User;
import net.agilepartner.craftsminator.users.UserRepository;
import org.junit.Before;
import org.junit.Test;

import javax.crypto.Cipher;
import java.nio.charset.StandardCharsets;
import java.util.Base64;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import static org.assertj.core.api.Assertions.assertThat;

public class TripServiceTest {

    private UUID connectedUser;

    @Before
    public void init() {
        this.connectedUser = UsersForTests.GRIFFIN;
        TripService.connect(connectedUser);
    }

    @Test
    public void test_service() throws Exception {
        UserRepository userRepository = new UserRepository();
        TripService tripService = new TripService();

        Optional<User> aFriendOfTheConnectedUser = userRepository.getUser(UsersForTests.SMITH);

        List<Trip> trips = tripService.getTripsForUser(aFriendOfTheConnectedUser.get());

        assertThat(trips).hasSize(1);
        assertThat(trips).extracting(Trip::getDestination).containsOnly("Dubrovnik");

        System.out.println(new String(Base64.getDecoder().decode("Q2FydGUgNTQ="), StandardCharsets.UTF_8));
    }

}