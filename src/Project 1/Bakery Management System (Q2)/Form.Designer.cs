namespace Bakery_Management_System
{
    partial class MainForm
    {
        // Elements
        private GroupBox productBox;
        private Button buttonCreate;
        private Label labelID;
        private Label labelName;
        private Label labelCategory;
        private Label labelPrice;
        private Label labelQuantity;
        private TextBox textName;
        private TextBox textID;
        private ComboBox comboCategory;
        private NumericUpDown numericQuantity;
        private TableLayoutPanel productTable;
        private PictureBox logoBox;



        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            productBox = new GroupBox();
            numericPrice = new NumericUpDown();
            buttonClearSearch = new Button();
            buttonModify = new Button();
            buttonSearch = new Button();
            buttonDelete = new Button();
            buttonCreate = new Button();
            numericQuantity = new NumericUpDown();
            labelID = new Label();
            textName = new TextBox();
            labelCategory = new Label();
            labelPrice = new Label();
            textID = new TextBox();
            labelName = new Label();
            labelQuantity = new Label();
            comboCategory = new ComboBox();
            productTable = new TableLayoutPanel();
            logoBox = new PictureBox();
            productBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // productBox
            // 
            productBox.AccessibleName = "Product Box";
            productBox.AccessibleRole = AccessibleRole.Grouping;
            productBox.AutoSize = true;
            productBox.BackColor = Color.Beige;
            productBox.Controls.Add(numericPrice);
            productBox.Controls.Add(buttonClearSearch);
            productBox.Controls.Add(buttonModify);
            productBox.Controls.Add(buttonSearch);
            productBox.Controls.Add(buttonDelete);
            productBox.Controls.Add(buttonCreate);
            productBox.Controls.Add(numericQuantity);
            productBox.Controls.Add(labelID);
            productBox.Controls.Add(textName);
            productBox.Controls.Add(labelCategory);
            productBox.Controls.Add(labelPrice);
            productBox.Controls.Add(textID);
            productBox.Controls.Add(labelName);
            productBox.Controls.Add(labelQuantity);
            productBox.Controls.Add(comboCategory);
            productBox.FlatStyle = FlatStyle.Flat;
            productBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productBox.ForeColor = Color.Black;
            productBox.Location = new Point(6, 369);
            productBox.Name = "productBox";
            productBox.Size = new Size(1240, 307);
            productBox.TabIndex = 1;
            productBox.TabStop = false;
            productBox.Text = "Products";
            // 
            // numericPrice
            // 
            numericPrice.AutoSize = true;
            numericPrice.DecimalPlaces = 2;
            numericPrice.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericPrice.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericPrice.Location = new Point(961, 33);
            numericPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericPrice.Name = "numericPrice";
            numericPrice.RightToLeft = RightToLeft.Yes;
            numericPrice.Size = new Size(214, 50);
            numericPrice.TabIndex = 18;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.AutoSize = true;
            buttonClearSearch.BackColor = Color.Coral;
            buttonClearSearch.FlatStyle = FlatStyle.Flat;
            buttonClearSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonClearSearch.Location = new Point(709, 225);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(166, 44);
            buttonClearSearch.TabIndex = 17;
            buttonClearSearch.Text = "Clear Search";
            buttonClearSearch.UseVisualStyleBackColor = false;
            buttonClearSearch.Click += buttonClearSearch_Click;
            // 
            // buttonModify
            // 
            buttonModify.AutoSize = true;
            buttonModify.BackColor = Color.SkyBlue;
            buttonModify.Cursor = Cursors.Hand;
            buttonModify.FlatStyle = FlatStyle.Flat;
            buttonModify.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonModify.Location = new Point(1063, 177);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(112, 44);
            buttonModify.TabIndex = 16;
            buttonModify.Text = "Modify";
            buttonModify.UseVisualStyleBackColor = false;
            buttonModify.Click += buttonModify_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.AutoSize = true;
            buttonSearch.BackColor = Color.SkyBlue;
            buttonSearch.Cursor = Cursors.Hand;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonSearch.Location = new Point(945, 177);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(112, 44);
            buttonSearch.TabIndex = 15;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.AutoSize = true;
            buttonDelete.BackColor = Color.Coral;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDelete.Location = new Point(827, 177);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(112, 44);
            buttonDelete.TabIndex = 14;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.LimeGreen;
            buttonCreate.Cursor = Cursors.Hand;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCreate.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCreate.Location = new Point(709, 177);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(112, 44);
            buttonCreate.TabIndex = 3;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = false;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // numericQuantity
            // 
            numericQuantity.AccessibleName = "Quantity";
            numericQuantity.Cursor = Cursors.IBeam;
            numericQuantity.Font = new Font("Segoe UI", 16F);
            numericQuantity.Location = new Point(1063, 104);
            numericQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.RightToLeft = RightToLeft.Yes;
            numericQuantity.Size = new Size(112, 50);
            numericQuantity.TabIndex = 4;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelID.Location = new Point(16, 35);
            labelID.Name = "labelID";
            labelID.Size = new Size(182, 45);
            labelID.TabIndex = 4;
            labelID.Text = "ProductID:";
            // 
            // textName
            // 
            textName.AccessibleName = "Name";
            textName.Cursor = Cursors.IBeam;
            textName.Font = new Font("Segoe UI", 16F);
            textName.Location = new Point(289, 104);
            textName.Name = "textName";
            textName.Size = new Size(249, 50);
            textName.TabIndex = 11;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelCategory.Location = new Point(16, 195);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(166, 45);
            labelCategory.TabIndex = 6;
            labelCategory.Text = "Category:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelPrice.Location = new Point(687, 35);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(103, 45);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "Price:";
            // 
            // textID
            // 
            textID.AccessibleName = "ID";
            textID.Cursor = Cursors.IBeam;
            textID.Font = new Font("Segoe UI", 16F);
            textID.Location = new Point(289, 35);
            textID.Name = "textID";
            textID.Size = new Size(249, 50);
            textID.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelName.Location = new Point(16, 107);
            labelName.Name = "labelName";
            labelName.Size = new Size(236, 45);
            labelName.TabIndex = 5;
            labelName.Text = "ProductName:";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelQuantity.Location = new Point(687, 104);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(270, 45);
            labelQuantity.TabIndex = 8;
            labelQuantity.Text = "QuantityInStock:";
            // 
            // comboCategory
            // 
            comboCategory.AccessibleName = "Category";
            comboCategory.Cursor = Cursors.Hand;
            comboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategory.Font = new Font("Segoe UI", 16F);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "Bread", "Cakes", "Cookies & Biscuits", "Donuts & Fried Pastries", "Other", "Pastries", "Pies & Tarts", "Savory Items", "Specialty Items" });
            comboCategory.Location = new Point(289, 192);
            comboCategory.MaxLength = 50;
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(372, 53);
            comboCategory.Sorted = true;
            comboCategory.TabIndex = 2;
            comboCategory.Tag = "category";
            // 
            // productTable
            // 
            productTable.AutoScroll = true;
            productTable.AutoSize = true;
            productTable.BackColor = Color.White;
            productTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            productTable.ColumnCount = 5;
            productTable.ColumnStyles.Add(new ColumnStyle());
            productTable.ColumnStyles.Add(new ColumnStyle());
            productTable.ColumnStyles.Add(new ColumnStyle());
            productTable.ColumnStyles.Add(new ColumnStyle());
            productTable.ColumnStyles.Add(new ColumnStyle());
            productTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            productTable.Location = new Point(12, 12);
            productTable.Name = "productTable";
            productTable.RowCount = 4;
            productTable.RowStyles.Add(new RowStyle());
            productTable.RowStyles.Add(new RowStyle());
            productTable.RowStyles.Add(new RowStyle());
            productTable.RowStyles.Add(new RowStyle());
            productTable.Size = new Size(833, 351);
            productTable.TabIndex = 10;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(848, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(398, 351);
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoBox.TabIndex = 3;
            logoBox.TabStop = false;
            // 
            // MainForm
            // 
            AccessibleDescription = "Bakery Management System";
            AccessibleName = "Application";
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.SeaGreen;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1258, 684);
            Controls.Add(logoBox);
            Controls.Add(productTable);
            Controls.Add(productBox);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1280, 740);
            MinimumSize = new Size(1280, 740);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bakery Management System";
            productBox.ResumeLayout(false);
            productBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSearch;
        private Button buttonDelete;
        private Button buttonModify;
        private Button buttonClearSearch;
        private NumericUpDown numericPrice;
    }
}
