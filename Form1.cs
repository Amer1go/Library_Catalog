// Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Catalog
{
    public partial class Form1 : Form
    {
        private List<Book> allBooks = new List<Book>();
        private BindingList<Book> displayedBooks;
        private bool isAdminMode = false;
        public Form1()
        {
            InitializeComponent();
            SetupApplication();
        }
        private void SetupApplication()
        {
            ctgComBox.Items.Clear();
            ctgComBox.Items.Add("Назва");
            ctgComBox.Items.Add("Автор");
            ctgComBox.Items.Add("Ключове слово");
            if (ctgComBox.Items.Count > 0)
            {
                ctgComBox.SelectedIndex = 0;
            }

            dgvBooks.AutoGenerateColumns = false;
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TitleColumn",
                HeaderText = "Назва",
                DataPropertyName = "Title", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 40
            });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AuthorsColumn",
                HeaderText = "Автори",
                DataPropertyName = "AuthorsDisplay", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });
            dgvBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "KeywordsColumn",
                HeaderText = "Ключові слова",
                DataPropertyName = "KeywordsDisplay", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });

            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.MultiSelect = false;
            dgvBooks.RowHeadersVisible = false;

            LoadDataFromDatabase();

            RefreshDataGridView(allBooks); 

            UpdateAdminControlsVisibility();
        }

        private void LoadDataFromDatabase()
        {
            allBooks = DatabaseHelper.GetAllBooks();
        }

        private void RefreshDataGridView(List<Book> booksToShow)
        {
            
            displayedBooks = new BindingList<Book>(new List<Book>(booksToShow));
            dgvBooks.DataSource = displayedBooks;
            dgvBooks.ClearSelection();
            if (dgvBooks.Rows.Count > 0)
                dgvBooks.Rows[0].Selected = true; 
        }

        private void UpdateAdminControlsVisibility()
        {
            AdminGbox.Visible = isAdminMode;
            if (isAdminMode)
            {
                adminBtn.Text = "Вийти з режиму Адміністратора";
            }
            else
            {
                adminBtn.Text = "Увійти як Адміністратор";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = SearchTB.Text.Trim().ToLower();
            string criteria = ctgComBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(query))
            {
                RefreshDataGridView(allBooks);
                return;
            }

            if (criteria == null)
            {
                MessageBox.Show("Будь ласка, виберіть критерій пошуку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Book> filteredBooks = new List<Book>();

            switch (criteria)
            {
                case "Назва":
                    filteredBooks = allBooks.Where(b => b.Title.ToLower().Contains(query)).ToList();
                    break;
                case "Автор":
                    filteredBooks = allBooks.Where(b => b.Authors.Any(a => a.ToLower().Contains(query))).ToList();
                    break;
                case "Ключове слово":
                    filteredBooks = allBooks.Where(b => b.Keywords.Any(k => k.ToLower().Contains(query))).ToList();
                    break;
            }

            RefreshDataGridView(filteredBooks);

            if (!filteredBooks.Any())
            {
                MessageBox.Show("Книг за вашим запитом не знайдено.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            isAdminMode = !isAdminMode;
            UpdateAdminControlsVisibility();

            if (isAdminMode)
            {
                MessageBox.Show("Ви увійшли в режим адміністратора.", "Режим змінено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ви вийшли з режиму адміністратора. Активний режим гостя.", "Режим змінено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (AddEditBookForm addBookForm = new AddEditBookForm())
            {
                if (addBookForm.ShowDialog() == DialogResult.OK)
                {
                    Book newBook = addBookForm.CurrentBook;
                    if (DatabaseHelper.AddBook(newBook))
                    {
                        allBooks.Add(newBook);
                        RefreshDataGridView(allBooks);
                        MessageBox.Show("Книгу додано успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося додати книгу до бази даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть книгу для редагування.", "Книгу не вибрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book selectedBookFromGrid = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
            Book bookToEdit = allBooks.FirstOrDefault(b => b.Id == selectedBookFromGrid.Id);

            if (bookToEdit == null)
            {
                MessageBox.Show("Помилка: не вдалося знайти книгу для редагування в локальному списку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book bookCopyForEditing = new Book(bookToEdit.Id, bookToEdit.Title, new List<string>(bookToEdit.Authors), new List<string>(bookToEdit.Keywords));


            using (AddEditBookForm editBookForm = new AddEditBookForm(bookCopyForEditing))
            {
                if (editBookForm.ShowDialog() == DialogResult.OK)
                {
                    if (DatabaseHelper.UpdateBook(editBookForm.CurrentBook))
                    {
                        int index = allBooks.FindIndex(b => b.Id == editBookForm.CurrentBook.Id);
                        if (index != -1)
                        {
                            allBooks[index] = editBookForm.CurrentBook;
                        }
                        RefreshDataGridView(allBooks);
                        MessageBox.Show("Дані книги успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося оновити книгу в базі даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть книгу для видалення.", "Книгу не вибрано", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book selectedBookFromGrid = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
            Book bookToDelete = allBooks.FirstOrDefault(b => b.Id == selectedBookFromGrid.Id);

            if (bookToDelete == null)
            {
                MessageBox.Show("Помилка: не вдалося знайти книгу для видалення в локальному списку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show($"Ви впевнені, що хочете видалити книгу \"{bookToDelete.Title}\"?",
                                                      "Підтвердження видалення",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                if (DatabaseHelper.DeleteBook(bookToDelete.Id))
                {
                    allBooks.Remove(bookToDelete);
                    RefreshDataGridView(allBooks); 
                    MessageBox.Show("Книгу успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не вдалося видалити книгу з бази даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}