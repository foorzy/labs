#pragma once
#include <string>
#include <vector>
using namespace std;

class Set{
private:
	// поле, що утримує елементи множини
	vector<int> set;
public:
	// кількість елементів в множині
	int count;
	// стандартний конструктор
	Set();
	// конструктор з параметром
	Set(vector<int>);
	//конструктор копіювання
	Set(const Set&);
	//перевантаження оператора =
	Set& operator=(Set&);
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
	Set Union(Set);
	//перетин двох множин
	Set Intersection(Set);
	//перевантаження оператора потоку вивода
	friend std::ostream& operator<< (std::ostream& out, Set);
	//перевантаження оператора потоку ввода
	friend std::istream& operator>> (std::istream& in, Set&);
};