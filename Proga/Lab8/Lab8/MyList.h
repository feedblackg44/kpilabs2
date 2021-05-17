#pragma once
#include <iostream>

struct Node
{
    long x;
    Node* next;
    Node* prev;
};

typedef Node* PNode;

class MyList
{
public:
    MyList();

    size_t Length();
    void put(long num);
    size_t CountElemDivBy5OnEvenPos();
    void RemoveElementsMoreThanAverage();
    long CountAverageLower();

    friend std::ostream& operator<< (std::ostream&, MyList&);
    
    ~MyList();

private:
    PNode _head,
          _tail;

    PNode CreateNode(long num);
    void AddLast(PNode newNode);
    void DeleteNode(PNode p);
};