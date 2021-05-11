#include <iostream>
#include "expression.h"

using std::cout;
using std::endl;
using std::cin;

int main()
{
    double a, b, c, d;
    cout << "Write a, b, c and d: ";
    cin >> a >> b >> c >> d;

    Expression exp = Expression(a, b, c, d);

    try
    {
        cout << "The result is: " << exp.Calculate() << endl;
    }
    catch (std::exception ex)
    {
        cout << ex.what() << endl;
    }

    system("pause");
    return 0;
}