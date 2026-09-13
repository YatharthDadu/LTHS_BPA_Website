#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <iomanip>
#include <sstream> // Allows splitting of string

using namespace std;

const string filePath = "hours.txt";

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

typedef struct emp
{
	string name = "";
	double pay = 0.0;
	double otbonus = 0.0;
	int hoursWeek1 = 0;
	int hoursWeek2 = 0;
	int hoursWeek3 = 0;
	int hoursWeek4 = 0;

	string getName()
	{
		return name;
	}

	int getHoursCurPeriod()
	{
		return hoursWeek3 + hoursWeek4;
	}

	int getHoursPrvPeriod()
	{
		return hoursWeek1 + hoursWeek2;
	}

	static int getOtHours(int hours)
	{
		return hours > 40 ? hours - 40 : 0;
	}

	static int getNormHours(int hours)
	{
		return hours > 40 ? 40 : hours;
	}

	static double getPay(int hours, double pay, double otbonus)
	{
		return (static_cast<double>(getNormHours(hours)) * pay)
			 + (static_cast<double>(getOtHours(hours)) * pay * otbonus);
	}

	double getPayCurPeriod()
	{
		return getPay(hoursWeek3, pay, otbonus) 
			 + getPay(hoursWeek4, pay, otbonus);
	}

	double getPayPrvPeriod()
	{
		return getPay(hoursWeek1, pay, otbonus) 
			 + getPay(hoursWeek2, pay, otbonus);
	}

	int getAvgHours()
	{
		return (getHoursCurPeriod() + getHoursPrvPeriod()) / 2;
	}

	double getAvgPay()
	{
		return (getPayCurPeriod() + getPayPrvPeriod()) / 2.0;
	}
} employee;

typedef vector<employee> employeeList;

void parseHours(ifstream& stream, bool& fail, int& hours)
{
	string val;

	if (getline(stream, val))
	{
		vector<string> hourtoken = Split(',', val);
		if (hourtoken.size() == 7)
		{
			for (int i = 0; i < 7; i++)
			{
				hours += stoi(hourtoken[i]);
			}
		}
		else
			fail = true;
	}
	else
		fail = true;
}

employee fromFile(ifstream& stream, bool& fail)
{
	employee res;
	string val;

	if (getline(stream, val))
	{
		vector<string> nametoken = Split(';', val);
		if (nametoken.size() == 3)
		{
			res.name = nametoken[0];
			res.pay = stod(nametoken[1]);
			res.otbonus = stod(nametoken[2]);

			parseHours(stream, fail, res.hoursWeek1);
			if (!fail) 
				parseHours(stream, fail, res.hoursWeek2);
			if (!fail) 
				parseHours(stream, fail, res.hoursWeek3);
			if (!fail) 
				parseHours(stream, fail, res.hoursWeek4);
		}
		else
			fail = true; // incorrect token count
	}
	else
		fail = true; // no line present

	return res;
}

employeeList retrieveEmployees()
{
	employeeList employees;

	ifstream dataFile(filePath); // Creates ifstream object
	if (dataFile.is_open()) // Ensures file is open
	{
		string line;
		bool fail = false;

		do
		{
			employee res = fromFile(dataFile, fail);
			if (!fail)
				employees.push_back(res);
		} while (!fail);
	}
	else
	{
		cout << "Failed to open file at following location: " << filePath << endl;
	}

	return employees;
}

void repExtremes(employeeList employees)
{
	int idxMaxHours = 0, idxMinHours = 0;
	for (int i = 0; i < employees.size(); i++)
	{
		employee e = employees[i];
		if (e.getHoursCurPeriod() > employees[idxMaxHours].getHoursCurPeriod())
		{
			idxMaxHours = i;
		}
		if (e.getHoursCurPeriod() < employees[idxMinHours].getHoursCurPeriod())
		{
			idxMinHours = i;
		}
	}

	cout << "Employee with lowest hours this period:    " << left << employees[idxMinHours].getName() << endl;
	cout << "Employee with highest hours this period:   " << employees[idxMaxHours].getName() << endl;

	cout << endl;
}

void repTotalAvg(employeeList employees)
{
	int totalHoursCurPeriod = 0;
	int totalHoursPrvPeriod = 0;
	double totalPaidCurPeriod = 0.0;
	double totalPaidPrvPeriod = 0.0;

	for (int i = 0; i < employees.size(); i++)
	{
		employee e = employees[i];

		totalHoursCurPeriod += e.getHoursCurPeriod();
		totalHoursPrvPeriod += e.getHoursPrvPeriod();
		totalPaidCurPeriod += e.getPayCurPeriod();
		totalPaidPrvPeriod += e.getPayPrvPeriod();
	}

	cout << "Total Hours Current Period:      " << right << setw(10) << totalHoursCurPeriod << endl;
	cout << "Total Hours Previous Period:     " << setw(10) << totalHoursPrvPeriod << endl;
	cout << "Average Hours Per Employee:      " << setw(10) << totalHoursPrvPeriod / employees.size() << endl;
	cout << "Total Payment Current Period:    " << setw(10) << totalPaidCurPeriod << endl;
	cout << "Total Payment Previous Period:   " << setw(10) << totalPaidPrvPeriod << endl;
	cout << "Average Payment Per Employee:    " << setw(10) << totalPaidPrvPeriod / employees.size() << endl;

	cout << endl;
}

void repOverview(employeeList employees)
{
	cout << right << setw(15) << "NAME" <<
		setw(10) << "PAY_RATE" <<
		setw(10) << "OT_BONUS" <<
		setw(15) << "CUR_PAY" <<
		setw(10) << "CUR_HOUR" <<
		setw(15) << "PRV_PAY" <<
		setw(10) << "PRV_HOUR" <<
		setw(15) << "AVG_PAY" <<
		setw(10) << "AVG_HOUR" << endl;

	for (int i = 0; i < employees.size(); i++)
	{
		employee e = employees[i];
		cout << 
			setw(15) << e.name << 
			fixed << setprecision(2) << setw(10) << e.pay << 
			setw(10) << e.otbonus << 
			setw(15) << e.getPayCurPeriod() <<
			setw(10) << e.getHoursCurPeriod() <<
			setw(15) << e.getPayPrvPeriod() <<
			setw(10) << e.getHoursPrvPeriod() <<
			setw(15) << e.getAvgPay() <<
			setw(10) << e.getAvgHours() <<
			endl;
	}

	cout << endl;
}

int main()
{
	employeeList employees = retrieveEmployees();

	repOverview(employees);
	repTotalAvg(employees);
	repExtremes(employees);

    system("pause");
    return 0;
}