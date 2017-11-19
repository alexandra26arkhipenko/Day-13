using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Test
{
    class Book :IComparable<Book>
    {
        private string Title { get; }

        public Book(string title)
        {
            Title = title;
        }
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return string.CompareOrdinal(Title, other.Title);
        }
    }
}
