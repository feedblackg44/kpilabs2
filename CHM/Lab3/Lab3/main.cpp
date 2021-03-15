#include <iostream>
#include "functions.h"

using namespace std;

int main()
{
    int size = 5;

    int* numbersX = new int[size];
    fillInSeq(numbersX, size);

    double** A = createMatrix(size);
    matrix5Init(A);
    cout << "Matrix after 1 gauss step:\n";
    print(A, size);

    double* B = createVec(size);
    vector5Init(B);
    cout << "The right vec of matrix:\n";
    print(B, size);

    double* X = createVec(size);
    vector5Init(X);

    zeidelMethodSolve(A, B, X, size);

    cout << "\nRes vector is:\n";
    print(X, size);

    cout << "\nr = b - Ax:\n";
    print(vecDelta(A, B, X, size), size, 15);

    system("pause");
    return 0;
}