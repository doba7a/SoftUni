using System;
using System.Collections.Generic;

public class Book : IBook, IComparable<Book>
{
    private string title;
    private int year;
    private IReadOnlyList<string> authors;

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get => title; private set => title = value; }
    public int Year { get => year; private set => year = value; }
    public IReadOnlyList<string> Authors { get => authors; private set => authors = value; }

    public int CompareTo(Book other)
    {
        int result = this.Year.CompareTo(other.Year);

        if (result == 0)
        {
            result = this.Title.CompareTo(other.Title);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}

