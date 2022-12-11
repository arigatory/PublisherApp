using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext();

//AddSomeMoreAuthors();
GetAuthors();
InsertMultipleAuthors();
Console.WriteLine();
GetAuthors();

void InsertMultipleAuthors()
{
    _context.Authors.AddRange(new Author { FirstName = "Ivan", LastName = "Panchenko" },
                              new Author { FirstName = "Don", LastName = "Din" },
                              new Author { FirstName = "Joim", LastName = "Kapser" },
                              new Author { FirstName = "Ann", LastName = "Malaha" });
    _context.SaveChanges();
}



void DeleteAnAuthor()
{
    var extraJL = _context.Authors.Find(1);
    if (extraJL != null)
    {
        _context.Authors.Remove(extraJL);
        _context.SaveChanges();
    }
}

void RetrieveAndUpdateAuthor()
{
    var author = _context.Authors.FirstOrDefault(a => a.FirstName == "Josie" && a.LastName == "Newf");
    if (author != null)
    {
        author.FirstName = "Ivan 2";
        _context.SaveChanges();
    }

}


void RetrieveAndUpdateMultipleAuthor()
{
    var newfAuthors = _context.Authors.Where(a => a.LastName == "Pan").ToList();
    foreach (var jn in newfAuthors)
    {
        jn.LastName = "Panchenko";
    }
    Console.WriteLine("Before: " + _context.ChangeTracker.DebugView.ShortView);
    _context.ChangeTracker.DetectChanges();
    Console.WriteLine("After: " + _context.ChangeTracker.DebugView.ShortView);
    _context.SaveChanges();
}

void QueryFilters()
{
    var authors = _context.Authors.Where(s => EF.Functions.Like(s.FirstName, "J%")).ToList();
}

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Ivan", LastName = "Panchenko" });
    _context.Authors.Add(new Author { FirstName = "Don", LastName = "Din" });
    _context.Authors.Add(new Author { FirstName = "Joim", LastName = "Kapser" });
    _context.Authors.Add(new Author { FirstName = "Ann", LastName = "Malaha" });
    _context.SaveChanges();
}

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Josie", LastName = "Newf" };
    author.Books.Add(new Book
    {
        Title = "Test Josie Book",
        PublishDate = new DateTime(2020, 1, 1).ToUniversalTime(),
    });
    author.Books.Add(new Book
    {
        Title = "Test Josie Book 2nd Ed",
        PublishDate = new DateTime(2022, 1, 1).ToUniversalTime()
    });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}


void GetAuthorWithBook()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}

void AddAuthor()
{
    var author = new Author { FirstName = "Josie", LastName = "Newf" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}