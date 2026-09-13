#include <iostream>
#include <fstream>
#include <vector>
#include <sstream>
#include <iomanip>

using namespace std;

// Define the classes

class Name {
public: //SC1
    Name(const string& first, const string& last) : firstName(first), lastName(last) {}
    string getFullName() const {
        return firstName + " " + lastName;  //SC2
    }
private: //SC3
    string firstName;
    string lastName;
};

class CarInfo {
public:  //SC4
    CarInfo(const string& make, const string& model, const string& plate)
        : carMake(make), carModel(model), licensePlate(plate) {}
    string getInfo() const {
        return carMake + " " + carModel + " " + licensePlate;
    }
private:  //SC6
    string carMake;
    string carModel;
    string licensePlate;
};

class Payment {
public: //SC7
    Payment(double ticketPayment, const string& creditCard) : ticketPayment(ticketPayment), creditCardNumber(creditCard) {}
    string getPaymentInfo() const {
        stringstream ss; //8
        ss << "$" << fixed << setprecision(2) << ticketPayment << " " << creditCardNumber;
        return ss.str();
    }
private: //SC9
    double ticketPayment;
    string creditCardNumber;
};

class Customer {
public: //SC10
    Customer(const Name& n, const CarInfo& c, const Payment& p) : name(n), carInfo(c), payment(p) {}
    void printInfo() const {  //SC11
        cout << "Name: " << name.getFullName() << endl;
        cout << "Car Information: " << carInfo.getInfo() << endl;
        cout << "Speeding Ticket Payment: " << payment.getPaymentInfo() << endl;
        cout << endl;
    }
private:  //SC12
    Name name;
    CarInfo carInfo;
    Payment payment;
};

// Driver class
class TicketDriver {
public:
    void run() { //SC13
        readDataFromFile();
        printRecords();
    }

private:
    void readDataFromFile() {  //SC14
        ifstream file("Names.txt");
        if (!file.is_open()) {
            cerr << "Error opening file." << endl;
            return;
        }

        string line;
        while (getline(file, line)) {
            stringstream ss(line);
            string firstName, lastName, carMake, carModel, licensePlate, creditCardNumber;
            double ticketPayment;

            if (getline(ss, firstName, ',') && getline(ss, lastName, ',') &&  //SC15
                getline(ss, carMake, ',') && getline(ss, carModel, ',') &&
                getline(ss, licensePlate, ',') && ss >> ticketPayment && ss.ignore() &&
                getline(ss, creditCardNumber)) {
                Name name(firstName, lastName);
                CarInfo carInfo(carMake, carModel, licensePlate);
                Payment payment(ticketPayment, creditCardNumber);
                customers.emplace_back(name, carInfo, payment);
            }
            else {
                cerr << "Error parsing line: " << line << endl;  //SC16
            }
        }

        file.close();  //SC17
    }
    void printRecords() const {
        int lineNumber = 1;
        cout << "*************************************" << endl;
        cout << "**   BPA Speeding Ticket Database  **" << endl;
        cout << "*************************************" << endl;
        cout << "*************************************" << endl;
        cout << "                                    " << endl;
        
        for (const auto& customer : customers) {
            cout << "**********>>>  " << setw(2) << lineNumber << "  <<<***************" << endl;  //SC19
            customer.printInfo();  //SC18
            lineNumber++;
        }
        cout << "***********************************" << endl;
    }

    vector<Customer> customers;
};

int main() {
    TicketDriver driver;
    driver.run();
    return 0;
}
