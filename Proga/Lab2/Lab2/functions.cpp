#include <iostream>
#include "MyString.h"
#include "MyText.h"
#include "functions.h"

using std::cout;
using std::cin;
using std::endl;

size_t GetSizeT()
{
    size_t num;

    cin >> num;
    if (cin.fail())
    {
        cin.clear();
        num = 0;
    }
    cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

    return num;
}

int GetInt()
{
    int num;

    cin >> num;
    if (cin.fail())
    {
        cin.clear();
        num = -1;
    }
    cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

    return num;
}

void menuInit(MyText& menu)
{
    MyString menuHead = "Main menu:",
             menu1 = "1 - Add a string to the text",
             menu2 = "2 - Remove a string from the text",
             menu3 = "3 - Clear text",
             menu4 = "4 - Make the first letters of all words in the text uppercase ",
             menu5 = "5 - Get the \"key string\" of a string of text",
             menu6 = "6 - Get the number of strings of a given length",
             menu0 = "0 - Exit";

    menu.AddString(menuHead);
    menu.AddString(menu1);
    menu.AddString(menu2);
    menu.AddString(menu3);
    menu.AddString(menu4);
    menu.AddString(menu5);
    menu.AddString(menu6);
    menu.AddString(menu0);
}