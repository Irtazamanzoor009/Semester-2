using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Book
    {
        public string author;
        public int pages;
        public List<string> chapters = new List<string>();
        public int bookmark;
        public int price;

        public Book(string author, int pages, int bookmark, int price)
        {
            this.author = author;
            this.pages = pages;
            this.bookmark = bookmark;
            this.price = price;
        }

        public string Getchapter(int chapternumber)
        {
            string chapter = chapters[chapternumber];
            return chapter;
        }
        public int Getbookmark()
        {
            return bookmark;
        }
        public void SetBookmark(int pagenumber)
        {
            bookmark = pagenumber;
        }
        public int Getbookprice()
        {
            return price;
        }
        public void SetBookprice(int newprice)
        {
            price = newprice;
        }
        public void Addchapter(string chaptername)
        {
            chapters.Add(chaptername);
        }
    }
}
