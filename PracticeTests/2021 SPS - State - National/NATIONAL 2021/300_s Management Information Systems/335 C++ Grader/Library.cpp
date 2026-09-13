#include <iostream>
#include <fstream> // Allows reading of files
#include <string> // Allows use of getline(ifstream, string)
#include <iomanip> // Allows output manipulation
#include <sstream> // Allows splitting of string
#include <vector> // Allows use of vectors
#include "Library.h"

using namespace std;

// Splits a selected string into a collection 
// of strings separated by a given delimeter
vector<string> Split(char delim, string input)
{
	vector<string> tokens; // Collection of string tokens
	stringstream stream(input); // Stringstream of input
	string token; // Used to pull out individual tokens
	// While delims still present in string...
	while (getline(stream, token, delim))
		if (token.compare(""))
			tokens.push_back(token); // Add to vector
	return tokens; // Returns collection
}

string Powers[] = { "", "THOUSAND", "MILLION", "BILLION" };
string Ones[] = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE",
	"SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN",
	"TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN",
	"SEVENTEEN", "EIGHTEEN", "NINETEEN" };
string Tens[] = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY",
	"SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

// If answer is not blank, pad the string
string PadNumber(string answer)
{
	if (answer == "")
		return "";
	return " " + answer;
}

// Converts a hundred value to text
string translateHundred(int amount)
{
	// If less than 20, simply return the value from Ones array
	if (amount < 20)
		return Ones[amount];
	// Get the number of tens and ones, then pad the ones and append
	int tens = amount / 10;
	int ones = amount % 10;
	return Tens[tens] + PadNumber(Ones[ones]);
}

// Converts a thousand value to text
string translateThousand(int amount)
{
	// If less than 100, translate it in that respect
	if (amount < 100)
		return translateHundred(amount);
	// Get the amount of hundreds and tens
	// Then append the hundreds and pad the result of hundred translation
	int hundreds = amount / 100;
	int tens = amount % 100;
	return Ones[hundreds] + " HUNDRED" + PadNumber(translateHundred(tens));
}

// Converts a given dollar and cents amount to English text
string DollarsToEnglish(int dollars, int cents)
{
	string result = ""; // The value in English
	int number = dollars; // Gives a changeable value for dollars
	int power = 0; // Determines power
	while (number > 0)
	{
		if (number % 1000 != 0) // If there is value in thousands
		{
			// Translate the thousands value and add necessary power
			result = translateThousand(number % 1000) +
				PadNumber(Powers[power] + PadNumber(result));
		}
		number /= 1000; // Adjust by power
		power++; // Increment power
	}

	if (cents != 0) // If there are cents
	{
		if (dollars != 0) // If there are no dollars
			result.append(" AND ");
		// Add the cents as a string
		result.append(to_string(cents) + "/100");
	}
	result.append(" DOLLARS");
	return result;
}
