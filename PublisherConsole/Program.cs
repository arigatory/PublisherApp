using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBook();
GetAuthorWithBook();


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
            Console.WriteLine("*"+book.Title);
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