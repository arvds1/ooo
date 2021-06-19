using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;


namespace PPR
{


    public partial class Barbora : Form
    {

        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public Barbora()
        {
            InitializeComponent();
            InitTable();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public class ProductData
        {
            public string Description { get; set; }
            public string ActionPrice { get; set; }
            public string RegularPrice { get; set; }
            public string Discount { get; set; }
            public string Link { get; set; }
            public string PictureLink { get; set; }
            public string ProductInformation { get; set; }
            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string SubSubCategory { get; set; }
        }



        private void InitTable()
        {

            table = new DataTable("ProductData");
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Action Price", typeof(string));
            table.Columns.Add("Regular Price", typeof(string));
            table.Columns.Add("Discount", typeof(string));
            table.Columns.Add("Link", typeof(string));
            table.Columns.Add("Picture Link", typeof(string));
            table.Columns.Add("Product Information", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("SubCategory", typeof(string));
            table.Columns.Add("SubSubCategory", typeof(string));
            productDataView.DataSource = table;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {



            int BrowserVer, RegVal;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);

        }

        private async void button1_Click(object sender, EventArgs e)
        {



            labelProcess.Visible = true;


            int catNum = 0;

            string homePageAdress = "https://www.barbora.lv/";
            var catLinks = web.LoadFromBrowser(homePageAdress);
           
            var categoryMenuNodes = catLinks.DocumentNode.SelectNodes("(//li[@class='b-categories-root-category'])/a");

            Start3:

            int urlNum = 0;


            string subLinkText = categoryMenuNodes[catNum].OuterHtml.ToString().Replace("\n", "").Replace("<a href=\"", "").Replace(" ", "");
            if (subLinkText.Contains("\">"))
            {
                subLinkText = subLinkText.Substring(0, subLinkText.IndexOf("\">"));
            }
            string subUrl = "https://www.barbora.lv" + subLinkText;
            var dox = web.LoadFromBrowser(subUrl);
            var menuNodes = dox.DocumentNode.SelectNodes("(//div[@class='b-single-category--box'])/h3");

            int catMenuCount = categoryMenuNodes.Count;
            int menuCount = menuNodes.Count;

            Start:

            labelProcess.Visible = true;
            catlabel.Text = "category: " + (catNum + 1) + " / " + (categoryMenuNodes.Count());
            urllabel.Text = " subcategory: " + (urlNum + 1) + " / " + menuNodes.Count();

            async Task<List<ProductData>> InformationFromPage(int PageNum)
            {
                Start2:

                string urlText = menuNodes[urlNum].OuterHtml.ToString().Replace("\n", "").Replace(" ", "");

                if (urlText.Contains("\">"))
                {
                    urlText = urlText.Substring(0, urlText.IndexOf("\">"));
                    urlText = urlText.Substring((urlText.IndexOf("href=") + 6), (urlText.Length - (urlText.IndexOf("href=") + 6)));

                }

                string url = "https://www.barbora.lv" + urlText;


                if (PageNum != 0)
                    url = url + "?page=" + PageNum.ToString();


                var doc = web.LoadFromBrowser(url);



                var descriptionNodes = doc.DocumentNode.SelectNodes("(//div/a/span[@itemprop='name'])");
                var regularPriceNodes = doc.DocumentNode.SelectNodes("(//div[@class='b-product-prices-block'])");
                var actionPriceNodes = doc.DocumentNode.SelectNodes("(//div[@class='b-product-price-current'])");
                var discountNodes = doc.DocumentNode.SelectNodes("(//div[@class='b-product-price--extra'])");
                var linkNodes = doc.DocumentNode.SelectNodes("(//div[@class='b-product-wrap-img']/a[1])");
                var pictureNodes = doc.DocumentNode.SelectNodes("(//div[@class='b-product-wrap-img']/a/img)");
                var productInfoNodes = doc.DocumentNode.SelectNodes("(//div/a/span[@itemprop='name'])");
                var categoryNodes = doc.DocumentNode.SelectSingleNode("(//li/a/span[@itemprop='name'])[2]").InnerText;
                var subCategoryNodes = doc.DocumentNode.SelectSingleNode("(//li/a/span[@itemprop='name'])[3]").InnerText;
                var subSubCategoryNodes = doc.DocumentNode.SelectSingleNode("(//li/a/span[@itemprop='name'])[3]").InnerText;


                if (regularPriceNodes == null)
                {
                    if (urlNum < menuCount)
                    {
                        regularPriceNodes = doc.DocumentNode.SelectNodes("(//div/a/span[@itemprop='name'])"); 
                        actionPriceNodes = doc.DocumentNode.SelectNodes("(//div/a/span[@itemprop='name'])"); 
                        discountNodes = doc.DocumentNode.SelectNodes("(//div/a/span[@itemprop='name'])"); 

                    }

                    else return null;

                }


                string[] cate = new string[descriptionNodes.Count];
                string[] subCate = new string[descriptionNodes.Count];
                string[] subSubCate = new string[descriptionNodes.Count];
                for (int i = 0; i < descriptionNodes.Count; i++)
                {
                    cate[i] = categoryNodes;
                    subCate[i] = subCategoryNodes;
                    subSubCate[i] = subSubCategoryNodes;
                }



                var description = descriptionNodes.Select(node => node.InnerText);
                var discount = discountNodes.Select(node => node.InnerText);
                var actionPrice = actionPriceNodes.Select(node => node.InnerText);
                var regularPrice = regularPriceNodes.Select(node => node.InnerText);
                var linkInfo = linkNodes.Select(node => node.OuterHtml);
                var pictureInfo = pictureNodes.Select(node => node.OuterHtml);
                var productInfo = productInfoNodes.Select(node => node.OuterHtml);
                var category = cate;
                var subcategory = subCate;
                var subsubcategory = subSubCate;
                var result1 = description.ZipTen(actionPrice, regularPrice, discount, linkInfo, pictureInfo, productInfo, category, subcategory, subsubcategory, (name, action, regular, disco, link, picture, info, cat, sub, subsub) => new ProductData()
                { Description = name, ActionPrice = action, RegularPrice = regular, Discount = disco, Link = link, PictureLink = picture, ProductInformation = info, Category = cat, SubCategory = sub, SubSubCategory = subsub }).ToList();
                return result1;


            }


            int PageNum1 = 1;
            var products = await InformationFromPage(0);


            while (products.Count > 0)
            {
                foreach (var product in products)
                    table.Rows.Add(product.Description.Replace("\n", "").Replace("                                                                    ", "").Replace("                                                            ", ""),
                        product.ActionPrice.Replace("\n", "").Replace(",", ".").Replace(" ", ""),
                        product.RegularPrice.Replace("\n", "").Replace(",", ".").Replace(" ", ""),
                        product.Discount.Replace("\n", "").Replace(",", ".").Replace(" ", ""),
                        product.Link.Replace("\n", "").Substring((product.Link.IndexOf("href=") + 6), (product.Link.Length - (product.Link.IndexOf("href=") + 6))),
                        product.PictureLink.Replace("\n", ""),
                        product.ProductInformation.Replace("\n", ""),
                        product.Category.Replace("\n", "").Replace("       ", "").Replace("        ", "").Replace("    ", ""),
                        product.SubCategory.Replace("\n", "").Replace("       ", "").Replace("        ", "").Replace("    ", ""),
                        product.SubSubCategory.Replace("\n", "").Replace("       ", "").Replace("        ", "").Replace("    ", ""));

                PageNum1++;


                string urlText1 = menuNodes[urlNum].OuterHtml.ToString().Replace("\n", "").Replace(" ", "");

                if (urlText1.Contains("\">"))
                {
                    urlText1 = urlText1.Substring(0, urlText1.IndexOf("\">"));
                    urlText1 = urlText1.Substring((urlText1.IndexOf("href=") + 6), (urlText1.Length - (urlText1.IndexOf("href=") + 6)));

                }

                string url1 = "https://www.barbora.lv" + urlText1;


                if (PageNum1 != 0)
                    url1 = url1 + "?page=" + PageNum1.ToString();

                int pNum = 0;

                var doc1 = web.LoadFromBrowser(url1);
                var pageNumberNodes = doc1.DocumentNode.SelectNodes("(//li[@class='active'])");
                var pageNumber = pageNumberNodes.Select(node => node.InnerText);

                int ix = 0;
                string s = pageNumber.Last();
                bool result = int.TryParse(s, out ix);

                if (result == false)
                {
                    pNum = 0;
                }
                else pNum = ix;


                if (products.Count != 52 || PageNum1 != pNum)
                {
                    labelProcess.Visible = false;


                    if (urlNum < menuCount)
                    {
                        urlNum++;
                        if (urlNum == menuCount)
                        {
                            catNum++;
                            if (catNum == categoryMenuNodes.Count())
                            {
                                MessageBox.Show("The parsing task have been completed!" + " " + DateTime.Today);
                                break;
                            }

                            urlNum = 0;
                            goto Start3;
                        }

                        goto Start;

                    }

                    else break;


                }

                if (await InformationFromPage(PageNum1) != null)
                {

                    products = await InformationFromPage(PageNum1);

                }

                else break;

            }



            labelProcess.Visible = false;

        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            labelProcess.Visible = false;

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void urllabel_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }



}
