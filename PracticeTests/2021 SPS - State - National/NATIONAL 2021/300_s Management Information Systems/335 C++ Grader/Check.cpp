#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include "Check.h"
#include "Library.h"

using namespace std;

// Constructs using data string
Check::Check(string data)
{
	vector<string> checkTokens = Split(' ', data);
	name = checkTokens[0];
	name.append(" " + checkTokens[1]);
	date = checkTokens[2];
	amount = checkTokens[3];
}

// Default constructor with junk values
Check::Check()
{
	amount = "500";
	date = "1/2/03";
	id = 1;
	name = "John Doe";
}

// Formats a given date from month/day/year
// to year-month-day
void Check::formatDate()
{
	vector<string> dateTokens = Split('/', this->date);
	this->date = "20";
	this->date.append(dateTokens[2] + "-");
	if (atoi(dateTokens[0].c_str()) < 10)
		this->date.append("0");
	this->date.append(dateTokens[0] + "-");
	if (atoi(dateTokens[1].c_str()) < 10)
		this->date.append("0");
	this->date.append(dateTokens[1]);
}

// Converts the check amount from a dollar
// value to english text
string Check::AmountToEnglish(Check check)
{
	vector<string> currencyTokens = Split('.', check.amount);
	int dollars = atoi(currencyTokens[0].c_str());
	int cents = atoi(currencyTokens[1].c_str());
	return DollarsToEnglish(dollars, cents);
}

// Mutator method for ID
void Check::setID(int newID)
{
	id = newID;
}

// Displays a check
void Check::Display(Check check)
{
	cout << check.id << setw(50) << check.date << endl;
	cout << "PAY TO THE ORDER OF: " << setw(20) << left << check.name;
	cout << right << setw(13) << "$ " + check.amount << endl << endl;
	cout << AmountToEnglish(check) << endl;
	cout << setw(54) << "Business Inc." << endl;
	cout << string(54, '-') << endl;
}

// Retrieves a check from a data string
Check Check::GetCheck(string data)
{
	return Check(data);
}