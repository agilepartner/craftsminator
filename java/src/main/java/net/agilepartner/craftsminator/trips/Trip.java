package net.agilepartner.craftsminator.trips;


import java.time.Duration;

public class Trip {
    private String destination;
    private Duration duration;

    public Trip(String destination, Duration duration) {
        this.destination = destination;
        this.duration = duration;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public Duration getDuration() {
        return duration;
    }

    public void setDuration(Duration duration) {
        this.duration = duration;
    }
}
