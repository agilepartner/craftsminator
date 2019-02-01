package net.agilepartner.craftsminator.trips;

import net.agilepartner.craftsminator.users.User;

import java.time.Duration;
import java.util.*;

public class TripRepository {

    private static Map<UUID, List<Trip>> tripsByUserId;

    static {
        Map<UUID, List<Trip>> map = new HashMap<>();
        map.put(UUID.fromString("6690DEB8-B5C6-46AB-A597-229F2608695B"), Arrays.asList(new Trip("Hawaï", Duration.ofDays(25L)),
                                                                                        new Trip("Paris", Duration.ofDays(10L)),
                                                                                        new Trip("Fort-de-France", Duration.ofDays(20L))));
        map.put(UUID.fromString("279FE4CE-5355-4C7F-ACDF-D69B017ABD87"), Arrays.asList(new Trip("Toronto", Duration.ofDays(12L)),
                                                                                        new Trip("London", Duration.ofDays(10L)),
                                                                                        new Trip("Acapulco", Duration.ofDays(20L)),
                                                                                        new Trip("Lima", Duration.ofDays(98L))));
        map.put(UUID.fromString("2284247F-7F72-41A1-B892-4D84CB53D9E7"), Arrays.asList(new Trip("Dubrovnik", Duration.ofDays(59L))));
        tripsByUserId = Collections.unmodifiableMap(map);
    }

    public static List<Trip> getTripsByUser(User user) {
        List<Trip> trips = tripsByUserId.get(user.getId());
        user.setTrips(trips);
        return trips;
    }
}
