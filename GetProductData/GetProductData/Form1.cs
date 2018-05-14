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
    public class ProductData
    {
        public string Description { get; set; }
        public string RegularPrice { get; set; }
        public string ActionPrice { get; set; }
    }
    public partial class Form1 : Form
    {
        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
       
            table = new DataTable("ProductData");
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("RegularPrice", typeof(string));
            table.Columns.Add("ActionPrice", typeof(string));
            productDataView.DataSource = table;
        }

        private async Task<List<ProductData>> InformationFromPage(int PageNum)
        {
            string url = "https://www.ksenukai.lv/c/darza-un-auto-piederumi/darza-mebeles/1hq";
            if (PageNum != 0)
                url = "https://www.ksenukai.lv/c/darza-un-auto-piederumi/darza-mebeles/1hq?page=" + PageNum.ToString();
            var doc = await Task.Factory.StartNew(() => web.Load(url));
            var descriptionNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div//div//div//div//div//div//div//p/a");
            var regularPriceNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div/div//div//div/div//span[2]");
            var actionPriceNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div/div//div//div/div//span//span[1]");

            if (descriptionNodes == null || regularPriceNodes == null || actionPriceNodes == null)
                return new List<ProductData>();
            var description = descriptionNodes.Select(node => node.InnerText);
            var regularPrice = regularPriceNodes.Select(node => node.InnerText);
            var actionPrice = actionPriceNodes.Select(node => node.InnerText);
            return description.Zip(actionPrice, (name, action) => new ProductData() {  Description = name, ActionPrice = action, RegularPrice = action }).ToList();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            int PageNum = 0;
            var products = await InformationFromPage(0);
            while (products.Count > 0)
            {
                foreach (var product in products)
                    table.Rows.Add(product.Description, product.RegularPrice, product.ActionPrice);
                PageNum++;
                products = await InformationFromPage(PageNum);
            }




        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
