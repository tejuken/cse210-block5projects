using System;

// This class represents a goal that can be recorded repeatedly without completion.
public class EternalGoal : Goal
{
    // Initialize the eternal goal using the shared attributes in Goal.
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // No additional fields are required because eternal goals never complete.
    }

    // Override the completion method because an eternal goal is never complete.
    public override bool IsComplete()
    {
        // Always return false to preserve the meaning of an eternal goal.
        return false;
    }

    // Override the event method to award points on every recording.
    public override int RecordEvent()
    {
        // Return the goal's points without changing any completion state.
        return GetPoints();
    }

    // Override the display method to identify the goal as ongoing.
    public override string GetDetailsString()
    {
        // Display an infinity symbol to show that this goal continues indefinitely.
        return $"[∞] {GetName()} ({GetDescription()}) — {GetPoints()} points each time";
    }

    // Override the save method to preserve the eternal goal's details.
    public override string GetSaveString()
    {
        // Save the type, encoded name, encoded description, and points.
        return $"Eternal|{EncodeText(GetName())}|{EncodeText(GetDescription())}|{GetPoints()}";
    }
}