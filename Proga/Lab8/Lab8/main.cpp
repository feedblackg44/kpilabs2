#include <iostream>
#include <ctime>
#include "MyList.h"

using std::cin;
using std::cout;
using std::endl;

int main()
{
    MyList list1 = MyList();

    srand(time(NULL));

    for (long i = 0; i < 20; i++)
    {
        long current = rand() % 20 + 1;
        list1.put(current);
    }

    cout << "Genereated list: " << list1 << endl;

    cout << "\nAmount of elements that stands on even positions and can be divided by 5: " << list1.CountElemDivBy5OnEvenPos() << endl;

    long avg = list1.CountAverageLower();
    list1.RemoveElementsMoreThanAverage();

    cout << "\nAverage rounded to lower of this list is: " << avg << "\nThe modified list is: " << list1 << endl;

    system("pause");
    return 0;
}