#include <iostream>
#include "MyList.h"

MyList::MyList()
{
    _head = NULL;
    _tail = NULL;
}

void MyList::put(long num)
{
    PNode temp = CreateNode(num);
    this->AddLast(temp);
}

size_t MyList::Length()
{
    size_t counter = 0;
    PNode q = _head;
    while (q->next)
    {
        counter++;
        q = q->next;
    }
    return counter;
}

std::ostream& operator<< (std::ostream& os, MyList& listOut)
{
    PNode q = listOut._head;
    while (q)
    {
        os << q->x;
        if (q->next)
            os << ", ";
        else
            os << ".";
        q = q->next;
    }
    return os;
}

size_t MyList::CountElemDivBy5OnEvenPos()
{
    bool IsEven = false;
    size_t counter = 0;
    PNode q = _head;
    while (q->next)
    {
        if (IsEven)
            if (q->x % 5 == 0)
                counter++;
        IsEven = !IsEven;
        q = q->next;
    }
    return counter;
}

void MyList::RemoveElementsMoreThanAverage()
{
    PNode q = _head;
    long averageLower = CountAverageLower();
    while (q)
    {
        PNode p = q->next;
        if (q->x > averageLower)
            DeleteNode(q);
        q = p;
    }
}

long MyList::CountAverageLower()
{
    long sum = 0;
    size_t counter = 0;
    PNode q = _head;
    while (q)
    {
        sum += q->x;
        counter++;
        q = q->next;
    }
    return sum / counter;
}

MyList::~MyList()
{
    while (_head)
    {
        _tail = _head->next;
        delete _head;
        _head = _tail;
    }
}

PNode MyList::CreateNode(long num)
{
    PNode newNode = new Node;
    newNode->x = num;
    newNode->next = NULL;
    newNode->prev = NULL;
    return newNode;
}

void MyList::AddLast(PNode newNode)
{
    if (_head == NULL)
    {
        _head = _tail = newNode;
    }
    else
    {
        newNode->prev = _tail;
        _tail->next = newNode;
        _tail = newNode;
    }
}

void MyList::DeleteNode(PNode p)
{
    PNode q = _head;
    if (_head == p)
    {
        _head = p->next;
    }
    else
    {
        while (q && q->next != p)
        {
            q = q->next;
        }
        if (q != NULL)
            q->next = p->next;
    }
    delete p;
}