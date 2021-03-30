#include <iostream>
#include <iomanip>
#include "Romb.h"

using std::cout;
using std::cin;
using std::endl;

int main()
{
    Romb R2;
    double crdsR2[4][2] = { {0.0, 4.0}, {-2.0, 0.0}, {0.0, -4.0}, {2.0, 0.0} };
    double** coordsR2 = new double* [4];
    for (size_t i = 0; i < 4; i++)
    {
        coordsR2[i] = new double[2];
        for (size_t j = 0; j < 2; j++)
        {
            coordsR2[i][j] = crdsR2[i][j];
        }
    }
    Romb R3 = coordsR2;
    cout << "Coords of R2:\n" << R2 << endl;
    cout << "Coords of R3:\n" << R3 << endl << endl;

    R3 = R3 * 2;

    Romb R1 = R3 - R2;

    cout << "Coords of R1:\n" << R1 << endl;
    cout << "Perimeter of R1: " << R1.GetPerimeter() << endl;
    cout << "Square of R1: " << R1.GetSquare() << endl;
    double* Angles = R1.GetAngles();
    cout << "Angles of R1: " << std::setw(7) << std::fixed << std::setprecision(2) << Angles[0] << " " << std::setw(7) << std::fixed << std::setprecision(2) << Angles[1] << endl;
    cout << std::defaultfloat;
    cout << "Side of R1: " << R1.GetSide() << endl;

    system("pause");
    return 0;
}