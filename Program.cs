using System;
using System.IO;
using System.Text.RegularExpressions;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, int pages, string genre, string publisher, string isbn)
    {
        Title = title;
        Author = author;
        Pages = pages;
        Genre = genre;
        Publisher = publisher;
        ISBN = isbn;
    }

    public bool Validate()
    {
        Regex titleRegex = new Regex(@"^[a-zA-Z0-9\s]+$");
        Regex authorRegex = new Regex(@"^[a-zA-Z\s]+$");
        Regex isbnRegex = new Regex(@"^[\d-]+$");
        Regex genrePublisherRegex = new Regex(@"^[a-zA-Z\s]+$");

        return titleRegex.IsMatch(Title) &&
               authorRegex.IsMatch(Author) &&
               Pages > 0 &&
               genrePublisherRegex.IsMatch(Genre) &&
               genrePublisherRegex.IsMatch(Publisher) &&
               isbnRegex.IsMatch(ISBN);
    }

    public static string ExtractEmail(string input)
    {
        Regex emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
        Match match = emailRegex.Match(input);
        if (match.Success)
        {
            return match.Value;
        }
        else
        {
            return "";
        }
    }

    public void SaveToFile(string filePath)
    {
        if (!Validate())
        {
            throw new InvalidOperationException("Invalid book data.");
        }

        string bookData = $"Title: {Title}\nAuthor: {Author}\nPages: {Pages}\nGenre: {Genre}\nPublisher: {Publisher}\nISBN: {ISBN}";
        File.WriteAllText(filePath, bookData);
    }

    public static Book ReadFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length != 6)
        {
            throw new InvalidOperationException("File format is incorrect.");
        }

        return new Book(
            lines[0].Substring(7),
            lines[1].Substring(8),
            int.Parse(lines[2].Substring(7)),
            lines[3].Substring(7),
            lines[4].Substring(11),
            lines[5].Substring(6)
        );
    }

public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }
}

static Dictionary<string, Student> studentData = new Dictionary<string, Student>();
public static void Main(string[] args)
    {
        Student Alice = new Student("Alice", 85);
        Student Bob = new Student("Bob", 92);

        studentData.Add("ID-001", Alice);
        studentData.Add("ID-002", Bob);
    }
}
