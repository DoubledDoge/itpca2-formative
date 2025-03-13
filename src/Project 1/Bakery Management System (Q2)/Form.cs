using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;

namespace Bakery_Management_System
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private DatabaseManager? dbManager;
        private List<Product>? products = new List<Product>();

        public MainForm()
        {
            // South African Rand
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ZA");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-ZA");
            InitializeComponent();
            SetupForm();
            InitializeDatabase();
            LoadProducts();
        }

        private void SetupForm()
        {
            // Double buffering technique for rendering
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.UserPaint
                    | ControlStyles.DoubleBuffer,
                true
            );

            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
        }

        // Function to enable Aero Glass effect on the form
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                int attrValue = 2;
                DwmSetWindowAttribute(Handle, 20, ref attrValue, Marshal.SizeOf(typeof(int)));
            }
        }

        // Exit confirmation
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (
                MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.No
            )
            {
                e.Cancel = true;
            }
        }

        // Function to make Esc key exit the program
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        // Aero Glass DLL import (Don't Worry about that. It has nothing to do with the functionality of this form. It can safely be removed alongside the other Aero Glass function)
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int attr,
            ref int attrValue,
            int attrSize
        );

        private void InitializeDatabase()
        {
            try
            {
                // Connect to SQL Server (Change this value to your server!)
                string connectionString =
                    @"Data Source=DDSWORKSPACE;Initial Catalog=BakeryManagementDB;Integrated Security=True;TrustServerCertificate=True";
                dbManager = new DatabaseManager(connectionString);

                if (!dbManager.TestConnection())
                {
                    MessageBox.Show(
                        "Failed to connect to the database. Please check your connection settings.",
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    Console.WriteLine("Successfully connected to the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error initializing database connection: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadProducts()
        {
            try
            {
                if (dbManager == null)
                    return;

                products = dbManager.GetAllProducts();
                DisplayProductsInTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading products: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void DisplayProductsInTable()
        {
            if (products == null)
                return;

            // Clear existing rows
            productTable.Controls.Clear();
            productTable.RowCount = 1;

            // Column headers
            productTable.Controls.Add(
                new Label
                {
                    Text = "ProductID",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                },
                0,
                0
            );
            productTable.Controls.Add(
                new Label
                {
                    Text = "ProductName",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                },
                1,
                0
            );
            productTable.Controls.Add(
                new Label
                {
                    Text = "Category",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                },
                2,
                0
            );
            productTable.Controls.Add(
                new Label
                {
                    Text = "Price",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                },
                3,
                0
            );
            productTable.Controls.Add(
                new Label
                {
                    Text = "Quantity",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                },
                4,
                0
            );

            // Add product rows
            int rowIndex = 1;
            foreach (var product in products)
            {
                if (rowIndex >= productTable.RowCount)
                {
                    productTable.RowCount++;
                }

                // Create labels with consistent background color (no alternating)
                Label tableLabelID = new Label
                {
                    Text = product.ProductID.ToString(),
                    AutoSize = true,
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                Label tableLabelName = new Label
                {
                    Text = product.ProductName ?? string.Empty,
                    AutoSize = true,
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                Label tableLabelCategory = new Label
                {
                    Text = product.Category,
                    AutoSize = true,
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                Label tableLabelPrice = new Label
                {
                    Text = product.Price.ToString("C"),
                    AutoSize = true,
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                Label tableLabelQuantity = new Label
                {
                    Text = product.QuantityInStock.ToString(),
                    AutoSize = true,
                    Padding = new Padding(5),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                // Add the labels to the table
                productTable.Controls.Add(tableLabelID, 0, rowIndex);
                productTable.Controls.Add(tableLabelName, 1, rowIndex);
                productTable.Controls.Add(tableLabelCategory, 2, rowIndex);
                productTable.Controls.Add(tableLabelPrice, 3, rowIndex);
                productTable.Controls.Add(tableLabelQuantity, 4, rowIndex);

                rowIndex++;
            }

            // Display a message if no products are found
            if (products.Count == 0)
            {
                Label noProductsLabel = new Label
                {
                    Text = "No products found",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                };

                productTable.Controls.Add(noProductsLabel, 0, 1);
                productTable.SetColumnSpan(noProductsLabel, 5);
            }
        }

        private void ClearInputFields()
        {
            textID.Text = string.Empty;
            textName.Text = string.Empty;
            numericPrice.Value = 0;
            comboCategory.SelectedIndex = -1;
            numericQuantity.Value = 0;
        }

        private void buttonCreate_Click(object? sender, EventArgs e)
        {
            if (dbManager == null)
                return;

            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(textName.Text) || comboCategory.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please fill in all required fields.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // No need to parse the price - it's already a numeric value
                float price = (float)numericPrice.Value;

                // Create a new product object
                Product newProduct = new Product
                {
                    ProductName = textName.Text,
                    Category = comboCategory.SelectedItem?.ToString() ?? string.Empty,
                    Price = price,
                    QuantityInStock = (int)numericQuantity.Value,
                };

                // Insert the product into the database
                bool success = dbManager.CreateProduct(newProduct);

                if (success)
                {
                    MessageBox.Show(
                        $"Product created successfully with ID: {newProduct.ProductID}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearInputFields();
                    LoadProducts(); // Refresh the product list
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "Failed to create product.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error creating product: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }

        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            if (dbManager == null)
                return;

            try
            {
                // Check if an ID is provided
                if (string.IsNullOrWhiteSpace(textID.Text))
                {
                    MessageBox.Show(
                        "Please enter a Product ID to delete.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Get the ID
                if (!int.TryParse(textID.Text, out int productId))
                {
                    MessageBox.Show(
                        "Invalid Product ID. Please enter a valid number.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return;
                }

                // Delete the product
                bool success = dbManager.DeleteProduct(productId);

                if (success)
                {
                    MessageBox.Show(
                        "Product deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearInputFields();
                    LoadProducts(); // Refresh
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete product. The product may not exist.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error deleting product: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            if (dbManager == null)
                return;

            try
            {
                // Check if search term is provided
                if (
                    string.IsNullOrWhiteSpace(textID.Text)
                    && string.IsNullOrWhiteSpace(textName.Text)
                    && comboCategory.SelectedItem == null
                )
                {
                    MessageBox.Show(
                        "Please enter a search term (ID, Name, or select a Category).",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string searchTerm = "";

                // Determine which field to search by
                if (!string.IsNullOrWhiteSpace(textID.Text))
                {
                    searchTerm = textID.Text;
                }
                else if (!string.IsNullOrWhiteSpace(textName.Text))
                {
                    searchTerm = textName.Text;
                }
                else if (comboCategory.SelectedItem != null)
                {
                    searchTerm = comboCategory.SelectedItem.ToString() ?? string.Empty;
                }

                // Search for products
                List<Product> searchResults = dbManager.SearchProducts(searchTerm);

                if (searchResults.Count > 0)
                {
                    // Display search results
                    products = searchResults;
                    DisplayProductsInTable();
                    MessageBox.Show(
                        $"Found {searchResults.Count} product(s).",
                        "Search Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "No products found matching your search criteria.",
                        "Search Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error searching products: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }

        private void buttonModify_Click(object? sender, EventArgs e)
        {
            if (dbManager == null)
                return;

            try
            {
                // Check if an ID is provided
                if (string.IsNullOrWhiteSpace(textID.Text))
                {
                    MessageBox.Show(
                        "Please enter a Product ID to modify.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Parse the ID
                if (!int.TryParse(textID.Text, out int productId))
                {
                    MessageBox.Show(
                        "Invalid Product ID. Please enter a valid number.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Check if other required fields are filled
                if (string.IsNullOrWhiteSpace(textName.Text) || comboCategory.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please fill in all required fields.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Get price from the numeric control
                float price = (float)numericPrice.Value;

                Product updatedProduct = new Product
                {
                    ProductID = productId,
                    ProductName = textName.Text,
                    Category = comboCategory.SelectedItem?.ToString() ?? string.Empty,
                    Price = price,
                    QuantityInStock = (int)numericQuantity.Value,
                };

                // Update the product
                bool success = dbManager.UpdateProduct(updatedProduct);

                if (success)
                {
                    MessageBox.Show(
                        "Product updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearInputFields();
                    LoadProducts(); // Refresh
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "Failed to update product. The product may not exist.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error updating product: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }

        private void ResetProductView()
        {
            if (dbManager == null)
                return;

            try
            {
                products = dbManager.GetAllProducts();
                DisplayProductsInTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error resetting product view: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Validate input for the ID field
        private void textID_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e == null)
                return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        // Handle Form Load event
        private void MainForm_Load(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            textID.KeyPress += textID_KeyPress;
            textName.Focus();
        }

        // Clear search results and reset the product view
        private void buttonClearSearch_Click(object? sender, EventArgs e)
        {
            if (dbManager == null)
                return;

            ClearInputFields();
            ResetProductView();
        }
    }
}
