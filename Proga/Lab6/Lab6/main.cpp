#include <iostream>
#include "MyString.h"
#include "NumString.h"
#include "LowerString.h"

using std::cin;
using std::cout;
using std::endl;

int main()
{
    cout << "Stock string1:\nH1e3l5l7o9" << endl;
    MyString* strNum = new NumString("H1e3l5l7o9");
    cout << "Stock number string:\n" << strNum << endl;
    (*strNum).MoveLetters();
    cout << "Number string after moving fisrt element to the last pos:\n" << strNum << endl;

    cout << endl;

    cout << "Stock string2:\nHeLlO mY fRiEnD" << endl;
    MyString* strLow = new LowerString("HeLlO mY fRiEnD");
    cout << "Stock lower string:\n" << strLow << endl;
    (*strLow).MoveLetters();
    cout << "Lower string after moving last element to the first pos:\n" << strLow << endl;

    system("pause");
    return 0;
}