namespace Drone_Racing_System
{
    public class Drone(int id, string name)
    {

        private static readonly Random random = new Random();
        private static readonly Lock lockObject = new Lock();
        public int Id { get; } = id;
        public string Name { get; } = name;
        public double DistanceCovered { get; private set; }
        public bool HasFinished { get; private set; }
        public DateTime? FinishTime { get; private set; }
        private int CurrentMilestone { get; set; }

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

        public void MoveForward()
        {
            double moveDistance;

            if (HasFinished)
                return;

            lock (lockObject)
            {
                // Simulate drone movement with a random distance between 0.2 and 0.8 km
                moveDistance = random.NextDouble() * 0.6 + 0.2;
            }

            // Update the distance covered
            DistanceCovered += moveDistance;

            // Check if the drone has won and record it
            if (DistanceCovered >= RaceManager.TotalDistance)
            {
                DistanceCovered = RaceManager.TotalDistance;
                HasFinished = true;
                FinishTime = DateTime.Now;
            }

            // Check for milestone progress
            CheckMilestones();
        }

        private void CheckMilestones()
        {
            var newMilestone = (int)(DistanceCovered / 5); // Every 5km is a milestone

            // Ensure we only update if the new milestone is greater than the current one
            if (newMilestone <= CurrentMilestone || newMilestone > 5)
                return;

            // Update the current milestone
            CurrentMilestone = newMilestone;
            RaceManager.OnMilestoneReached(this, newMilestone);
        }

        public double GetProgressPercentage()
        {
            return DistanceCovered / RaceManager.TotalDistance * 100;
        }
    }
}
