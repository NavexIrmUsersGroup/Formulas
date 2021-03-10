// While record Ids are unique in a table they are not unique in the platform. To create a platform level unique record Id it is necessary to create a numeric field in a table and populate it with a formula.

// Instructions
// 1. Create a numeric field in the table with the following settings:
//    System Name: IdUnique
//    Precision: 15
//    Scale: 0

// Add the formula below to the field that will hold the unique record Id

// The table Id is not currently accessible in the formula engine and has to be hard-coded to match the table in which the field is added.
// The multiplier in this example of 1000000000 allows up to a 999,999,999 records in a table and for the table Id to increase from the current base value of 10,000 (resulting in a precision 14 value) up to 999,999 (resulting in a precision 15 value) without having to adjust the formula or any subsequent dependencies.
// The multiplier can be reduced to change the number of zeros padded to the original recordId based on the number of anticipated records the table will eventually hold.
// In this example the hard-coded table Id is 10013 (system prebuilt Risk Exceptions table)
// Assuming a record Id of 5 for this example the result unique record Id would be 10013000000005

decimal tableId = 10013;
decimal multiplier = 1000000000;
decimal recordId = record.GetValue<int>("Id");

return tableId * multiplier + recordId;

// To reverse the unique record Id into it's two components you would use the following formula

// decimal UniqueRecordId = record.GetValue<int>("UniqueRecordIdField");  // value from the field for this example is 10013000000005
// decimal recordId = UniqueRecordIdField % 1000000000 // result is 5
// decimal tableId = (UniqueRecordId - recordId) / 1000000000 // result is 10013
