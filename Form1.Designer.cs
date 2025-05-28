namespace Library_Catalog
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchLbL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctgComBox = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.adminBtn = new System.Windows.Forms.Button();
            this.AdminGbox = new System.Windows.Forms.GroupBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.AdminGbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(185, 12);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(508, 426);
            this.dgvBooks.TabIndex = 0;
            // 
            // SearchTB
            // 
            this.SearchTB.BackColor = System.Drawing.SystemColors.Window;
            this.SearchTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTB.Location = new System.Drawing.Point(5, 108);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(176, 20);
            this.SearchTB.TabIndex = 1;
            // 
            // SearchLbL
            // 
            this.SearchLbL.AutoSize = true;
            this.SearchLbL.Location = new System.Drawing.Point(71, 92);
            this.SearchLbL.Name = "SearchLbL";
            this.SearchLbL.Size = new System.Drawing.Size(40, 13);
            this.SearchLbL.TabIndex = 2;
            this.SearchLbL.Text = "Пошук";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Пошук по:";
            // 
            // ctgComBox
            // 
            this.ctgComBox.FormattingEnabled = true;
            this.ctgComBox.Location = new System.Drawing.Point(60, 131);
            this.ctgComBox.Name = "ctgComBox";
            this.ctgComBox.Size = new System.Drawing.Size(121, 21);
            this.ctgComBox.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(5, 162);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(176, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // adminBtn
            // 
            this.adminBtn.Location = new System.Drawing.Point(3, 302);
            this.adminBtn.Name = "adminBtn";
            this.adminBtn.Size = new System.Drawing.Size(176, 23);
            this.adminBtn.TabIndex = 6;
            this.adminBtn.Text = "Увійти як Адміністратор";
            this.adminBtn.UseVisualStyleBackColor = true;
            this.adminBtn.Click += new System.EventHandler(this.adminBtn_Click);
            // 
            // AdminGbox
            // 
            this.AdminGbox.Controls.Add(this.delBtn);
            this.AdminGbox.Controls.Add(this.editBtn);
            this.AdminGbox.Controls.Add(this.addBtn);
            this.AdminGbox.Location = new System.Drawing.Point(3, 331);
            this.AdminGbox.Name = "AdminGbox";
            this.AdminGbox.Size = new System.Drawing.Size(176, 106);
            this.AdminGbox.TabIndex = 7;
            this.AdminGbox.TabStop = false;
            this.AdminGbox.Text = "Панель Адміністратора";
            this.AdminGbox.Visible = false;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(6, 77);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(164, 23);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "Видалити запис";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(6, 48);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(164, 23);
            this.editBtn.TabIndex = 1;
            this.editBtn.Text = "Редагувати запис";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(6, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(164, 23);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Створити запис";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 77);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AdminGbox);
            this.Controls.Add(this.adminBtn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ctgComBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchLbL);
            this.Controls.Add(this.SearchTB);
            this.Controls.Add(this.dgvBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Catalog";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.AdminGbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Label SearchLbL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ctgComBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button adminBtn;
        private System.Windows.Forms.GroupBox AdminGbox;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

