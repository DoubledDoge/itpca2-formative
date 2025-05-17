namespace Drone_Racing_System
{
    public class Drone (int id, string name, int speed)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public int Speed { get; } = speed;

        public static List<Drone> GetDrones()
        {
            return
            [
                new Drone(1, "WirrWind Warrior", 120),
                new Drone(2, "Propeller's Promise", 150),
                new Drone(3, "Voltage Vanguard", 130),
                new Drone(4, "Airborne Alibi", 140),
                new Drone(5, "Throttle Thunder", 160),
            ];
        }
    }
}
