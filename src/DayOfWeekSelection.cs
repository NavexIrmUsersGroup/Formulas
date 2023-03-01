// Recalculation Interval: Recurring, 6 hours
// Dependancies: Two System Lookup Tables

// Create a standard system lookup table.
// Populate the table with the data listed in Table 1 below.

// Create a standard system lookup table.
// Populate the table with the data listed in Table 2 below.

// Create a Lookup field in the table with the following settings:
// Display Name: Day of Week.
// System Name: _DayOfWeek.
// Target: Table created in step #1.
// Create Report Definition to only display the Name field.

// Create a Lookup field in the table with the following settings:
// Display Name: Frequency.
// System Name: _Frequency.
// Target: Table created in step #2.
// Create Report Definition to only display the Name field.

// Create a Date field in the table with the following settings:
// Display Name: Previous Date.
// System Name: _PreviousDate.

// Create a Date field in the table with the following settings:
// Display Name: Next Date.
// System Name: _NextDate.
// Add the formula in Listing 1 to the field.

// Table 1
//
// _Name        _Value
//
// Monday       1
// Tuesday      2
// Wednesday    3
// Thursday     4
// Friday       5
// Saturday     6
// Sunday       0
// weekday      -1

// Table 2
//
// _Name        _Value
//
// Daily        1
// Weekly       7
// Monthly      30
// Quarterly    90
// Annually     365

// Listing 1
//
// get the value of the previous date and frequency
DateTime? previousDate = record.GetValue<DateTime?>("_PreviousDate");
int frequencyValue = (int)record.GetValue<Decimal?>("_Frequency._Value");

// get the .Net numeric value of the day selected in the dropdown
// a value of -1 represents the next weekday
int dayOfWeekTargetNumber = (int)record.GetValue<Decimal?>("_DayOfWeek._Value");

// calculate the future date based on the previous date and frequency
DateTime? nextDateSimple = previousDate.Value.AddDays(frequencyValue);
int nextDateSimpleNumber = (int)nextDateSimple.Value.DayOfWeek;

// check to see if the future date landed on the day selected and if so exit early
if (nextDateSimpleNumber == dayOfWeekTargetNumber){
    return nextDateSimple;
    } else {
        // calculate the offset which will result in the closest matching day
        int daysOffset = dayOfWeekTargetNumber - nextDateSimpleNumber;
        // if the offest is negative the closest matching day was in the past
        // therefore we add 7 days to pick the closest matching day in the future
        if (daysOffset < 0 ){
            daysOffset += 7;
        }
        // check to see if we are picking picking the next weekday and if not exit early
        if (dayOfWeekTargetNumber != -1){
            return nextDateSimple.Value.AddDays(daysOffset);
        } else {
            // check to see if we landed on Sunday and if so add 1 day
            if ((int)nextDateSimple.Value.DayOfWeek == 0){
                return nextDateSimple.Value.AddDays(1);
            } else {
                // check to see if we landed on Saturday and is so add 2 days
                if((int)nextDateSimple.Value.DayOfWeek == 6){
                    return nextDateSimple.Value.AddDays(2);
                } else {
                    // we landed on a weekday so no adjustment needed
                    return nextDateSimple;
                }
            }
        }
    }
