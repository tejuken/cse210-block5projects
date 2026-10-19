using System;
using System.Globalization;

// Define the abstract base class shared by all exercise activities
namespace ExerciseTracking
{
    public abstract class Activity
    {
        // Create a private field to store the activity date
        // Store the activity date
        private DateTime _date;

        // Create a private field to store the activity duration in minutes 
        // Store the activity duration in minutes
        private int _length;

        // Create Activity object using constructor that receives the date and duration shared by every activity
        public Activity(DateTime date, int length)
        {
            // Assign the supplied date to the private date field
            _date = date;

            // Assign the supplied duration to the private length field
            _length = length;
        }

        // Return the activity date without exposing the private field
        public DateTime GetDate()
        {
            // Return the stored activity date
            return _date;
        }

        // Return the activity duration without exposing the private field
        public int GetLength()
        {
            // Return the stored activity duration in minutes
            return _length;
        }

        // Require every derived activity to calculate its distance
        public abstract double GetDistance();

        // Require every derived activity to calculate its speed
        public abstract double GetSpeed();

        // Require every derived activity to calculate its pace
        public abstract double GetPace();

        // Provide a shared summary method that supports polymorphism
        public virtual string GetSummary()
        {
            // Format the date with an English abbreviated month
            string date = _date.ToString(
            "dd MMM yyyy",
            CultureInfo.InvariantCulture
        );

        // Get the name of the specific activity class
        string activityName = GetType().Name;

        // Obtain the distance through the derived class implementation
        double distance = GetDistance();

        // Obtain the speed through the derived class implementation
        double speed = GetSpeed();

        // Obtain the pace through the derived class implementation
        double pace = GetPace();

        // Return the activity summary using kilometers and metric units
        return $"{date} {activityName} ({_length} min): " +
            $"Distance {distance:F1} km, " +
            $"Speed {speed:F1} kph, " +
            $"Pace {pace:0.##} min per km";
        }
    }
}