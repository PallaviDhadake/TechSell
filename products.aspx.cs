using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
public partial class products : System.Web.UI.Page
{
    public string sideNavDisplay, productList, bCrumb;
    public string[] arrDetails = new string[10];
    iClass c = new iClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string category = Page.RouteData.Values["Category"] as string;
                string productId = Page.RouteData.Values["ProductId"] as string;

                if (!string.IsNullOrEmpty(productId))
                {
                    // Product details page
                    DisplayDecision(productId);

                }
                else if (!string.IsNullOrEmpty(category))
                {
                    // Category page
                    DisplayDecision(category);

                }
                else
                {
                    // Default behavior (show all products or a specific category if needed)
                    divProducts.Visible = true;
                    divDetails.Visible = false;
                    ShowProductList(1); // Default category ID, modify as needed
                }
           }
        }
        catch (Exception ex)
        {
            productList = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }



    private void DisplayDecision(string catString)
    {
        try
        {
            int catIdX = 0;
            if (catString == "")
            {
                catIdX = 1;
            }
            else
            {
                string[] arrLink = catString.Split('-');

                if (c.IsNumeric(arrLink[arrLink.Length - 1]))
                {
                    divProducts.Visible = false;
                    divDetails.Visible = true;
                    ShowProductDetails(Convert.ToInt32(arrLink[arrLink.Length - 1]));


                }
                else
                {
                    string catVarName = catString.Replace("-", " ");
                    catIdX = Convert.ToInt32(c.GetReqData("ProCategory", "catId", "catName='" + catVarName + "'"));

                    divProducts.Visible = true;
                    divDetails.Visible = false;
                    ShowProductList(catIdX);
                }
            }
        }
        catch (Exception ex)
        {
            productList = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }

    private void ShowProductList(int catIdX)
    {
        try
        {
            bCrumb = "<li><a href=\"" + Master.rootPath + "\">Home</a></li><li>»</li><li><span>" + c.GetReqData("ProCategory", "catName", "catId=" + catIdX).ToString() + "</span></li>";

            //Menu Markup Starts
            DataTable dtCategory = new DataTable();
            dtCategory = c.GetDataTable("Select * From ProCategory");

            this.Title = c.GetReqData("ProCategory", "catName", "catId=" + catIdX).ToString() + " Sales Services in Sangli Kolhapur | Maxvell, Sangli";

            StringBuilder strMarkup = new StringBuilder();

            foreach (DataRow row in dtCategory.Rows)
            {
                string rdrUrl = row["catName"].ToString().ToLower().Replace(" ", "-");

                strMarkup.Append("<li><a href=\"" + Master.rootPath + "product/" + c.UrlGenerator(rdrUrl) + "\">" + row["catName"].ToString() + "</a></li>");
            }
            strMarkup.Append("<li><a href=\"" + Master.rootPath + "bank-display-boards\">Bank Display Boards</a></li>");
            strMarkup.Append("<li><a href=\"" + Master.rootPath + "street-lights\">Street Lights</a></li>");
            sideNavDisplay = strMarkup.ToString();

            strMarkup.Length = 0;
            dtCategory.Dispose();
            dtCategory = null;

            //Product Listing Starts
            DataTable dtProducts = new DataTable();
            dtProducts = c.GetDataTable("Select a.*, b.brandName, c.catName From Products a Inner Join Brands b on a.brandId=b.brandId Inner Join ProCategory c on a.catId=c.catId Where a.catId=" + catIdX);


            int rCount = 1;
            if (dtProducts.Rows.Count > 0)
            {

                foreach (DataRow pRow in dtProducts.Rows)
                {
                    strMarkup.Append("<div class=\"row\">");
                    strMarkup.Append("<div class=\"col-md-4\">");
                    //strMarkup.Append("<div class=\"prImgBox\">");
                    strMarkup.Append("<img src=\"" + Master.rootPath + "upload/product/gallery/" + pRow["proImage"].ToString() + "\" class=\"img-fluid\" />");
                    strMarkup.Append("</div>");

                    strMarkup.Append("<div class=\"col-md-8\">");
                    //strMarkup.Append("<div class=\"prDetailBox\">");
                    //strMarkup.Append("<div class=\"prOffset\">");

                    string detailUrl = "product/" + c.UrlGenerator(pRow["brandName"].ToString().ToLower().Replace(" ", "-") + "-" + pRow["proName"].ToString().ToLower().Replace(" ", "-") + "-" + pRow["proId"].ToString());
                    strMarkup.Append("<a href=\"" + Master.rootPath + detailUrl + "\" class=\"prAnch\">" + pRow["brandName"].ToString() + " " + pRow["proName"].ToString() + "</a>");

                    string[] arrFeatures = pRow["proFeatures"].ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    strMarkup.Append("<ul>");
                    int fCount = 0;

                    foreach (string fetPoint in arrFeatures)
                    {
                        if (fCount < 4)
                        {
                            strMarkup.Append("<li>" + fetPoint + "</li>");
                        }
                        fCount++;
                    }
                    strMarkup.Append("</ul>");

                    strMarkup.Append("<span class=\"space30\"></span>");
                    strMarkup.Append("<a class=\"prDetAnch\" href=\"" + Master.rootPath + detailUrl + "\">Details</a>");
                    //strMarkup.Append("</div>");
                    // strMarkup.Append("</div>");
                   
                    strMarkup.Append("</div>");
                    strMarkup.Append("<span class=\"greyLine\">");
                    strMarkup.Append("</div>");

                    strMarkup.Append("<div class=\"float_clear\"></div>");

                    if (rCount < dtProducts.Rows.Count)
                    {
                        strMarkup.Append("<span class=\"space15\"></span>");
                        strMarkup.Append("<span class=\"lineSpace\"></span>");
                        strMarkup.Append("<span class=\"space15\"></span>");
                    }

                    rCount++;
                }

                productList = strMarkup.ToString();
            }
            else
            {
                productList = "There are no products under this category";
            }
            dtProducts.Dispose();
            dtProducts = null;
        }
        catch (Exception ex)
        {
            productList = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }


    private void ShowProductDetails(int proIdX)
    {
        try
        {
            DataTable dtProduct = new DataTable();
            dtProduct = c.GetDataTable("Select a.*, b.brandName, c.catName From Products a Inner Join Brands b on a.brandId=b.brandId Inner Join ProCategory c on a.catId=c.catId Where a.proId=" + proIdX);
            StringBuilder strMarkup = new StringBuilder();



            if (dtProduct.Rows.Count > 0)
            {
                DataRow row = dtProduct.Rows[0];


                this.Title = row["brandName"].ToString() + " " + row["proName"].ToString() + " Sales Services in Sangli Kolhapur | Maxvell, Sangli";

                string catUrl = Master.rootPath + "product/" + row["catName"].ToString().ToLower().Replace(" ", "-");

                bCrumb = "<li><a href=\"" + Master.rootPath + "\">Home</a></li><li>»</li><li><a href=\"" + catUrl + "\">" + row["catName"].ToString() + "</a></li><li>»</li><li><span>" + row["brandName"] + " " + row["proName"].ToString() + "</span></li>";


                arrDetails[0] = Master.rootPath + "upload/product/gallery/" + row["proImage"].ToString();
                arrDetails[1] = row["brandName"].ToString() + " " + row["proName"].ToString();

                string[] arrFeat = row["proFeatures"].ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int fCount = 1;
                foreach (string feat in arrFeat)
                {
                    if (fCount <= 4)
                    {
                        arrDetails[2] = arrDetails[2] + "<li>" + feat + "</li>";
                    }
                    fCount++;
                }

                if (row["proBrochure"] != DBNull.Value && row["proBrochure"].ToString() != "")
                {
                    arrDetails[3] = "<a href=\"" + Master.rootPath + "upload/product/brochure/" + row["proBrochure"].ToString() + "\" target=\"_blank\" class=\"dlAnch\">Brochure</a>";
                }
                else
                {
                    arrDetails[3] = "";
                }
                if (row["proVideo"] != DBNull.Value && row["proVideo"].ToString() != "")
                {
                    arrDetails[4] = "<a href=\"" + row["proVideo"].ToString() + "\" class=\"vidAnch swipebox-video\" rel=\"youtube\" >Video</a>";

                }
                else
                {
                    arrDetails[4] = "";
                }

                arrDetails[5] = row["proDesc"].ToString().Replace(Environment.NewLine, "<br/>");


                arrFeat = row["proFeatures"].ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string feat in arrFeat)
                {
                    arrDetails[6] = arrDetails[6] + "<li>" + feat + "</li>";
                }


                arrDetails[7] = row["proSpecs"].ToString();

                arrDetails[8] = Master.rootPath + "enquiry/" + c.UrlGenerator((row["brandName"].ToString().ToLower() + "-" + row["proName"].ToString().ToLower() + "-" + proIdX.ToString()).Replace(" ", "-"));
            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            //productDisplay = c.errNotification(3, ex.Message.ToString());
            return;
        }
    }
}
    