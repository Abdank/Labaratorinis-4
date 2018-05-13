using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>

public class Book : IComparable<Book>, IEquatable<Book>
{
    public int CompareTo(Book book)
    {
        if (book == null)
            return 1;
        if (String.Compare(Title, book.Title, StringComparison.CurrentCulture) != 0)
            return String.Compare(Title, book.Title, StringComparison.CurrentCulture);
        if (Sold > book.Sold)
            return -1;
        else return 1;
    }
    public bool Equals(Book book)
    {
        if (book == null)
            return false;
        if (book.Title == Title && Author == book.Author && Years == book.Years)
            return true;
        return false;
    }

    public string Author { get; set; }
    public string Title { get; set; }
    public int Years { get; set; }
    public double Price { get; set; }
    public int Sold { get; set; }
    public int Left { get; set; }
    public Book(string author, string title, int years, double price, int sold, int left, string bookstore)
    {
        Author = author;
        Title = title;
        Years = years;
        Price = price;
        Sold = sold;
        Left = left;
        Bookstore = bookstore;
    }
    public override string ToString()
    {
        string a = String.Format("{0,-20}{1,-15}{2,-7}{3,-6}{4,-5}{5,-5}", Author, Title, Years, Price, Sold, Left);
        return a;
    }
    public string ToTable()
    {
        string a = String.Format("{0};{1};{2};{3};{4};{5}", Author, Title, Years, Price, Sold, Left);
        return a;
    }
    public string Bookstore { get; set; }
}