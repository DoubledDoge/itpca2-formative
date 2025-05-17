namespace Drone_Racing_System
{
    static class MainClass
    {
        private static readonly List<Drone> Drones = Drone.GetDrones();

        private static void Main()
        {
            Console.Title = "BuzzBets Drone Racing System";

            Console.Write(
                "==================================\n"
                + "     BuzzBets Exchange System\n"
                + "==================================\n\n"
            );

            Console.WriteLine("Welcome to BuzzBets Drone Racing System!\n");
            Console.WriteLine("Where Velocity Meets Fortune.\n");

            ShowLoadingAnimation();
            MakeBet();


        }

        private static void MakeBet()
        {
            ShowDrones();

            string droneName = InputValidator.GetValidStringInput("Enter the name of the drone you want to bet on");

            var selectedDrone = Drones
                .Where(d => d.Name.Contains(droneName, StringComparison.OrdinalIgnoreCase));


        }

        private static void ShowDrones()
        {
            Console.WriteLine("Available Drones:");
            foreach (var drone in Drones)
            {
                Console.WriteLine($"Name: {drone.Name}, Average Speed: {drone.Speed} km/h");
            }
        }

        private static void PerformRace()
        {

        }

        private static void ShowRaceResults()
        {

        }

        private static void RandCalculate()
        {

        }

        private static void ShowLoadingAnimation()
        {
            Console.Write("\nLoading system");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
