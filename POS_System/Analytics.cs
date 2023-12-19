using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Analytics : Form
    {
        private Connector _connector;
        private DataGridViewTextBoxColumn column;
        
        public Analytics()
        {
            InitializeComponent();
            
            _connector = new Connector();
            _connector.InitState();

            var result = _connector.Query("SELECT productName FROM Product LIMIT 1");
            result.Read();
            richTextBox1.Text = result.GetString(0);
            result.Close();
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Product Search Results";
            column.Name = "Search Result";
            dataGridView1.Columns.Add(column);
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            result = _connector.Query("SELECT productName FROM Product LIMIT 20");
            while (result.Read())
            {
                dataGridView1.Rows.Add(result.GetString(0));
            } result.Close();
            changeOperation(1);
            PlotSalesData();

        }
        
        

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void InitializeBrowser()
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void pOSUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPOSUnlock?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler<EventArgs> OnPOSUnlock;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            var result  = _connector.Query("SELECT productName from Product WHERE lower(productName) LIKE '%" + richTextBox1.Text + "%' LIMIT 10");
            while (result.Read())
            {
                dataGridView1.Rows.Add(result.GetString(0));
            } result.Close();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private string productName = "";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the data from the selected cell
                DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                object cellValue = selectedCell.Value;

                if (cellValue != null)
                {
                    string productName = cellValue.ToString();
                    this.productName = productName;

                    // Use the selected data as needed
                    richTextBox1.Text = productName;
                    
                    // Let's add the company
                    int currBrandID = 1;
                    var result = _connector.Query("SELECT brandName FROM Brand WHERE brandID = (SELECT brandID FROM Product WHERE productName like \"" +
                                                  "%" + productName + "%\" LIMIT 1)");
                    if (result.Read())
                    {
                        richTextBox2.Text = result.GetString(0);
                        result.Close();
                    }
                    else
                    {
                        richTextBox2.Text = "Unknown Brand";
                    }
                    
                    result.Close();
                    result = _connector.Query("SELECT sum(price * orderAmount)  FROM Product " +
                                              "LEFT JOIN purchase on purchase.productID = Product.ProductID" +
                                              " WHERE productName like \"%" + productName + "%\" GROUP BY Product.productID LIMIT 1");
                    
                    result.Read();
                    richTextBox3.Text =  result.GetDouble(0).ToString() + ".00";
                    result.Close();
                }
            }
            changeOperation(currentOperation);
            PlotSalesData();
            
            
        }

        private void Analytics_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeOperation(1);
        }

        private int currentOperation;

        private void changeOperation(int operation)
        {
            currentOperation = operation;
            switch (operation)
            {
                case 1:
                {
                    totalSales();
                    button1.BackColor = Color.SeaGreen;
                    button1.ForeColor = Color.White;
                    button2.BackColor = Color.White;
                    button2.ForeColor = Color.Black;
                    button3.BackColor = Color.White;
                    button3.ForeColor = Color.Black;
                    break;
                }
                case 2:
                {
                    lastMonth();
                    button1.BackColor = Color.White;
                    button1.ForeColor = Color.Black;
                    button2.BackColor = Color.SeaGreen;
                    button2.ForeColor = Color.White;
                    button3.BackColor = Color.White;
                    button3.ForeColor = Color.Black;
                    break;
                }
                case 3:
                {
                    lastYear();
                    button1.BackColor = Color.White;
                    button1.ForeColor = Color.Black;
                    button2.BackColor = Color.White;
                    button2.ForeColor = Color.Black;
                    button3.BackColor = Color.SeaGreen;
                    button3.ForeColor = Color.White;
                    break;
                }
            }
        }

        private void totalSales()
        {
            var result = _connector.Query("SELECT sum(price * orderAmount)  FROM Product " +
                                          "LEFT JOIN purchase on purchase.productID = Product.ProductID" +
                                          " WHERE productName like \"%" + productName + "%\" GROUP BY Product.productID LIMIT 1");
                    
            result.Read();
            richTextBox3.Text =  result.GetDouble(0).ToString() + ".00";
            result.Close();
        }
        
        private void lastMonth()
        {
            string queryStr = $@"
WITH pdID AS (
    SELECT productID FROM product WHERE productName LIKE '%{productName}%'
    LIMIT 1
),
latestEvent AS (
    SELECT MAX(orderEvent) AS mxEvent FROM purchase JOIN pdID ON pdID.productID = purchase.productID
),
prdSales AS (
    SELECT price, orderAmount, orderEvent 
    FROM Product
    LEFT JOIN purchase ON purchase.productID = Product.ProductID
    JOIN latestEvent ON DATEDIFF(latestEvent.mxEvent, purchase.orderEvent) <= 30
    WHERE Product.ProductID IN (SELECT productID FROM pdID)
)
SELECT SUM(price * orderAmount) FROM prdSales;
";


            // find the latest month and calculate from there
            var result = _connector.Query(queryStr);
                    
            result.Read();
            richTextBox3.Text =  result.GetDouble(0).ToString() + ".00";
            result.Close();
        }
        
        private void lastYear()
        {
            string query = $@"
WITH pdID AS (
    SELECT productID FROM product WHERE productName LIKE '%{productName}%'
    LIMIT 1
),
latestEvent AS (
    SELECT MAX(orderEvent) AS mxEvent FROM purchase JOIN pdID ON pdID.productID = purchase.productID
),
prdSales AS (
    SELECT price, orderAmount, orderEvent 
    FROM Product
    LEFT JOIN purchase ON purchase.productID = Product.ProductID
    JOIN latestEvent ON DATEDIFF(latestEvent.mxEvent, purchase.orderEvent) <= 60
    WHERE Product.ProductID IN (SELECT productID FROM pdID)
)
SELECT SUM(price * orderAmount) FROM prdSales;
";
          
            // find the last month, then count backwards from there
            var result = _connector.Query(query);
                    
            result.Read();
            richTextBox3.Text =  result.GetDouble(0).ToString() + ".00";
            result.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeOperation(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeOperation(3);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }
        private void PlotSalesData()
        {
            // Clear existing series and set chart type
            chart1.Series.Clear();
            var series = chart1.Series.Add("Sales");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            // Retrieve sales data
            var salesData = GetSalesData();

            // Add data points to the series
            foreach (var data in salesData)
            {
                // ReSharper disable once HeapView.BoxingAllocation
                series.Points.AddXY(data.Date, data.Amount);
            }

            // Configure chart
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Title = "Date";
            chart1.ChartAreas[0].AxisY.Title = "Sales Amount";
        }


        private List<SalesData> GetSalesData()
        {
            var salesData = new List<SalesData>();

            // Use productName from the search text box
            string productName = richTextBox1.Text;

            string query = $@"
    WITH DateRange AS (
        SELECT MIN(orderEvent) AS StartDate, MAX(orderEvent) AS EndDate
        FROM purchase
        JOIN Product ON Product.productID = purchase.productID
        WHERE productName LIKE '%{productName}%'
    )
    SELECT DATE_FORMAT(orderEvent, '%Y-%m') AS OrderMonth, SUM(price * orderAmount) AS TotalSales
    FROM Product
    LEFT JOIN purchase ON purchase.productID = Product.ProductID
    CROSS JOIN DateRange
    WHERE productName LIKE '%{productName}%' AND orderEvent BETWEEN DateRange.StartDate AND DateRange.EndDate
    GROUP BY OrderMonth
    ORDER BY OrderMonth";

            var result = _connector.Query(query);

            while (result.Read())
            {
                var month = result.GetString(0);
                var sales = result.GetDouble(1);
                salesData.Add(new SalesData { Date = month, Amount = sales });
            }
            result.Close();

            return salesData;
        }


        private string FormatDateToFirstOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).ToString("yyyy-MM-dd");
        }
        
        public class SalesData
        {
            public string Date { get; set; }
            public double Amount { get; set; }
        }

        
        
        
    }
}