#include <iostream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;

string GetMainDiag(string* arr, size_t size)
{
    string strOut = "";
    for (size_t i = 0; i < size; i++)
    {
        for (size_t j = 0; j < strlen(arr[i].c_str()); j++)
        {
            if (i == j)
                strOut += arr[i][j];
        }
    }
    return strOut;
}

void print(string(*func)(string*, size_t), string* arr, size_t size)
{
    cout << (*func)(arr, size) << endl;
}

void main()
{
    const size_t size = 5;
    string* strArray = new string[size];
    strArray[0] = "Hello there";
    strArray[1] = "Wonderful";
    strArray[2] = "Did it!";
    strArray[3] = "I am clever";
    strArray[4] = "End of test";

    print(GetMainDiag, strArray, size);

    system("pause");
}