// Recalculation Interval: Recurring, 6 hours
// Dependencies: None

// Purpose: Display Referenced By links in the form layout without using the builtin control.
// It can be helpful to configure a Referenced By link to show on the table instead of in the "Linkages" Subpage
// The trade-off is that the hardcoded layout of putting this field in the layout takes considerable space.
// This formula provides an alternative solution if the Referenced By field will only ever contain 1 or 2 linked records.

// Formula Field Configuration:
//   Type: Rich Text

// Known Issues: The formula engine only exposing the First and Last method of accessing data in a lookup field.
// This means only 1 o2 2 linked records will be displayed until the formula engine supports looping operations.

// Hard-Coded Values: The Id of the foreign table must be hardcoded into the formula as this value is not accessible from the formula engine.

// Formula Description: This formula displays either 1 or 2 links to records in a 1:M lookup field.

// Id of foreign table.
String tableId = "10285";

// Id and Name of First record in the lookup field of the foreign table that creates the Referenced By linkage.
String recordFirstId = record.First<int?>("_ERMActivities_ERMActivityUpdates.Id").ToString();
String recordFirstName = record.First<String>("_ERMActivities_ERMActivityUpdates._Name");

// Id and Name of Last record in the lookup field of the foreign table that creates the Referenced By linkage.
String recordLastId = record.Last<int?>("_ERMActivities_ERMActivityUpdates.Id").ToString();
String recordLastName = record.Last<String>("_ERMActivities_ERMActivityUpdates._Name");

////////////////////////////////////////////////////////////////////////////////
// No Edits are needed beyond this point unless you want to change the style. //
////////////////////////////////////////////////////////////////////////////////

// This style mirrors the one in the platform with links always shown as plain black text that only underline when the mouse hovers over the link.
String style = "<style type=\"text/css\"> a {text-decoration: none; color:inherit;} a:hover { text-decoration: underline; } </style>";

// Building the relative link to the record in the foreign table. This URL format could change in the future as the platform conversion to the Angular framework continues.
String linkFirst = style + "<a href=\"/Rm/Portal.aspx?tableId=" + tableId + "&id=" + recordFirstId + "\">" + recordFirstName + "</a>";
String linkLast = style + "<a href=\"/Rm/Portal.aspx?tableId=" + tableId + "&id=" + recordLastId + "\">" + recordLastName + "</a>";

// check to see if the First and Last Id are the same, if so we only have one record and return that link, else return both links. one per line.
if (recordFirstId == recordLastId)
    return linkFirst;
else
    return String.Format("{0}<br>{1}", linkFirst, linkFirst);
