#ifndef Check_h
#define Check_h

#include <iostream>
#include <string>

using namespace std;

class Check
{
private:
	string name; // Holds the recipient of the check
	string date; // The date of the check
	string amount; // The amount the check is worth
	int id; // The check's ID
public:
	Check(string data); // Constructs using data string
	Check(); // Default constructor with junk values

	// Formats a given date from month/day/year
	// to year-month-day
	void formatDate();

	// Mutator method for ID
	void setID(int newID);

	// Converts the check amount from a dollar
	// value to english text
	static string AmountToEnglish(Check check);

	// Displays a check
	static void Display(Check check);

	// Retrieves a check from a data string
	static Check GetCheck(string data);
};

#endif