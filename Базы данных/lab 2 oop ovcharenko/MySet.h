#pragma once
#include <string>
#include <vector>
#include <array>
using namespace std;

class MySet {
private:
	// ����, �� ������ �������� �������
	array<int,1000> set;
public:
	// ������� �������� � ������
	int count;
	// ����������� �����������
	MySet();
	// ����������� � ����������
	MySet(vector<int>);
	//����������� ���������
	MySet(const MySet&);
	//�������������� ��������� =
	MySet& operator=(MySet&);
	// �������������� ��������� ����������
	int& operator[](const int);
	//�������� �� ��, �� � ������� � ����� ���������
	// � ������� ������
	bool Contains(int);
	//��������� �������� �� �������
	void Add(int);
	//��������� �������� � �������
	void Delete(int);
	//��'������� ���� ������
	MySet Union(MySet);
	//������� ���� ������
	MySet Intersection(MySet);
	//�������������� ��������� ������ ������
	friend std::ostream& operator<< (std::ostream& out, MySet);
	//�������������� ��������� ������ �����
	friend std::istream& operator>> (std::istream& in, MySet&);
};