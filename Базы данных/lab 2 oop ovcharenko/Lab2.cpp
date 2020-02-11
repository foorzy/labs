#include <iostream>
#include <fstream>
#include "MySet.h"
#include"Header.h"

using namespace std;

enum Operation
{
	Add,
	Delete,
	Contains,
	Union,
	Intersection,
	Indexation,
	FileRead,
	FileWrite
};

void ExecuteOperation(Operation op)
{
	MySet first, second;
	bool fl = false;
	ifstream in;
	ofstream out;
	MySet set;
	int a;
	switch (op)
	{
	case Add:
		cout << "Input set(size elements): ";
		cin >> set;
		cout << "Input a: ";
		cin >> a;
		set.Add(a);
		cout << "Result: " << set << endl;
		break;
	case Contains:
		cout << "Input set(size elements): ";
		cin >> set;
		cout << "Input a: ";
		cin >> a;
		if (set.Contains(a))
			cout << "CONTAINS" << endl;
		else
			cout << "DOES NOT CONTAIN" << endl;
		break;
	case Delete:
		cout << "Input set(size elements): ";
		cin >> set;
		cout << "Input a: ";
		cin >> a;
		set.Delete(a);
		cout << "Result: " << set << endl;
		break;
	case Union:
		cout << "Input set 1(size elements): ";
		cin >> first;
		cout << "Input set 2(size elements): ";
		cin >> second;
		cout << "Union set1 + set2: " << first.Union(second) << endl;
		break;
	case Intersection:
		cout << "Input set 1(size elements): ";
		cin >> first;
		cout << "Input set 2(size elements): ";
		cin >> second;
		cout << "Intersection set1 and set2: " << first.Intersection(second) << endl;
		break;
	case Indexation:
		int i, a;
		cout << "Input set(size elements): ";
		cin >> set;
		cout << "Input i: ";
		cin >> i;
		cout << "Input a: ";
		cin >> a;
		set[i] = a;
		cout << "Result: " << set << endl;
		break;
	case FileWrite:
		cout << "Input set(size elements): ";
		cin >> set;
		cout << "Writing to file..." << endl;
		out = ofstream("sets.txt"); // окрываем файл для записи
		if (out.is_open())
		{
			out << set << endl;
		}
		break;
	case FileRead:
		cout << "Reading from file..." << endl;
		MySet s;
		in = ifstream("sets.txt"); // окрываем файл для записи
		if (in.is_open())
		{
			in >> s;
		}
		cout << "Result: " << s << endl;
		break;
	}
}



int main()
{
	bool flag = true;
	do
	{
		lab3::PrintMessege();
		cout << "Choose the operation" << endl;
		cout << "1. Add" << endl;
		cout << "2. Delete" << endl;
		cout << "3. Contains" << endl;
		cout << "4. Union" << endl;
		cout << "5. Intersection" << endl;
		cout << "6. Indexation" << endl;
		cout << "7. File Write" << endl;
		cout << "8. File Read" << endl;
		cout << "9. Exit" << endl;

		int operation;
		cin >> operation;

		if (!cin)
		{
			cout << "Invalid operation" << endl;
			break;
		}

		switch (operation)
		{
		case 1:
			ExecuteOperation(Add);
			break;
		case 2:
			ExecuteOperation(Delete);
			break;
		case 3:
			ExecuteOperation(Contains);
			break;
		case 4:
			ExecuteOperation(Union);
			break;
		case 5:
			ExecuteOperation(Intersection);
			break;
		case 6:
			ExecuteOperation(Indexation);
			break;
		case 7:
			ExecuteOperation(FileWrite);
			break;
		case 8:
			ExecuteOperation(FileRead);
			break;
		case 9:
			flag = false;
			break;
		default:
			cout << "Invalid operation" << endl;
			break;
		}
	} while (flag);
	return 0;
}