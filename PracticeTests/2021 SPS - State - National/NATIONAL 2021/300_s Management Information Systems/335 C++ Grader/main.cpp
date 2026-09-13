#include <iostream>
#include <fstream>
#include "Check.h"
#include "Library.h"
#include "List.h"

using namespace std;

const string filePath = "checkdata.txt";

// Populates the check list and retrieves the initial checkID
bool PopulateList(int& checkID, List<Check>& checkList);

// Formats and sets the ID of every element of the checklist
void FormatList(int checkID, List<Check>& checkList);

int main()
{
	int checkID; // The initial ID
	List<Check> checkList(20); // A list of each check
	if (PopulateList(checkID, checkList))
	{
		FormatList(checkID, checkList);

		cout << string(54, '-') << endl; // Displays header

		for (int i = 0; i < checkList.GetCount(); i++)
		{
			Check::Display(checkList[i]);
		}
	}
	else
	{
		cout << "File was not able to be loaded." << endl;
	}

	system("pause");
	return 0;
}

// Formats and sets the ID of every element of the checklist
void FormatList(int checkID, List<Check>& checkList)
{
	for (int i = 0; i < checkList.elementCount; i++)
	{
		// Formats, then sets ID while incrementing ID for next check
		checkList[i].formatDate();
		checkList[i].setID(checkID++);
	}
}

// Populates the check list and retrieves the initial checkID
bool PopulateList(int& checkID, List<Check>& checkList)
{
	bool success = true;

	ifstream dataFile(filePath); // Creates ifstream object
	if (dataFile.is_open()) // Ensures file is open
	{
		// Retrieves ID, then populates checklist from file
		string ID;
		string line;
		getline(dataFile, ID);
		checkID = atoi(ID.c_str());

		while (getline(dataFile, line))
		{
			checkList.Insert(Check::GetCheck(line));
		}
	}
	else 
	{
		success = false;
	}

	return success;
}