using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
//using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApplication2
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";
            dataGridView1.Columns[3].Name = "Product Type";
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost/webapi");
            HttpResponseMessage response = client.GetAsync("http://localhost/webapi/api/values/7").Result;
            //response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            responseBody = responseBody.Replace("\"","");
            int a = Int32.Parse(responseBody);
            int b = a + 10;
            //label1.Text = Convert.ToString(responseBody);
            //label1.Text = Convert.ToString(b);
        }

        private async void clickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://localhost/service/api/food/1").Result;

            // HTTP GET
            // HttpResponseMessage response = await client.GetAsync("api/food/1");
            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadAsAsync<Product>();
                sttText.Text = product.Id;
                //dataGridView1.DataSource = product;
                string[] row = new string[] { product.Id, product.Name, product.Price, product.Type };
                dataGridView1.Rows.Add(row);

            }
        }
        
        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string Type { get; set; }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
