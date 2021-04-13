#include <iostream>
#include <cmath>
#include "Segment.h"

Segment::Segment(float coord1, float coord2, float coord3, float coord4)
    : Line(coord1, coord2, coord3, coord4)
{
    _coords[1][0] -= _coords[0][0];
    _coords[1][1] -= _coords[0][1];
    _coords[0][0] -= _coords[0][0];
    _coords[0][1] -= _coords[0][1];
}

void Segment::RestrictByFive()
{
    float curLength = this->Length();
    float diff = curLength / (curLength - 5);
    _coords[1][0] /= diff;
    _coords[1][1] /= diff;
}

float** Segment::GetCoords()
{
    return this->_coords;
}