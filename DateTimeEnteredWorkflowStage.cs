// Recalculation Interval: Recurring, 6 hours
// Dependancies: StageIdAndTimeStamp.cs

// Purpose: There is no system field that captures when a record enters a workflow stage. The Updated field will show when a record enters a stage this value will only be accurate if the record is not edited while remaining in the same workflow stage since editing the record will change the value in the Updated field.

// Formula Field Configuration:
//   Type: Date
//   Alias: DateTimeEnteredStage
//   Include Time: Yes

// Known Issues / Hard-Coded Values:
// As this formula has a dependancy that is also a formula the best approach is to set a specific Initial Recalculation date and time that is at least 10 minutes later than the the Initial Recalculation set on the field that this formula is dependant.

// Formula Description:
// This is a self referencing field that only updates itself if the workflow stage Id changes.

DateTime? dateExistingValue = record.GetValue<DateTime?>("_DateTimeEnteredStage");
String strWorkflowDateTimeStamp = record.GetValue<String>("_StageIdAndTimeStamp");

if (!string.IsNullOrEmpty(strExistingValue)) { // if the field is not empty get the workflow stage id from the _StageIdAndTimeStamp field value
    int endPosition = strExistingValue.IndexOf("-"); // get the poistion of the first delimiter
    String strExistingWorkflowId = strExistingValue.Substring(0, endPosition); // the workflow stage Id is stored as the first delimited value
    if (strExistingWorkflowId == strWorkflowStageId) { // the record is still in the same workflow stage so return the existing field value
        return strExistingValue;
    } else { // the record has moved to a new workflow stage so set a new workflow stage Id and the time stamp with a dash (-) as the field delimiter
        return String.Format("{0}-{1}", strWorkflowStageId, strCurrenDate);
    }
} else { // the field is empty so set the workflow stage Id and the time stamp with a dash (-) as the field delimiter
    return String.Format("{0}-{1}", strWorkflowStageId, strCurrenDate);
}

// Notes:
// None.

