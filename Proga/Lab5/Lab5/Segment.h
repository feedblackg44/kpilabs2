#pragma once
#include "Line.h"
class Segment : public Line
{
public:
    Segment(float, float, float, float);

    void RestrictByFive();

    float** GetCoords();
};

