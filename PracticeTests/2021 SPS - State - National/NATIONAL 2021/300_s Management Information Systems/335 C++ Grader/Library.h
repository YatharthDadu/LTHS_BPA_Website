#ifndef Library_h
#define Library_h

#include <iostream>
#include <fstream> // Allows reading of files
#include <string> // Allows use of getline(ifstream, string)
#include <iomanip> // Allows output manipulation
#include <sstream> // Allows splitting of string
#include <vector> // Allows use of vectors

using namespace std;

// Splits a selected string into a collection 
// of strings separated by a given delimeter
vector<string> Split(char delim, string input);

// If answer is not blank, pad the string
string PadNumber(string answer);

// Converts a hundred value to text
string translateHundred(int amount);

// Converts a thousand value to text
string translateThousand(int amount);

// Converts a given dollar and cents amount to English text
string DollarsToEnglish(int dollars, int cents);

#endif