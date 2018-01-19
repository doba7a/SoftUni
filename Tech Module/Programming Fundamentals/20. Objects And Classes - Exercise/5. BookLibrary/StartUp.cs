namespace BookLibrary
{
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;

    public class BookLibrary
    {
        public static void Main()
        {
            int numberOfBooks = int.Parse(Console.ReadLine());

            List<Book> booksData = new List<Book>();

            for (int i = 0; i < numberOfBooks; i++)
            {
                Book currentBook = Book.ReadBook(Console.ReadLine());

                booksData.Add(currentBook);
            }

            Library libraryData = new Library
            {
                listOfBooks = booksData
            };

            foreach (var author in libraryData.listOfBooks
                .GroupBy(x => x.Author)
                .OrderByDescending(x => x.Sum(y => y.Price))
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Sum(x => x.Price):F2}");
            }
        }
    }

    public class Library
    {
        public string Author { get; set; }
        public List<Book> listOfBooks { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }

        public static Book ReadBook(string givenBook)
        {
            string[] givenBookData = givenBook.Split(' ');

            string givenBookTitle = givenBookData[0];
            string givenBookAuthor = givenBookData[1];
            string givenBookPublisher = givenBookData[2];
            DateTime givenBookReleaseDate = DateTime.ParseExact(givenBookData[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            string givenBookISBN = givenBookData[4];
            double givenBookPrice = double.Parse(givenBookData[5]);

            Book currentBook = new Book
            {
                Title = givenBookTitle,
                Author = givenBookAuthor,
                Publisher = givenBookPublisher,
                ReleaseDate = givenBookReleaseDate,
                ISBN = givenBookISBN,
                Price = givenBookPrice
            };

            return currentBook;
        }
    }
}