// AddEditBookForm.cs
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
    public partial class AddEditBookForm : Form
    {
        public Book CurrentBook { get; private set; }
        private bool isEditMode = false;

        public AddEditBookForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Додати нову книгу";
        }

        public AddEditBookForm(Book bookToEdit)
        {
            InitializeComponent();
            isEditMode = true;
            this.Text = "Редагувати книгу";

            CurrentBook = bookToEdit;
            
            txtTitle.Text = bookToEdit.Title;
            txtAuthor.Text = bookToEdit.Authors != null ? string.Join(", ", bookToEdit.Authors) : "";
            txtKeywords.Text = bookToEdit.Keywords != null ? string.Join(", ", bookToEdit.Keywords) : "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Назва книги не може бути порожньою.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return;
            }

            string title = txtTitle.Text.Trim();
            List<string> authors = txtAuthor.Text.Split(',')
                                        .Select(a => a.Trim())
                                        .Where(a => !string.IsNullOrWhiteSpace(a))
                                        .ToList();
            List<string> keywords = txtKeywords.Text.Split(',')
                                        .Select(k => k.Trim())
                                        .Where(k => !string.IsNullOrWhiteSpace(k))
                                        .ToList();
            if (isEditMode)
            {
              
                CurrentBook.Title = title;
                CurrentBook.Authors = authors;
                CurrentBook.Keywords = keywords;
            }
            else
            {
                
                CurrentBook = new Book(title, authors, keywords);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}