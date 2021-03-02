#include <iostream>
#include "functions.h"

using namespace std;

int main()
{
    int size = 4;

    int* numbersX = new int[size];
    fillInSeq(numbersX, size);

    float** A = createMatrix(size);
    //fillRandom(A, size);
    matrix4Init(A);
    print(A, size);

    float* B = createVec(size);
    //fillRandom(B, size);
    vector4Init(B);
    print(B, size);

    float* X = createVec(size);

    gaussAlgorithmTriangle(A, B, numbersX, size);

    gaussAlgorithmGetSolution(A, B, numbersX, X, size);

    cout << "\n\nSolution vector X: ";
    print(X, size);

    matrix4Init(A);
    vector4Init(B);

    cout << "\nr = b - Ax:\n";
    print(vecDelta(A, B, X, size), size);

    system("pause");
    return 0;
}