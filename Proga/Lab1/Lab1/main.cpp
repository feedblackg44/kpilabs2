#include <iostream>
#include "functions.h"

using namespace std;

int main()
{
    int a, b;           // numbers to compare
    string output;      // output string which depends on compare of numbers

    cout << "Print 2 numbers to compare. First number will be decremented by 1:" << endl;
    cin >> a >> b;

    if (moreThan(a, b))
        output = "Yes, a > b!";
    else
        output = "No, a <= b!";

    dekrement(a);

    cout << output << endl;
    cout << "a-- = " << a << endl;
    
    system("pause");
    return 0;
}