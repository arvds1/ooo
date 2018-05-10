using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GetProductData
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
       
            table = new DataTable("ProductData");
            table.Columns.Add("Number", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Regular Price", typeof(string));
            table.Columns.Add("Action Price", typeof(string));
            productDataView.DataSource = table;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            InitTable();
            HtmlWeb web = new HtmlWeb();
            var doc = await Task.Factory.StartNew(() => web.Load("https://www.ksenukai.lv/c?utf8=%E2%9C%93&q=mebeles"));
            doc.DocumentNode.SelectNodes("/html/body/div[2]/div[1]/div[3]/div/div[2]/div[2]/div/div[3]/div[1]/div/p/a");
            // 8.22 minuta video
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
