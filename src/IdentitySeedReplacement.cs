// Recalculation Interval: One Time
// Dependencies: None

// Purpose: Identity Seeds can be used to create unique record Ids.  The problem with using
// identity seeds is that they base seed is reset if the formula is changed thereby changing
// the "unique id".
// This formula can be used to create a platform level unique record Id that never changes.

// Formula Field Configuration:
//  Type: Numeric
//    Precision: 15
//    Scale: 0

// Known Issues / Hard-Coded Values:
// The table Id is not currently accessible in the formula engine and has to be hard-coded to match the table in which the field is added.
// The multiplier needs to be a multiple of 10 with the value determining the number of possible records that the table will hold up to a current maximum of 10000000000 based on table Ids being 5 digits and the field limit being 15 places.

// Formula Description:
// In this example the hard-coded table Id is 10013 (system prebuilt Risk Exceptions table).
// In this example of 1000000000 allows up to a 999,999,999 records in a table and for the table Id to increase from the current base value of 10,000 or 5 places (resulting in a precision 14 value) up to 999,999 (resulting in a precision 15 value) without having to adjust the formula or any subsequent dependencies.
// Assuming a record Id of 5 for this example the result unique record Id would be 10013000000005.

decimal tableId = 10013;
decimal multiplier = 1000000000;
decimal recordId = record.GetValue<int>("Id");

return tableId * multiplier + recordId;

// Notes:
// To reverse the unique record Id into it's two components you would use the following formula
// decimal UniqueRecordId = record.GetValue<int>("IdUnique");  // value from the field for this example is 10013000000005
// decimal recordId = UniqueRecordIdField % 1000000000 // result is 5
// decimal tableId = (UniqueRecordId - recordId) / 1000000000 // result is 10013
