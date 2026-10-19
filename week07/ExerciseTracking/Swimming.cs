using System;

// Define Swimming as a derived class of Activity
namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        // Create a private field to store the number of swimming laps made
        // Store the number of swimming laps
        private int _laps;

        // Create Swimming object using constructor that receives shared activity information and number of laps
        public Swimming(DateTime date, int length, int laps)
            : base(date, length)
        {
            // Store the supplied number of swimming laps
            _laps = laps;
        }

        // Override the base method to calculate swimming distance
        public override double GetDistance()
        {
            // Convert the total distance in metres into kilometers
            return (_laps * 50.0) / 1000;
        }

        // Override the base method to calculate swimming speed
        public override double GetSpeed()
        {
            // Calculate kilometers per hour using distance and duration
            return (GetDistance() / GetLength()) * 60;
        }

        // Override the base method to calculate swimming pace
        public override double GetPace()
        {
            // Calculate the minutes required to swim one kilometer
            return GetLength() / GetDistance();
        }
    }
}