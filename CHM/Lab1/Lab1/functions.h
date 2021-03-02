#pragma once

float** createMatrix(int size);

float* createVec(int size);

void matrix4Init(float** M);

void vector4Init(float* V);

void fillInSeq(int* Vector, int size);

void fillRandom(float** Matrix, int size);

void fillRandom(float* Vector, int size);

void print(float** Matrix, int size);

void print(float* Vector, int size);

void print(float number);

int* getIndexOfMaxElement(float** Matrix, int size, int n);

float* getMultipliersArray(float** Matrix, int size, int* key, int n);

void swapRows(float** Matrix, float* rightVector, int size, int numRow1, int numRow2);

void swapCols(float** Matrix, int* numbersX, int size, int numCol1, int numCol2);

void gaussStep(float** Matrix, float* rightVector, int* keys, float* multipl, int* numbersX, int size, int n);

void gaussAlgorithmTriangle(float** Matrix, float* rightVector, int* numbersX, int size);

void gaussAlgorithmGetSolution(float** Matrix, float* rightVector, int* numbersX, float* X, int size);

float Solution(float** Matrix, float* X, int n, int size);

float* MatrixVecMult(float** matrix1, float* matrix2, int size);

float* vecDelta(float** Matrix, float* rightVec, float* X, int size);