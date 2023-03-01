// Recalculation Interval: 24 hours
// Dependencies: _DateTimeEnteredStage, https://github.com/LockpathUsers/LockpathFormulas/blob/master/DateTimeEnteredWorkflowStage.cs

// Purpose: Calculates the number of days a record has been in the same workflow stage.

// Formula Field Configuration:
//   Type: Numeric
//   Alias: Any

// Known Issues / Hard-Coded Values: The formula currrently takes the raw difference in dates and formats the output to days.

// Formula Description: Tracks how many days a record has been in the same workflow stage.

DateTime? enteredWorkflowStageDate = record.GetValue<DateTime?>("_DateTimeEnteredStage");
DateTime? currentDate =  DateTime.Now;
return (decimal)((currentDate.Value - enteredWorkflowStageDate.Value).TotalDays);

// Notes: The value returned to the field can be updated to show weeks, months, years, etc.
