namespace Drone_Racing_System
{
    public class Drone (int id, string name)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;

        public static Drone[] GetDrones()
        {
            return
            [
                new Drone(1, "WirrWind Warrior"),
                new Drone(2, "Propeller's Promise"),
                new Drone(3, "Voltage Vanguard"),
                new Drone(4, "Airborne Alibi"),
                new Drone(5, "Throttle Thunder"),
            ];
        }
    }
}
