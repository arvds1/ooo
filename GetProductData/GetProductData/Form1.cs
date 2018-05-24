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
using System.Diagnostics;


namespace GetProductData
{


    public partial class Form1 : Form
    {

        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public Form1()
        {

            InitializeComponent();
            //button1.Click += new EventHandler(this.button1_Click);
            InitTable();



        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void textUrl_TextChanged(object sender, EventArgs e)
        {

            string url = textUrl.Text;

        }



        public class ProductData
        {
            public string Description { get; set; }
            public string ActionPrice { get; set; }
            public string RegularPrice { get; set; }
            public string Discount { get; set; }

        }

        public class CategoryData
        {
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string SubSubCategory { get; set; }
        }


        private void InitTable()
        {

            table = new DataTable("ProductData");
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("ActionPrice", typeof(string));
            table.Columns.Add("RegularPrice", typeof(string));
            table.Columns.Add("Discount", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("SubCategory", typeof(string));
            table.Columns.Add("SubSubCategory", typeof(string));
            productDataView.DataSource = table;
        }

        string url1 = "https://www.ksenukai.lv/c/interjers-mebeles-un-tekstils/mebeles/darza-mebeles/2b4";





        private async void button1_Click(object sender, EventArgs e)
        {
            
            async Task<List<ProductData>> InformationFromPage(int PageNum)
            {

                string url = url1;
                if (PageNum != 0)
                    url = url1 + "?page=" + PageNum.ToString();



                var doc = await Task.Factory.StartNew(() => web.Load(url));

                var descriptionNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div//div//div//div//div//div//div//p/a");
                var actionPriceNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div/div//div//div/div//span//span[1]");
                var regularPriceNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div//div//div//div/div[1]/span[2]");
                var discountNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div//div//div//div/div[3]");


                if (descriptionNodes == null || discountNodes == null || actionPriceNodes == null)
                    return new List<ProductData>();
                var description = descriptionNodes.Select(node => node.InnerText);
                var discount = discountNodes.Select(node => node.InnerText);
                var actionPrice = actionPriceNodes.Select(node => node.InnerText);
                var regularPrice = regularPriceNodes.Select(node => node.InnerText);
                var result1 = description.ZipFour(actionPrice, regularPrice, discount, (name, action, regular, disco) => new ProductData() { Description = name, ActionPrice = action, RegularPrice = regular, Discount = disco }).ToList();
                return result1;


            }

            async Task<List<CategoryData>> CategoryInfo(int PageNum)
            {

                string url = url1;
                var doc = await Task.Factory.StartNew(() => web.Load(url));
                var categoryNodes = doc.DocumentNode.SelectNodes("//*[@id=\"breadcrumb_1\"]/a[1]/span");
                var subCategoryNodes = doc.DocumentNode.SelectNodes("//*[@id=\"breadcrumb_2\"]/a/span");
                var subSubCategoryNodes = doc.DocumentNode.SelectNodes("/html//div//div//div//div/div//div//div//div//h1/a");

                if (categoryNodes == null || subCategoryNodes == null || subSubCategoryNodes == null)
                    return new List<CategoryData>();
                var category = categoryNodes.Select(node => node.InnerText);
                var subcategory = subCategoryNodes.Select(node => node.InnerText);
                var subsubcategory = subSubCategoryNodes.Select(node => node.InnerText);
                var result2 = category.ZipThree(subcategory, subsubcategory, (cat, sub, subsub) => new CategoryData() { Category = cat, SubCategory = sub, SubSubCategory = subsub }).ToList();
                return result2;

            }

            int PageNum1 = 1;
            var products = await InformationFromPage(0);
            var categories = await CategoryInfo(0);


            while (products.Count > 0 || categories.Count > 0)
            {
                
                foreach (var product in products)
                    foreach (var category in categories)
                        table.Rows.Add(product.Description,
                            product.ActionPrice.Replace(",", "."),
                            product.RegularPrice.Replace(" € / gab.", "").Replace(",", ".").Replace(" € / pak.", "").Replace("\n", "").Replace(" € / vnt.", "").Replace(" € / tk", ""),
                            product.Discount.Replace("\n", ""),
                            category.Category.Replace("\n", ""),
                            category.SubCategory,
                            category.SubSubCategory);

                PageNum1++;
                products = await InformationFromPage(PageNum1);
                categories = await CategoryInfo(PageNum1);
            }

        }


        private async void Form1_Load(object sender, EventArgs e)
        {
           




        }


    }



}
