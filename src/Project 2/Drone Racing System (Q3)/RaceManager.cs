namespace Drone_Racing_System
{
    public static class RaceManager
    {
        public const double TotalDistance = 25.0; // 25km
        private static readonly Lock ConsoleLock = new Lock();
        private static Drone[] drones = [];
        private static int userBet;
        private static DateTime raceStartTime;

        public static void OnMilestoneReached(Drone drone, int milestone)
        {
            lock (ConsoleLock)
            {
                // Calculate elapsed time since race start
                var elapsed = DateTime.Now - raceStartTime;

                if (milestone == 5)
                {
                    // Special message for race completion
                    ConsoleDesign.WriteMilestone(
                        $"[{elapsed:mm\\:ss}] {drone.Name} finished the race!\n",
                        ConsoleColor.Green
                    );
                }
                else
                {
                    // Colour code milestones for distance tracking
                    var milestoneColor = milestone switch
                    {
                        1 => ConsoleColor.White,
                        2 => ConsoleColor.Cyan,
                        3 => ConsoleColor.Magenta,
                        4 => ConsoleColor.DarkYellow,
                        _ => ConsoleColor.Gray,
                    };

                    // Announce drone progress with timestamp
                    ConsoleDesign.WriteMilestone(
                        $"[{elapsed:mm\\:ss}] {drone.Name} reached milestone {milestone} ({milestone * 5}km)!\n",
                        milestoneColor
                    );
                }
            }
        }

        public static async Task StartRace()
        {
            drones = Drone.GetDrones();

            // Get user's bet
            GetUserBet();

            // Countdown (Hype)
            Console.WriteLine("\nRace is about to begin!");
            Console.WriteLine("=".PadLeft(50, '='));
            await CountdownToStart();

            // Race begins!
            ConsoleDesign.WriteSuccess("\nRace Started!\n");
            Console.WriteLine("Watch for milestone announcements as drones progress...\n");

            // Record race start time
            raceStartTime = DateTime.Now;

            // Start racing all drones asynchronously
            var racingTasks = drones.Select(drone => Task.Run(() => RaceDrone(drone))).ToArray();

            // Update display while racing (much less frequent updates)
            var displayTask = Task.Run(UpdateRaceStatus);

            // Wait for all drones to finish
            await Task.WhenAll(racingTasks);

            // Cancel the display task since all drones are finished
            // (The display task will exit its loop naturally when all drones are finished)

            // Announce results immediately
            AnnounceResults();
        }

        private static void GetUserBet()
        {
            Console.WriteLine("\nBetting Time!");
            Console.WriteLine("=".PadLeft(30, '='));

            // Display a list of drones
            Console.WriteLine("Available drones to bet on:");
            for (var i = 0; i < drones.Length; i++)
            {
                ConsoleDesign.WriteMenu($"{i + 1}. {drones[i].Name}\n");
            }

            // Betting on a drone
            userBet = InputValidator.GetValidIntInput("\nPlace your bet (choose drone 1-5)", 1, 5);

            ConsoleDesign.WriteSuccess($"\nYou bet on: {drones[userBet - 1].Name}\n");
            Console.WriteLine("Good luck!");
        }

        private static async Task CountdownToStart()
        {
            // Fancy countdown animation
            for (var i = 3; i > 0; i--)
            {
                ConsoleDesign.WriteHeader($"\nStarting in {i}...\n");
                await Task.Delay(1000);
            }
        }

        private static async Task RaceDrone(Drone drone)
        {
            // When the drone haven't been finished
            while (!drone.HasFinished)
            {
                drone.MoveForward();
                // Shorter delay between moves (1-2 seconds) for faster racing
                await Task.Delay(Random.Shared.Next(1000, 2000));
            }
        }

        private static async Task UpdateRaceStatus()
        {
            // While the race haven't finished yet
            while (!drones.All(d => d.HasFinished))
            {
                await Task.Delay(20000); // Check every 20 seconds for cleaner display

                lock (ConsoleLock)
                {
                    var elapsed = DateTime.Now - raceStartTime;
                    Console.WriteLine(
                        $"[{elapsed:mm\\:ss}] Race in progress - {drones.Count(d => d.HasFinished)}/5 drones finished"
                    );
                }
            }
        }

        private static void AnnounceResults()
        {
            var totalRaceTime = DateTime.Now - raceStartTime;

            Console.Clear();
            Console.WriteLine("\nRace Completed!");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine($"Total race time: {totalRaceTime:mm\\:ss}\n");

            // Sort drones by finish time
            var finishedDrones = drones
                .Where(d => d.HasFinished)
                .OrderBy(d => d.FinishTime)
                .ToArray();

            // Announce winner
            var winner = finishedDrones.First();
            ConsoleDesign.WriteSuccess($"Winner: {winner.Name}! \n");

            // Show final standings with finish times
            Console.WriteLine("\nFinal Results:");
            Console.WriteLine("-".PadLeft(40, '-'));

            for (var i = 0; i < finishedDrones.Length; i++)
            {
                var drone = finishedDrones[i];
                var finishTime = drone.FinishTime!.Value - raceStartTime;

                // Format position
                var position = (i + 1) switch
                {
                    1 => "1st",
                    2 => "2nd",
                    3 => "3rd",
                    _ => $"{i + 1}th",
                };

                Console.WriteLine($"{position} - {drone.Name} (Finished at {finishTime:mm\\:ss})");
            }

            // Check user's bet
            Console.WriteLine("\nBet Result:");
            Console.WriteLine("-".PadLeft(25, '-'));

            // Check if user won or not
            if (winner.Id == userBet)
            {
                ConsoleDesign.WriteSuccess("Congratulations! You won your bet! \n");
                ConsoleDesign.WriteSuccess("You've earned your winnings!\n");
            }
            else
            {
                ConsoleDesign.WriteError("Sorry, you lost your bet this time.\n");
                Console.WriteLine($"You bet on: {drones[userBet - 1].Name}");
                Console.WriteLine("Better luck next time!");
            }
        }
    }
}
