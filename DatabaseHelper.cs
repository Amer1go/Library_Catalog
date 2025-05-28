using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Windows.Forms; 
namespace Library_Catalog
{
    public static class DatabaseHelper
    {
        static string databasePath = @"C:\Users\berez\source\repos\Library_Catalog\LibCatDB.accdb";
        static string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            string query = "SELECT BookID, Title, Authors, Keywords FROM Books";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Guid id = Guid.Parse(reader["BookID"].ToString());
                                string title = reader["Title"].ToString();
                                List<string> authors = reader["Authors"].ToString()
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(a => a.Trim())
                                    .ToList();
                                List<string> keywords = reader["Keywords"].ToString()
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(k => k.Trim())
                                    .ToList();
                                books.Add(new Book(id, title, authors, keywords));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних з БД: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return books;
        }

        public static bool AddBook(Book book)
        {
            string query = "INSERT INTO Books (BookID, Title, Authors, Keywords) VALUES (@BookID, @Title, @Authors, @Keywords)";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", book.Id.ToString());
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Authors", string.Join(", ", book.Authors));
                        command.Parameters.AddWithValue("@Keywords", string.Join(", ", book.Keywords));

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання книги до БД: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool UpdateBook(Book book)
        {
            string query = "UPDATE Books SET Title = @Title, Authors = @Authors, Keywords = @Keywords WHERE BookID = @BookID";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Authors", string.Join(", ", book.Authors));
                        command.Parameters.AddWithValue("@Keywords", string.Join(", ", book.Keywords));
                        command.Parameters.AddWithValue("@BookID", book.Id.ToString());

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення книги в БД: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteBook(Guid bookId)
        {
            string query = "DELETE FROM Books WHERE BookID = @BookID";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", bookId.ToString());
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення книги з БД: {ex.Message}", "Помилка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}