using System;

// This abstract class defines the common information and behaviour of every goal.
public abstract class Goal
{
    // Store the goal name privately so derived classes cannot access the field directly.
    private string _name;

    // Store the goal description privately to protect the information.
    private string _description;

    // Store the points awarded for the goal privately.
    private int _points;

    // Store whether the goal is complete for goal types that use completion status.
    private bool _isComplete;

    // Initialize the shared attributes whenever a derived goal is created.
    protected Goal(string name, string description, int points, bool isComplete = false)
    {
        // Store the supplied name, using an empty string if null was supplied.
        _name = name ?? string.Empty;

        // Store the supplied description, using an empty string if null was supplied.
        _description = description ?? string.Empty;

        // Prevent negative points from being assigned to a goal.
        _points = Math.Max(0, points);

        // Store the initial completion state.
        _isComplete = isComplete;
    }

    // Return the goal name without exposing the private field.
    public string GetName()
    {
        // Provide the stored name to the calling method.
        return _name;
    }

    // Return the goal description without exposing the private field.
    public string GetDescription()
    {
        // Provide the stored description to the calling method.
        return _description;
    }

    // Return the points associated with the goal.
    public int GetPoints()
    {
        // Provide the stored points to the calling method.
        return _points;
    }

    // Report completion status for goal types that use the shared status.
    public virtual bool IsComplete()
    {
        // Return the stored completion value.
        return _isComplete;
    }

    // Allow derived classes to update completion without accessing the field directly.
    protected void SetComplete(bool isComplete)
    {
        // Update the private completion field.
        _isComplete = isComplete;
    }

    // Require every derived goal class to define how an event is recorded.
    public abstract int RecordEvent();

    // Require every derived goal class to define how it is displayed.
    public abstract string GetDetailsString();

    // Require every derived goal class to define how its data is saved.
    public abstract string GetSaveString();

    // Encode text so separators and punctuation do not corrupt saved records.
    protected static string EncodeText(string value)
    {
        // Convert the text into UTF-8 bytes and then encode those bytes as Base64.
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
    }

    // Decode text that was previously encoded for the save file.
    protected static string DecodeText(string value)
    {
        // Convert the Base64 text back into its original UTF-8 string.
        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}