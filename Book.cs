using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Catalog
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Keywords { get; set; }

        // Свойства для DataGridView
        public string AuthorsDisplay => Authors != null ? string.Join(", ", Authors) : string.Empty;
        public string KeywordsDisplay => Keywords != null ? string.Join(", ", Keywords) : string.Empty;

        // Конструктор для создания новой книги
        public Book(string title, List<string> authors, List<string> keywords)
        {
            Id = Guid.NewGuid();
            Title = title;
            Authors = authors ?? new List<string>();
            Keywords = keywords ?? new List<string>();
        }

        // Конструктор для загрузки книги из БД
        public Book(Guid id, string title, List<string> authors, List<string> keywords)
        {
            Id = id;
            Title = title;
            Authors = authors ?? new List<string>();
            Keywords = keywords ?? new List<string>();
        }
    }
}