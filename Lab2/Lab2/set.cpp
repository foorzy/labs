#include <string>
#include "set.h"
#include <vector>
#include <iostream>

using namespace std;

Set::Set()
{
	count = 0;
}
Set::Set(vector<int> newSet)
{
	set = newSet;
}
Set::Set(const Set& anotherSet)
{
	count = anotherSet.count;
	set = anotherSet.set;
}

int& Set::operator[](int element)
{
	return set[element];
}

Set& Set::operator=(Set& s)
{
	count = s.count;
	for (int i = 0; i < s.count; i++)
	{
		set[i] = s[i];
	}
	return *this;
}
bool Set::Contains(int element)
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

void Set::Add(int element)
{
	if (!Contains(element))
	{
		set.push_back(element);
		count++;
	}
	else
	{
		cout << "Set already has this element\n";
	}
}
void Set::Delete(int element)
{
	if (Contains(element))
	{
		for (int i = 0; i < count; i++) {
			if (set[i] == element) {
				set.erase(set.begin() + i);
				count--;
			}
		}
	}
	else {
		cout << "Set does not contain this element! \n";
	}
}

Set Set::Union(Set set1)
{

	for (int i = 0; i < set1.count; i++) {
		if (!Contains(set1[i])) {
			Add(set1[i]);
		}
	}
	return *this;
}

Set Set::Intersection(Set set1)
{
	Set newSet;
	if (count >= set1.count) {
		for (int i = 0; i < set1.count; i++) {
			if (Contains(set1[i])) {
				newSet.Add(set[i]);
			}
		}
		
	}
	else {
		for (int i = 0; i < this->count; i++) {
			if (set1.Contains(this->set[i])) {
				newSet.Add(set1[i]);
			}
		}
	}
	return newSet;
}

std::ostream& operator<< (std::ostream& out, Set set)
{
	out << set.count << " ";
	for (int i = 0; i < set.count; i++) {
		out << set.set[i];
		if (set.count - 1 != i) { out << " "; }
	}
	return out;
}
std::istream& operator>> (std::istream& in, Set &set)
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
