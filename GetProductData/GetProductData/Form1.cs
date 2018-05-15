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
    public static class MyFunkyExtensions
    {
        public static IEnumerable<TResult> ZipThree<T1, T2, T3, TResult>(
            this IEnumerable<T1> source,
            IEnumerable<T2> second,
            IEnumerable<T3> third,
            Func<T1, T2, T3, TResult> func)
        {
            using (var e1 = source.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    yield return func(e1.Current, e2.Current, e3.Current);
            }
        }
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


        public class ProductData
        {
            public string Description { get; set; }
            public string ActionPrice { get; set; }
            public string Discount { get; set; }
            
        }

        private void InitTable()
        {
       
            table = new DataTable("ProductData");
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("ActionPrice", typeof(string));
            table.Columns.Add("Discount", typeof(string));
            productDataView.DataSource = table;
        }

        private async Task<List<ProductData>> InformationFromPage(int PageNum)
        {
            string url = "https://www.ksenukai.lv/c/darza-un-auto-piederumi/darza-mebeles/1hq";
            if (PageNum != 0)
                url = "https://www.ksenukai.lv/c/darza-un-auto-piederumi/darza-mebeles/1hq?page=" + PageNum.ToString();
            var doc = await Task.Factory.StartNew(() => web.Load(url));
            var descriptionNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div//div//div//div//div//div//div//p/a");
            var actionPriceNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div/div//div//div/div//span//span[1]");
            var discountNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div//div//div//div/div[3]");

            if (descriptionNodes == null || discountNodes == null || actionPriceNodes == null)
                return new List<ProductData>();
            var description = descriptionNodes.Select(node => node.InnerText);
            var discount = discountNodes.Select(node => node.InnerText);
            var actionPrice = actionPriceNodes.Select(node => node.InnerText);

            var result = description.ZipThree(actionPrice, discount, (name, action, disco) => new ProductData() {  Description = name, ActionPrice = action, Discount = disco }).ToList();
            return result;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            int PageNum = 0;
            var products = await InformationFromPage(0);
            while (products.Count > 0)
            {
                foreach (var product in products)
                    table.Rows.Add(product.Description, product.ActionPrice, product.Discount);
                PageNum++;
                products = await InformationFromPage(PageNum);
            }




        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
