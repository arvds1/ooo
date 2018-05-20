﻿using System;
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
        public static IEnumerable<TResult> ZipFour<T1, T2, T3, T4, TResult>(
            this IEnumerable<T1> source,
            IEnumerable<T2> second,
            IEnumerable<T3> third,
            IEnumerable<T4> fourth,
            Func<T1, T2, T3, T4, TResult> func)
        {
            using (var e1 = source.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
            using (var e4 = fourth.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext() && e4.MoveNext ())
                    yield return func(e1.Current, e2.Current, e3.Current, e4.Current);
            }
        }
    }

    public static class MyFunkyExtensions2
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

        string url1 = "https://www.k-rauta.ee/c/kute-ventilatsioon-ja-vesi/ahjud-ja-korstnad/ahjud-ja-kaminad/fj";


        private async Task<List<ProductData>> InformationFromPage(int PageNum)
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
            var result1 = description.ZipFour(actionPrice, regularPrice, discount, (name, action, regular, disco) => new ProductData() {  Description = name, ActionPrice = action, RegularPrice = regular, Discount = disco }).ToList();
            return result1;
        }

        private async Task<List<CategoryData>> CategoryInfo(int PageNum)

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
         


        private async void Form1_Load(object sender, EventArgs e)
        {
            
            int PageNum = 0;
            var products = await InformationFromPage(0);
            var categories = await CategoryInfo(0);
            while (products.Count > 0 || categories.Count > 0)
            {
                foreach (var product in products)
                    foreach(var category in categories)
                    table.Rows.Add(product.Description, 
                        product.ActionPrice.Replace(",","."), 
                        product.RegularPrice.Replace(" € / gab.", "").Replace(",",".").Replace(" € / pak.","").Replace("\n","").Replace(" € / vnt.", "").Replace(" € / tk", ""), 
                        product.Discount.Replace("\n", ""), 
                        category.Category.Replace("\n", ""), category.SubCategory, category.SubSubCategory);
                        
                PageNum++;
                products = await InformationFromPage(PageNum);
                categories = await CategoryInfo(PageNum);
            }

            



        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
