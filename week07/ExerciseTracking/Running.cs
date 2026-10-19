using System;

// Define Running as a derived class of Activity
namespace ExerciseTracking
{
    public class Running : Activity
    {
        // Create a private field to store the running distance covered in kilometers
        // Store the running distance in kilometers
        private double _distance;

         // Create Swimming object using constructor that receives shared activity information and running distance
        public Running(DateTime date, int length, double distance)
            : base(date, length)
        {
            // Store the supplied running distance.
            _distance = distance;
        }

        // Override the base method to return the running distance
        public override double GetDistance()
        {
            // Return the distance in kilometers.
            return _distance;
        }

        // Override the base method to calculate running speed
        public override double GetSpeed()
        {
            // Calculate kilometers per hour using distance and duration
            return (GetDistance() / GetLength()) * 60;
        }

        // Override the base method to calculate running pace
        public override double GetPace()
        {
            // Calculate the minutes required to run one kilometer
            return GetLength() / GetDistance();
        }
    }
}