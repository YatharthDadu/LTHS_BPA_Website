#ifndef List_h
#define List_h

#include <iostream>
#include <fstream> // Allows file IO
#include <string> // Allows use of string
#include <vector> // Allows use of vectors
#include <iomanip> // Allows manipulation of output
#include <sstream> // Allows for easy string parsing
#include "Library.h" // Allows access to general methods

using namespace std;

template <class T>
class List
{
private:
	T* array; // The container of type T
public:
	int elementCount; // Stores number of elements
	int maxSize; // Stores current capacity of list

	// Allows the object to be indexed
	T& operator[] (int x) { return array[x]; }

	// Default constructor, with size set to 10
	// if no value is passed with it
	List(int newSize = 10)
	{
		Initialize(newSize);
	}

	// Initializes list as an empty
	// array with newSize elements
	void Initialize(int newSize)
	{
		array = new T[newSize];
		maxSize = newSize;
		elementCount = 0;
	}

	// Returns number of elements
	int GetCount()
	{
		return elementCount;
	}

	// Frees up dynamically allocated memory
	~List()
	{
		delete[] array;
	}

	// Inserts a new item
	void Insert(T newItem)
	{
		// Inserts new value at end
		array[elementCount] = newItem;
		elementCount++;
	}
};

#endif