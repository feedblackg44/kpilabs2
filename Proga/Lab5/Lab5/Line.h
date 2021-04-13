#pragma once
class Line
{
protected:
    float** _coords;
public:
    Line(float coord1, float coord2, float coord3, float coord4);

    float Length();

    ~Line();
};

