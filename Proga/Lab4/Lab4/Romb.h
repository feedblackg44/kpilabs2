#pragma once

class Romb {
public:
    Romb();

    Romb(Romb&);
    
    Romb(double**);
    
    double GetPerimeter();
    
    double GetSquare();
    
    double GetSide();
    
    double* GetAngles();

    friend std::ostream& operator<<(std::ostream&, const Romb&);
    
    friend Romb& operator*(const Romb&, double);
    
    friend Romb& operator-(const Romb&, const Romb&);

private:
    double coords[4][2];
    double side;

    bool IsCoordsCorrect(double**);

    double GetVectorDistance(double[2], double[2]);
};