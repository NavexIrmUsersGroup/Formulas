// Recalculation Interval: Recurring, 6 hours
// Dependancies: _DateTimeEnteredStage, https://github.com/LockpathUsers/LockpathFormulas/blob/master/DateTimeEnteredWorkflowStage.cs

// Purpose: There is no system field that captures when a record enters a workflow stage. The Updated field will show when a record enters a stage this value will only be accurate if the record is not edited while remaining in the same workflow stage since editing the record will change the value in the Updated field.

// Formula Field Configuration:
//   Type: String
//   Alias: StageIdAndTimeStamp

// Known Issues / Hard-Coded Values:
// As this formula has a dependant field that is a formula, _DateTimeEnteredStage, the best approach is to set a specific Initial Recalculation date and time that is at least 10 minutes prior to the Initial Recalculation set on the _DateTimeEnteredStage field.

// Formula Description:
// This is a self referencing field that only updates itself if the record moves to a new workflow stage.

String strExistingValue = record.GetValue<String>("_StageIdAndTimeStamp");
String strWorkflowStageId = record.GetValue<int?>("WorkflowStage.Id").ToString();
String strCurrenDate = DateTime.Now.AddHours(-8).ToString(); // get the current date and time and offset for pacific timezone 

if (!string.IsNullOrEmpty(strExistingValue)) { // if the field is not empty get the workflow stage id from the _StageIdAndTimeStamp field value
    int endPosition = strExistingValue.IndexOf("-"); // get the poistion of the first delimiter
    String strExistingWorkflowId = strExistingValue.Substring(0, endPosition); // the workflow stage Id is stored as the first delimited value
    if (strExistingWorkflowId == strWorkflowStageId) { // if the existing workflow stage id from the field matches the currnet workflow stage id then return the existing field value
        return strExistingValue;
    } else { // set a new workflow stage Id and the time stamp with a dash (-) as the field delimiter
        return String.Format("{0}-{1}", strWorkflowStageId, strCurrenDate);
    }
} else { // set a new workflow stage Id and the time stamp with a dash (-) as the field delimiter
    return String.Format("{0}-{1}", strWorkflowStageId, strCurrenDate);
}

// Notes:
// This formula could be adjusted to capture and track the workflow Id instead of or in addition to the workflow stage Id. This would then only update the field when a record moved between workflows.
