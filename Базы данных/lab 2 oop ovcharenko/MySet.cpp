#include <string>
#include "MySet.h"
#include <vector>
#include <iostream>

using namespace std;

MySet::MySet()
{
	count = 0;
}
MySet::MySet(vector<int> newMySet)
{
	for (size_t i = 0; i < newMySet.size(); i++)
	{
		set[i] = newMySet[i];
	}
	count = newMySet.size();
}
MySet::MySet(const MySet& anotherMySet)
{
	count = anotherMySet.count;
	set = anotherMySet.set;
}

int& MySet::operator[](int element)
{
	return set[element];
}

MySet& MySet::operator=(MySet& s)
{
	count = s.count;
	for (int i = 0; i < s.count; i++)
	{
		set[i] = s[i];
	}
	return *this;
}
bool MySet::Contains(int element)
{
	for (int i = 0; i < count; i++)
	{
		if (set[i] == element)
		{
			return true;
		}
	}
	return false;
}

void MySet::Add(int element)
{
	if (!Contains(element))
	{
		set[count]=element;
		count++;
	}
	else
	{
		cout << "MySet already has this element\n";
	}
}
void MySet::Delete(int element)
{
	if (Contains(element))
	{
		int index;
		for ( index = 0; index < count; index++)
		{
			if (set[index] == element)
			{
				break;
			}
		}
		if (index == count - 1)
		{
			count--;
			return;
		}
		for (int i = index + 1; i < count; i++) 
		{
			set[index - 1] = set[index];
			count--;
		}
	}
	else {
		cout << "MySet does not contain this element! \n";
	}
}

MySet MySet::Union(MySet set1)
{

	for (int i = 0; i < set1.count; i++) {
		if (!Contains(set1[i])) {
			Add(set1[i]);
		}
	}
	return *this;
}

MySet MySet::Intersection(MySet set1)
{
	MySet newMySet;
	if (count >= set1.count) {
		for (int i = 0; i < set1.count; i++) {
			if (Contains(set1[i])) {
				newMySet.Add(set[i]);
			}
		}

	}
	else {
		for (int i = 0; i < this->count; i++) {
			if (set1.Contains(this->set[i])) {
				newMySet.Add(set1[i]);
			}
		}
	}
	return newMySet;
}

std::ostream& operator<< (std::ostream& out, MySet set)
{
	out << set.count << " ";
	for (int i = 0; i < set.count; i++) {
		out << set.set[i];
		if (set.count - 1 != i) { out << " "; }
	}
	return out;
}
std::istream& operator>> (std::istream& in, MySet &set)
{
	int count = 0;
	in >> count;
	for (int i = 0; i < count; i++) {
		int x;
		in >> x;
		set.Add(x);
	}
	return in;
}