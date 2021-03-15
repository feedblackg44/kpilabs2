#pragma once

double** createMatrix(int size);

double* createVec(int size);

void fillInSeq(int* Vector, int size);

void matrix5Init(double** M);

void vector5Init(double* V);

void print(double** Matrix, int size);

void print(double* Vector, int size, int prec = 6);

void print(double number);

double sumOfMatrixElements(double** matrix, double* X, int firstNum, int secondNum, int i);

void zeidelMethodSolve(double** matrix, double* B, double* X, int size);

double maxInArrays(double* arr1, double* arr2, int size);

void copyVec(double* vecCopyFrom, double* vecToCopy, int size);

double* MatrixVecMult(double** matrix1, double* matrix2, int size);

double* vecDelta(double** Matrix, double* rightVec, double* X, int size);