using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace POS_System
{
    public partial class Form1 : Form
    {
        private Connector _connector;
        private DataGridViewTextBoxColumn searchResultsProductName;
        private DataGridViewTextBoxColumn searchResultsBrandName;
        private DataGridViewTextBoxColumn searchResultsProductID;
        private DataGridViewTextBoxColumn productID;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn productQty;
        private DataGridViewTextBoxColumn productPrice;
        private DataGridViewTextBoxColumn totalPrice;
        private DataGridViewTextBoxColumn searchResultprice;
        
        
        public Form1()
        {
            InitializeComponent();
            AutoScaleDimensions = new SizeF(6F, 13F);
            MaximizeBox = false;
            WindowState = FormWindowState.Maximized;
            _connector = new Connector();
            _connector.InitState();
            InitializeDataGridView();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.ReadOnly = true;
        }

        private void InitializeDataGridView()
        {
            searchResultsProductName = new DataGridViewTextBoxColumn();
            searchResultsBrandName = new DataGridViewTextBoxColumn();
            searchResultsProductID = new DataGridViewTextBoxColumn();
            productName = new DataGridViewTextBoxColumn();
            productQty = new DataGridViewTextBoxColumn();
            productID = new DataGridViewTextBoxColumn();
            searchResultsProductID.HeaderText = "Product ID";
            searchResultsProductID.Name = "Product ID";
            
            searchResultsProductID.FillWeight = 0.15f;
            searchResultsProductID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            searchResultsProductID.DataPropertyName = "ColumnNameInDataSource"; // If you are binding data
            
            
            // Set properties for the new columns (customize as needed)
            searchResultsProductName.HeaderText = "Product Name";
            searchResultsProductName.Name = "Product Name";
            searchResultsProductName.FillWeight = 1;
            searchResultsProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            searchResultsProductName.DataPropertyName = "ColumnNameInDataSource"; // If you are binding data

            productName.HeaderText = "Product Name";
            productName.Name = "Product Name";
            productName.FillWeight = 1;
            productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productName.DataPropertyName = "ColumnNameInDataSource";
            
            productID.HeaderText = "Product ID";
            productID.Name = "Product ID";
            productID.FillWeight = 0.15f;
            productID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productID.DataPropertyName = "ColumnNameInDataSource";
            
            productQty.HeaderText = "Quantity";
            productQty.Name = "Quantity";
            productQty.FillWeight = 0.15f;
            productQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productQty.DataPropertyName = "ColumnNameInDataSource";
            
            
            
            searchResultsBrandName.HeaderText = "Brand Name";
            searchResultsBrandName.Name = "Brand Name";
            searchResultsBrandName.FillWeight = 0.25f;
            searchResultsBrandName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            searchResultsBrandName.DataPropertyName = "ColumnNameInDataSource"; // If you are binding data

            dataGridView2.Columns.Add(productID);
            dataGridView2.Columns.Add(productName);
            dataGridView2.Columns.Add(productQty);
            dataGridView1.Columns.Add(searchResultsProductID);
            // Add the columns to the DataGridView
            dataGridView1.Columns.Add(searchResultsProductName);
            dataGridView1.Columns.Add(searchResultsBrandName);
            
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // or another mode that suits your needs
            productPrice = new DataGridViewTextBoxColumn();
            totalPrice = new DataGridViewTextBoxColumn();

            productPrice.HeaderText = "Price Per Piece";
            productPrice.Name = "Price Per Piece";
            productPrice.FillWeight = 0.2f;
            productPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productPrice.DataPropertyName = "ColumnNameInDataSource"; // Adjust as needed

            totalPrice.HeaderText = "Total Price";
            totalPrice.Name = "Total Price";
            totalPrice.FillWeight = 0.2f;
            totalPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            totalPrice.DataPropertyName = "ColumnNameInDataSource"; // Adjust as needed

            dataGridView2.Columns.Add(productPrice);
            dataGridView2.Columns.Add(totalPrice);

            searchResultprice = new DataGridViewTextBoxColumn();
            searchResultprice.HeaderText = "Price Per Piece";
            searchResultprice.Name = "Price Per Piece";
            searchResultprice.FillWeight = 0.2f;
            searchResultprice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            searchResultprice.DataPropertyName = "ColumnNameInDataSource";
            dataGridView1.Columns.Add(searchResultprice);

        }
        
        private void UpdateTotalAmount()
        {
            double totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Total Price"].Value != null && double.TryParse(row.Cells["Total Price"].Value.ToString(), out double rowTotal))
                {
                    totalAmount += rowTotal;
                }
            }

            label3.Text = totalAmount.ToString("0.00");
            label3.Text = totalAmount.ToString("0.00");
        }

        
        private void addProduct(int id, string productName, int qty, string pricePerPiece)
        {
            // Create a new row
            DataGridViewRow newRow = new DataGridViewRow();

            // Create cells for the new entry
            DataGridViewCell productIDCell = new DataGridViewTextBoxCell();
            DataGridViewCell productNameCell = new DataGridViewTextBoxCell();
            DataGridViewCell productQtyCell = new DataGridViewTextBoxCell();
            DataGridViewCell priceCell = new DataGridViewTextBoxCell();
            DataGridViewCell totalPriceCell = new DataGridViewTextBoxCell();

            // Set the values of the cells
            productIDCell.Value = id;
            productNameCell.Value = productName;
            productQtyCell.Value = qty;

            // Parse price per piece and calculate total price
            if (double.TryParse(pricePerPiece, out double convertedPrice))
            {
                priceCell.Value = convertedPrice.ToString("0.00");
                totalPriceCell.Value = (convertedPrice * qty).ToString("0.00");
            }
            else
            {
                priceCell.Value = "0.00";
                totalPriceCell.Value = "0.00";
            }

            // Add the cells to the new row
            newRow.Cells.Add(productIDCell);
            newRow.Cells.Add(productNameCell);
            newRow.Cells.Add(productQtyCell);
            newRow.Cells.Add(priceCell);
            newRow.Cells.Add(totalPriceCell);

            // Add the new row to the DataGridView
            dataGridView2.Rows.Add(newRow);
            UpdateTotalAmount();
        }


        
        private void addSearchResult(int id, string productName, string productBrand, double pricePerProduct )
        {
            // Create a new row
            DataGridViewRow newRow = new DataGridViewRow();

            // Create cells for the new entry
            DataGridViewCell productIDCell = new DataGridViewTextBoxCell();
            DataGridViewCell productNameCell = new DataGridViewTextBoxCell();
            DataGridViewCell productBrandCell = new DataGridViewTextBoxCell();
            DataGridViewCell productPrice = new DataGridViewTextBoxCell();

            // Set the values of the cells
            productIDCell.Value = id;
            productNameCell.Value = productName;
            productBrandCell.Value = productBrand;
            productPrice.Value = pricePerProduct.ToString("0.00");

                            // Add the cells to the new row
            newRow.Cells.Add(productIDCell);
            newRow.Cells.Add(productNameCell);
            newRow.Cells.Add(productBrandCell);
            newRow.Cells.Add(productPrice);

            // Add the new row to the DataGridView
            dataGridView1.Rows.Add(newRow);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }


       
        private string generateSearchQuery(string q)
        {
            if (q.Length == 0) return "SELECT * FROM PRODUCT WHERE productId=-1";
            // Basic cleansing of the input to escape special characters
            string sanitizedInput = q.Replace("'", "''").ToLower();
            sanitizedInput = sanitizedInput.ToLower();
            return 
                "SELECT ProductID, ProductName, BrandName, Price FROM Product JOIN Brand ON Product.BrandID = Brand.BrandID WHERE LOWER(ProductName) LIKE '%" +
                sanitizedInput + "%' or LOWER(BrandName) LIKE '%\" + sanitizedInput + \"%' LIMIT 10;";
            // Construct the query with the sanitized input
            
        }

       

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {
            
        }


       

        private void richTextBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1, 1);
                Refresh();
               
                richTextBox3.Focus();

            } else if (e.KeyValue == (int)Keys.Down)
            {
                dataGridView1.Focus();
            }
            else
            {
                MySqlDataReader reader = _connector.Query(generateSearchQuery((richTextBox1.Text)));
                // clear all rows
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                
                    // add search result
                    addSearchResult(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                } reader.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                doubleTab = false;
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    // Assuming that the first column is the "Product ID" column
                    int productId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Product ID"].Value);
                    string productName = dataGridView1.Rows[selectedRowIndex].Cells["Product Name"].Value.ToString();
                    string price = dataGridView1.Rows[selectedRowIndex].Cells["Price Per Piece"].Value.ToString();
                    // You can now use the productId as needed
                    DialogResult result = MessageBox.Show($"Do you want to select Product ID {productId}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var destination = dataGridView2; // destination table 

                        if (!int.TryParse(richTextBox3.Text.Trim(), out int qty))
                        {
                            MessageBox.Show("Please enter a valid quantity in the quantity box.");
                            return;
                        }
                        
                        // Add the product name, qty, and id to the destination table
                        addProduct(productId, productName, qty, price);
                        richTextBox3.Text = "1";
                        richTextBox1.Focus();
                    }

                    // Add your further logic here, for example, passing the productId to another method, etc.
                }
            } else if (e.KeyValue == (int)Keys.Tab)
            {
                if (!doubleTab) doubleTab = true;
                else
                {
                    richTextBox1.Focus();
                }
            }
            else doubleTab = false;
            
        }

        private bool doubleTab = false;



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void richTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                
                Refresh();
               
                dataGridView1.Focus();

            }

            else if (e.KeyValue == (int)Keys.Down)
            {
                dataGridView1.Focus();
            }
        }
        
        private void fulfillOrders()
        {
            // Ask the user to confirm the finalization of the purchase
            DialogResult result = MessageBox.Show("Is this purchase final?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Push the orders to the SQL server
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Product ID"].Value != null && row.Cells["Total Price"].Value != null)
                    {
                        // Extract order details
                        string productId = row.Cells["Product ID"].Value.ToString();
                        string orderAmount = row.Cells["Total Price"].Value.ToString();
                        DateTime orderEvent = DateTime.Now;

                        // SQL query to insert the order into the Purchase table
                        string insertQuery = $"INSERT INTO Purchase (orderEvent, orderAmount, productID) VALUES ('{orderEvent.ToString("yyyy-MM-dd HH:mm:ss")}', {orderAmount}, {productId})";
                        _connector.Query(insertQuery).Close();
                    }
                }

                // Clear DataGridViews
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                // Display confirmation message
                MessageBox.Show("Order Fulfilled", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fulfillOrders();
            UpdateTotalAmount();
            richTextBox1.Text = "";
            
        }
    }
}