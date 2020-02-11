#pragma once
#include <string>
#include <vector>
using namespace std;

class Set{
private:
	// ����, �� ������ �������� �������
	vector<int> set;
public:
	// ������� �������� � ������
	int count;
	// ����������� �����������
	Set();
	// ����������� � ����������
	Set(vector<int>);
	//����������� ���������
	Set(const Set&);
	//�������������� ��������� =
	Set& operator=(Set&);
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
	Set Union(Set);
	//������� ���� ������
	Set Intersection(Set);
	//�������������� ��������� ������ ������
	friend std::ostream& operator<< (std::ostream& out, Set);
	//�������������� ��������� ������ �����
	friend std::istream& operator>> (std::istream& in, Set&);
};