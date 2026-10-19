using System;

// Define Cycling as a derived class of Activity
namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        // Create a private field to store the cycling speed in kilometers per hour
        // Store the cycling speed in kilometers per hour
        private double _speed;

        // Create Cycling object using constructor that receives the shared activity information and cycling speed
        public Cycling(DateTime date, int length, double speed)
            : base(date, length)
        {
            // Store the supplied cycling speed
            _speed = speed;
        }

        // Override the base method to calculate cycling distance
        public override double GetDistance()
        {
            // Calculate distance using speed and duration in hours
            return (_speed * GetLength()) / 60;
        }

        // Override the base method to return cycling speed
        public override double GetSpeed()
        {
            // Return the stored speed in kilometers per hour
            return _speed;
        }

        // Override the base method to calculate cycling pace
        public override double GetPace()
        {
            // Calculate the minutes required to cycle one kilometer
            return GetLength() / GetDistance();
        }
    }
}