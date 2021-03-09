#pragma once

#define DELIMITERS_STRING " "
#define EMPTY_STRING nullptr

class MyString
{
public:
    MyString();

    MyString(const char*);

    MyString(char*);

    MyString(const MyString&);

    MyString(std::nullptr_t);

    size_t GetLength();

    bool IsEmpty();

    void DeepCopy(MyString&);

    friend void getline(std::istream&, MyString&);

    MyString& UpperCase();

    MyString& KeyWord();

    friend std::ostream& operator<< (std::ostream&, const MyString&);

    char operator[] (const int);
    
    MyString& operator+= (char);

    MyString& operator+= (MyString&);

    MyString& operator= (MyString&);

    MyString& operator= (const char*);

    ~MyString();

private:
    char* str;
    size_t length;

    size_t ExtractFisrtWordOfString(MyString& strIn);

    size_t removeFirstSpaces(MyString strIn);
};