using System;

// This class represents a goal that can be completed only once.
public class SimpleGoal : Goal
{
    // Store the completion state privately because only SimpleGoal needs direct access.
    private bool _simpleComplete;

    // Initialize the simple goal using shared information from the base class.
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points, isComplete)
    {
        // Store the initial completion state for this simple goal.
        _simpleComplete = isComplete;
    }

    // Override the completion method to return this goal's completion state.
    public override bool IsComplete()
    {
        // Report whether the simple goal has already been completed.
        return _simpleComplete;
    }

    // Override the event method to award points only once.
    public override int RecordEvent()
    {
        // Check whether the goal has already been completed.
        if (_simpleComplete)
        {
            // Return zero because this goal cannot award points a second time.
            return 0;
        }

        // Mark the simple goal as completed.
        _simpleComplete = true;

        // Update the base class completion state as well.
        SetComplete(true);

        // Return the points earned from completing the goal.
        return GetPoints();
    }

    // Override the display method to show the correct completion symbol.
    public override string GetDetailsString()
    {
        // Use X when the goal is complete and a blank space otherwise.
        string completionMark = _simpleComplete ? "X" : " ";

        // Display the status, name, description, and points.
        return $"[{completionMark}] {GetName()} ({GetDescription()}) — {GetPoints()} points";
    }

    // Override the save method to preserve the simple goal's data.
    public override string GetSaveString()
    {
        // Save the type, encoded text fields, points, and completion state.
        return $"Simple|{EncodeText(GetName())}|{EncodeText(GetDescription())}|{GetPoints()}|{_simpleComplete}";
    }
}