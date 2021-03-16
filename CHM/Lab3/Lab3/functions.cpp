#include <iostream>
#include <iomanip>
#include "functions.h"

using namespace std;

double** createMatrix(int size)
{
    double** matrix = new double* [size];
    for (int i = 0; i < size; i++)
    {
        matrix[i] = new double[size];
    }
    return matrix;
}

double* createVec(int size)
{
    double* vector = new double[size];
    return vector;
}

void fillInSeq(int* Vector, int size)
{
    for (int i = 0; i < size; i++)
    {
        Vector[i] = i;
    }
}

void matrix5Init(double** M)
{
    M[0][0] = 5.032773; M[0][1] = 0.791452; M[0][2] = 0.0;  M[0][3] = 1.120082; M[0][4] = 0.586688;
    M[1][0] = 0.791452; M[1][1] = 3.546819; M[1][2] = 0.0;  M[1][3] = 0.123866; M[1][4] = 0.367031;
    M[2][0] = 0.95;     M[2][1] = 2.12;     M[2][2] = 6.13; M[2][3] = 1.29;     M[2][4] = 1.57;
    M[3][0] = 1.120082; M[3][1] = 0.123866; M[3][2] = 0.0;  M[3][3] = 4.298532; M[3][4] = 0.919608;
    M[4][0] = 0.586688; M[4][1] = 0.367031; M[4][2] = 0.0;  M[4][3] = 0.919608; M[4][4] = 4.807896;
}

void vector5Init(double* V)
{
    V[0] = 5.5267;
    V[1] = 1.7298;
    V[2] = 4.28;
    V[3] = 5.34931;
    V[4] = 3.85382;
}

void print(double** Matrix, int size)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            cout << fixed << setw(12) << setprecision(6) << Matrix[i][j] << " ";
        }
        cout << "\n" << endl;
    }
    cout << defaultfloat;
}

void print(double* Vector, int size, int prec)
{
    for (int i = 0; i < size; i++)
    {
        cout << fixed << setw(prec + 6) << setprecision(prec) << Vector[i] << " ";
    }
    cout << endl;
    cout << defaultfloat;
}

void print(double number)
{
    cout << fixed << setw(21) << setprecision(15) << number << endl;
    cout << defaultfloat;
}

double sumOfMatrixElements(double** matrix, double* X, int firstNum, int secondNum, int i)
{
    double sum = 0.0;

    for (int j = firstNum; j < secondNum; j++)
    {
        sum += matrix[i][j] / matrix[i][i] * X[j];
    }

    return sum;
}

void zeidelMethodSolve(double** matrix, double* B, double* X, int size)
{
    double* tempX = new double[size];
    double e = 0.000001;
    do
    {
        copyVec(X, tempX, size);
        for (int i = 0; i < size; i++)
        {
            X[i] = -sumOfMatrixElements(matrix, X, 0, i, i) - sumOfMatrixElements(matrix, tempX, i + 1, size, i) + B[i] / matrix[i][i];
        }
        print(X, size);
    } while (maxInArrays(X, tempX, size) >= e);
}

double maxInArrays(double* arr1, double* arr2, int size)
{
    double max = abs(arr1[0] - arr2[0]);
    for (int i = 1; i < size; i++)
    {
        if (abs(arr1[i] - arr2[i]) > max)
            max = abs(arr1[i] - arr2[i]);
    }
    return max;
}

void copyVec(double* vecCopyFrom, double* vecToCopy, int size)
{
    for (int i = 0; i < size; i++)
    {
        vecToCopy[i] = vecCopyFrom[i];
    }
}

double* MatrixVecMult(double** matrix1, double* matrix2, int size)
{
    double* outMatrix = new double[size];

    for (int i = 0; i < size; i++)
    {
        outMatrix[i] = 0;
        for (int k = 0; k < size; k++)
        {
            outMatrix[i] += matrix1[i][k] * matrix2[k];
        }
    }

    return outMatrix;
}

double* vecDelta(double** Matrix, double* rightVec, double* X, int size)
{
    double* Ax = MatrixVecMult(Matrix, X, size);
    double* r = new double[size];

    for (int i = 0; i < size; i++)
    {
        r[i] = rightVec[i] - Ax[i];
    }

    return r;
}