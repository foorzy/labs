#pragma once
#include <string>
#include <vector>
#include <array>
using namespace std;

class MySet {
private:
	// поле, що утримує елементи множини
	array<int,1000> set;
public:
	// кількість елементів в множині
	int count;
	// стандартний конструктор
	MySet();
	// конструктор з параметром
	MySet(vector<int>);
	//конструктор копіювання
	MySet(const MySet&);
	//перевантаження оператора =
	MySet& operator=(MySet&);
	// перевантаження оператора індексації
	int& operator[](const int);
	//перевірка на те, чи є елемент з таким значенням
	// у поточній множині
	bool Contains(int);
	//додавання елемента до множини
	void Add(int);
	//видалення елемента з множини
	void Delete(int);
	//об'єднання двох множин
	MySet Union(MySet);
	//перетин двох множин
	MySet Intersection(MySet);
	//перевантаження оператора потоку вивода
	friend std::ostream& operator<< (std::ostream& out, MySet);
	//перевантаження оператора потоку ввода
	friend std::istream& operator>> (std::istream& in, MySet&);
};