export class Trip {
    public destination: string;
    public duration: number;

    constructor(destination: string, 
                duration: number) {
        this.destination = destination;
        this.duration = duration;
    }
}