#include <iostream>
#include <iomanip>
#include <cmath>
#include "Romb.h"

Romb::Romb()
{
    this->coords[0][0] = 0.0;   this->coords[0][1] = 1.0;
    this->coords[1][0] = -1.0;  this->coords[1][1] = 0.0;
    this->coords[2][0] = 0.0;   this->coords[2][1] = -1.0;
    this->coords[3][0] = 1.0;   this->coords[3][1] = 0.0;
    this->side = GetVectorDistance(this->coords[0], this->coords[1]);
}

Romb::Romb(Romb& copyFrom)
{
    for (size_t i = 0; i < 4; i++)
    {
        for (size_t j = 0; j < 2; j++)
        {
            this->coords[i][j] = copyFrom.coords[i][j];
        }
    }
    this->side = copyFrom.side;
}

Romb::Romb(double** arr)
{
    if (IsCoordsCorrect(arr))
    {
        for (size_t i = 0; i < 4; i++)
        {
            for (size_t j = 0; j < 2; j++)
            {
                this->coords[i][j] = arr[i][j];
            }
        }
        this->side = GetVectorDistance(this->coords[0], this->coords[1]);
    }
}

double Romb::GetPerimeter()
{
    return this->side * 4;
}

double Romb::GetSquare()
{
    double d1 = GetVectorDistance(this->coords[0], this->coords[2]);
    double d2 = GetVectorDistance(this->coords[1], this->coords[3]);

    return d1 * d2 * 0.5;
}

double Romb::GetSide()
{
    return this->side;
}

double* Romb::GetAngles()
{
    double d1 = GetVectorDistance(this->coords[0], this->coords[2]);
    double d2 = GetVectorDistance(this->coords[1], this->coords[3]);

    double* angles = new double[2];
    angles[0] = 2 * atan(d1 / d2) / acos(-1) * 180;
    angles[1] = 180 - angles[0];

    return angles;
}

std::ostream& operator<<(std::ostream& os, const Romb& rombikOut)
{
    for (size_t i = 0; i < 4; i++)
    {
        for (size_t j = 0; j < 2; j++)
        {

            os << std::setw(5) << std::fixed << std::setprecision(2) << rombikOut.coords[i][j];
            if (j != 1)
                os << " ";
            os << std::defaultfloat;
        }
        if (i != 3)
            os << std::endl;
    }
    return os;
}

Romb& operator*(const Romb& rombik, double multip)
{
    Romb* rombikOut = new Romb();
    for (size_t i = 0; i < 4; i++)
    {
        for (size_t j = 0; j < 2; j++)
        {
            (*rombikOut).coords[i][j] = multip * rombik.coords[i][j];
        }
    }
    (*rombikOut).side = rombikOut->GetVectorDistance((*rombikOut).coords[0], (*rombikOut).coords[1]);
    return *rombikOut;
}

Romb& operator-(const Romb& rombik1, const Romb& rombik2)
{
    Romb* rombikOut = new Romb();
    for (size_t i = 0; i < 4; i++)
    {
        for (size_t j = 0; j < 2; j++)
        {
            (*rombikOut).coords[i][j] = rombik1.coords[i][j] - rombik2.coords[i][j];
        }
    }
    (*rombikOut).side = rombikOut->GetVectorDistance((*rombikOut).coords[0], (*rombikOut).coords[1]);
    return *rombikOut;
}

bool Romb::IsCoordsCorrect(double** coords)
{
    if (GetVectorDistance(coords[0], coords[1]) - GetVectorDistance(coords[1], coords[2]) < 0.000001 &&
        GetVectorDistance(coords[1], coords[2]) - GetVectorDistance(coords[2], coords[3]) < 0.000001 &&
        GetVectorDistance(coords[2], coords[3]) - GetVectorDistance(coords[3], coords[0]) < 0.000001 &&
        GetVectorDistance(coords[3], coords[0]) - GetVectorDistance(coords[0], coords[1]) < 0.000001)
        return true;
    else
    {
        std::cout << "Error parsing coordinates!" << std::endl;
        system("pause");
        exit(1);
    }
}

double Romb::GetVectorDistance(double pos1[2], double pos2[2])
{
    double vec[2] = { pos2[0] - pos1[0], pos2[1] - pos1[1] };
    return double(sqrt(vec[0] * vec[0] + vec[1] * vec[1]));
}