package net.agilepartner.craftsminator.users;


import net.agilepartner.craftsminator.trips.Trip;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

public class UserRepository {
    private List<User> users;

    public UserRepository() {
        users = new ArrayList<>();

        User simpson = new User(UUID.fromString("6690DEB8-B5C6-46AB-A597-229F2608695B"), "Simpson", "Homer");
        User griffin = new User(UUID.fromString("279FE4CE-5355-4C7F-ACDF-D69B017ABD87"), "Griffin", "Peter");
        User smith = new User(UUID.fromString("2284247F-7F72-41A1-B892-4D84CB53D9E7"), "Smith", "Stan");

        simpson.addFriend(smith);
        simpson.addFriend(griffin);

        griffin.addFriend(simpson);
        griffin.addFriend(smith);

        smith.addFriend(simpson);
        smith.addFriend(griffin);

        users.add(simpson);
        users.add(griffin);
        users.add(smith);
    }

    public Optional<User> getUser(UUID userId) {
        return users.stream().filter(user -> user.getId().equals(userId)).findFirst();
    }
}
