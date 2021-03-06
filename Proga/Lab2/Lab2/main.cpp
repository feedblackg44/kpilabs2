#include <iostream>
#include "MyString.h"
#include "MyText.h"
#include "functions.h"

using std::cout;
using std::cin;
using std::endl;

int main()
{
    MyText curText,
           menu;
    MyString curString;
    size_t strNum;
    int choise = -1;
    
    menuInit(menu);
    
    while (true)
    {
        cout << "Current text:\n" << curText << "\n" << endl;

        switch (choise)
        {
        case(1):
            cout << "\nType a position of new string (0 to go to main menu): ";
            strNum = GetSizeT();
            if (strNum)
            {
                cout << "\nType a string: ";
                getline(cin, curString);
                curText.AddString(curString, strNum);
            }
            else
                choise = -1;
            break;
        case(2):
            cout << "\nType a position to delete a string (0 to go to main menu): ";
            strNum = GetSizeT();
            if (strNum)
            {
                curText.RemoveString(strNum);
            }
            else
                choise = -1;
            break;
        case(3):
            curText.Clear();
            choise = -1;
            break;
        case(4):
            curText = curText.TextUpperCase();
            choise = -1;
            break;
        case(5):
            cout << "\nType a number of string (0 to go to main menu): ";
            strNum = GetSizeT();
            if (strNum)
            {
                cout << "\nKeyWord: " << curText[strNum - 1].KeyWord() << endl;
                system("pause");
            }
            else
                choise = -1;
            break;
        case(6):
            cout << "\nType a length (0 to go to main menu): ";
            strNum = GetSizeT();
            if (strNum)
            {
                cout << "\nNumber of strings of a given length: " << curText.GetNumberOfStrings(strNum) << endl;
                system("pause");
            }
            else
                choise = -1;
            break;
        case(0):
            exit(0);
            break;
        default:
            cout << "\n" << menu << "\n" << endl;
            cout << "Choose a num from 0 to 6: ";
            choise = GetInt();
            break;
        }
        system("cls");
    }
}