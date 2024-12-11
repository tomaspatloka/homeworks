namespace Lekce7
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
            CurrentPage = 0;
        }

        public void Read(int pages)
        {
            int newPage = CurrentPage + pages;
            CurrentPage = Math.Min(newPage, Pages);
        }

        public void DisplayProgress()
        {
            Console.WriteLine($"Reading '{Title}' by {Author}: {CurrentPage}/{Pages} pages read");
        }
    }
}