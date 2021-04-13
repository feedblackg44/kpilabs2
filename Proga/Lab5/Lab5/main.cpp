#include <iostream>
#include "Line.h"
#include "Segment.h"

using std::cout;
using std::cin;
using std::endl;

int main()
{
    Segment seg = Segment(1, 1, 7, 9);

    cout << "Current Length: " << seg.Length() << endl;
    float** curCoords = seg.GetCoords();
    cout << "Current Coords:" << endl;
    for (size_t i = 0; i < 2; i++)
    {
        cout << "\t";
        for (size_t j = 0; j < 2; j++)
        {
            cout << curCoords[i][j] << " ";
        }
        cout << endl;
    }

    seg.RestrictByFive();
    cout << "\nSegment restricted by 5\n" << endl;

    cout << "Current Length: " << seg.Length() << endl;
    curCoords = seg.GetCoords();
    cout << "Current Coords:" << endl;
    for (size_t i = 0; i < 2; i++)
    {
        cout << "\t";
        for (size_t j = 0; j < 2; j++)
        {
            cout << curCoords[i][j] << " ";
        }
        cout << endl;
    }

    system("pause");
    return 0;
}