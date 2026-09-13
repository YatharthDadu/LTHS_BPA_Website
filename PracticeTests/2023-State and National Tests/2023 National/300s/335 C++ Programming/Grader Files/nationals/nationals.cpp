#include <iostream>
#include <vector>
#include <map>
#include <fstream>
#include <string>
#include <sstream>
#include <iomanip>

using namespace std;

const string itemDataPath = "itemdata.txt";

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

class item
{
public:
    item() { name = ""; qty = 0; }
    item(string newName, int newQty)
    {
        name = newName;
        qty = newQty;
    }

    string getName()
    {
        return name;
    }

    int getQty()
    {
        return qty;
    }
private:
    string name;
    int qty;
};

struct itemValPair
{
    item itm;
    int val;

    itemValPair() { itm = item(); val = 0; }
    itemValPair(item newItm, int newVal)
    {
        itm = newItm;
        val = newVal;
    }
};

class itemList
{
public:
    itemValPair retrievePair(string itemName)
    {
        return items[itemName];
    }

    void loadInventory(string fileName)
    {
        string line;
        ifstream dataFile(fileName);
        while (getline(dataFile, line))
        {
            vector<string> itemTokens = Split(',', line);
            itemTokens[1].erase(remove(itemTokens[1].begin(), itemTokens[1].end(), '\"'), itemTokens[1].end());

            int val = stoi(itemTokens[2]);
            int qty = stoi(itemTokens[0]);

            items.insert(make_pair(itemTokens[1], itemValPair(item(itemTokens[1], val), qty)));
        }
    }
private:
    map<string, itemValPair> items;
};

class investment
{
public:
    investment(string newName)
    {
        newName.erase(remove(newName.begin(), newName.end(), '\"'), newName.end());
        invName = newName;
    }

    void addItemNeeded(string source)
    {
        source.erase(remove(source.begin(), source.end(), '\"'), source.end());
        vector<string> itmToken = Split(';', source);
        item itm(itmToken[1], stoi(itmToken[0]));
        itemsRequired.push_back(itm);
    }

    void addItemProduced(string source)
    {
        source.erase(remove(source.begin(), source.end(), '\"'), source.end());
        vector<string> itmToken = Split(';', source);
        item itm(itmToken[1], stoi(itmToken[0]));
        itemsProduced.push_back(itm);
    }

    void getValue(itemList inv, int& requiredVal, int& producedVal, int& repeatCnt)
    {
        int repeat = -1;

        for (int i = 0; i < itemsRequired.size(); i++)
        {
            item itm = itemsRequired[i];
            itemValPair pair = inv.retrievePair(itm.getName()); // lookup value of item in inventory
            requiredVal += pair.val * itm.getQty(); // retrieve necessary quantity

            int countInv = pair.itm.getQty();

            if (countInv >= itm.getQty())
            {
                int newRep = countInv / itm.getQty();

                if (newRep < repeat || repeat == -1)
                {
                    repeat = newRep;
                }
            }
            else
            {
                repeat = 0;
            }
        }

        for (int i = 0; i < itemsProduced.size(); i++)
        {
            item itm = itemsProduced[i];
            itemValPair pair = inv.retrievePair(itm.getName()); // lookup value of item
            producedVal += pair.val * itm.getQty(); // retrieve necessary quantity
        }

        repeatCnt = repeat;
    }

    string getName()
    {
        return invName;
    }

private:
    string invName;
    vector<item> itemsRequired;
    vector<item> itemsProduced;
};

void loadOpportunities(vector<investment>& oppList, string filePath)
{
    string line;
    ifstream dataFile(filePath);

    while (getline(dataFile, line))
    {
        if (!line.empty())
        {
            investment inv(line);

            while (getline(dataFile, line))
            {
                if (!line.empty())
                {
                    if (line[0] == '-')
                    {
                        inv.addItemNeeded(line.erase(0, 1));
                    }
                    else if (line[0] == '+')
                    {
                        inv.addItemProduced(line.erase(0, 1));
                    }
                }
                else
                {
                    break;
                }
            }

            oppList.push_back(inv);
        }
    }
}

void reportOpportunities(vector<investment> opps, itemList inv)
{
    cout
        << right << setw(25) << "INV_NAME"
        << setw(15) << "REQ_VAL($)"
        << setw(15) << "PROD_VAL($)"
        << setw(15) << "PROFIT($)"
        << setw(15) << "REP_CNT"
        << setprecision(4) << fixed << setw(15) << "PROFIT(%)" << endl;

    for (int i = 0; i < opps.size(); i++)
    {
        investment op = opps[i];

        int requiredVal = 0;
        int producedVal = 0;
        int repeatCnt = 0;
        double profitMargin = 0.0;

        op.getValue(inv, requiredVal, producedVal, repeatCnt);

        profitMargin = (static_cast<double>(producedVal) / static_cast<double>(requiredVal));

        cout
            << fixed << right << setw(25) << op.getName()
            << setprecision(2) << setw(15) << static_cast<double>(requiredVal) / 100.0
            << setprecision(2) << setw(15) << static_cast<double>(producedVal) / 100.0
            << setprecision(2) << setw(15) << static_cast<double>(producedVal-requiredVal) / 100.0
            << setw(15) << repeatCnt
            << setprecision(4) << setw(15) << profitMargin << endl;
    }
}

int main()
{
    itemList availableInventory;
    vector<investment> opportunities;

    availableInventory.loadInventory("itemdata.txt");
    loadOpportunities(opportunities, "investments.txt");

    reportOpportunities(opportunities, availableInventory);

    system("pause");
    return 0;
}