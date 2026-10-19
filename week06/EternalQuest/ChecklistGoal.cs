using System;

// This class represents a goal that must be recorded a specified number of times.
public class ChecklistGoal : Goal
{
    // Store how many successful recordings have been completed.
    private int _amountCompleted;

    // Store how many recordings are required to complete the goal.
    private int _targetCount;

    // Store the bonus awarded when the target is reached.
    private int _bonus;

    // Initialize the shared and checklist-specific information.
    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonus,
        int amountCompleted = 0)
        : base(name, description, points)
    {
        // Ensure that the target is at least one recording.
        _targetCount = Math.Max(1, targetCount);

        // Prevent a negative completion bonus.
        _bonus = Math.Max(0, bonus);

        // Keep progress within the valid range from zero to the target.
        _amountCompleted = Math.Max(0, Math.Min(amountCompleted, _targetCount));

        // Mark the goal complete if its restored progress has reached the target.
        SetComplete(_amountCompleted >= _targetCount);
    }

    // Override the completion method to check the current checklist progress.
    public override bool IsComplete()
    {
        // The checklist is complete once progress reaches the target.
        return _amountCompleted >= _targetCount;
    }

    // Override the event method to record one checklist completion.
    public override int RecordEvent()
    {
        // Prevent further points after the checklist target has been reached.
        if (IsComplete())
        {
            // Return zero because no further progress is required.
            return 0;
        }

        // Increase the number of completed recordings by one.
        _amountCompleted++;

        // Begin with the regular points awarded for this recording.
        int pointsEarned = GetPoints();

        // Check whether this recording reaches the required target.
        if (_amountCompleted == _targetCount)
        {
            // Add the finishing bonus to the regular points.
            pointsEarned += _bonus;

            // Update the shared completion state.
            SetComplete(true);
        }

        // Return the total points earned from this recording.
        return pointsEarned;
    }

    // Override the display method to show completion status and progress.
    public override string GetDetailsString()
    {
        // Display X when the target is reached and a blank space otherwise.
        string completionMark = IsComplete() ? "X" : " ";

        // Show progress, points per recording, and the finishing bonus.
        return $"[{completionMark}] {GetName()} ({GetDescription()}) — " +
               $"Completed {_amountCompleted}/{_targetCount} times; " +
               $"{GetPoints()} points each; bonus {_bonus}";
    }

    // Override the save method to preserve all checklist settings and progress.
    public override string GetSaveString()
    {
        // Save the type, text fields, points, target, bonus, and progress.
        return $"Checklist|{EncodeText(GetName())}|{EncodeText(GetDescription())}|" +
               $"{GetPoints()}|{_targetCount}|{_bonus}|{_amountCompleted}";
    }
}