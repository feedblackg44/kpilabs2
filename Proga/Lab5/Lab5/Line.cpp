#include <iostream>
#include <cmath>
#include "Line.h"

Line::Line(float coord1, float coord2, float coord3, float coord4)
{
    _coords = new float*[2];
    _coords[0] = new float[2];
    _coords[1] = new float[2];
    _coords[0][0] = coord1;
    _coords[0][1] = coord2;
    _coords[1][0] = coord3;
    _coords[1][1] = coord4;
}

float Line::Length()
{
    return sqrt(pow((_coords[1][0] - _coords[0][0]), 2) + pow((_coords[1][1] - _coords[0][1]), 2));
}

Line::~Line()
{
    for (size_t i = 0; i < 2; i++)
    {
        delete[] _coords[i];
    }
    delete[] _coords;
}