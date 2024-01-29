using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class enquiry : System.Web.UI.Page
{
    iClass c = new iClass();
    public string prMarkup, rootPath, errMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        string productId = Page.RouteData.Values["ProductId"] as string;
        string category = Page.RouteData.Values["Category"] as string;

        if (!IsPostBack)
        {
            if (String.IsNullOrEmpty(Page.RouteData.Values["ProductId"].ToString()))
            {
              //  NewsMarkup();
            }
            else
            {
                string[] arrLinks = Page.RouteData.Values["ProductId"].ToString().Split('-');
                ProductMarkup(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));

            }
        }

    }


    private void ProductMarkup(int proIdX)
    {
        try
        {
            DataTable dtProInfo = new DataTable();
            dtProInfo = c.GetDataTable("Select a.proName, LEFT(a.proDesc, 100) + '...' as proDesc,  a.proImage, b.brandName From Products a Inner Join Brands b on a.brandId=b.brandId Where a.proId=" + proIdX);

            StringBuilder strMarkup = new StringBuilder();

            if (dtProInfo.Rows.Count > 0)
            {
                DataRow row = dtProInfo.Rows[0];

                this.Title = "Enquiry For " + row["proName"].ToString() + " | Tushar Enterprises, Sangli";

                strMarkup.Append("<div class=\"pad_10\">");
                strMarkup.Append("<div class=\"enqImage\">");
                strMarkup.Append("<div class=\"border\">");
                strMarkup.Append("<div class=\"p-2\">");

                strMarkup.Append("<img src=\"" + Master.rootPath + "upload/product/gallery/thumb/" + row["proImage"].ToString() + "\" class=\"img-fluid\" />");
                strMarkup.Append("</div>");
                strMarkup.Append("</div>");
                strMarkup.Append("</div>");

                strMarkup.Append("<div class=\"enqDetails\">");
                strMarkup.Append("<div class=\"p-3\">");
                strMarkup.Append("<a href=\"" + Master.rootPath + "product/" + row["brandName"].ToString().ToLower().Replace(" ", "-") + "-" + row["proName"].ToString().ToLower().Replace(" ", "-") + "-" + proIdX.ToString() + "\" class=\"prAnch\">" + row["brandName"].ToString() + " " + row["proName"].ToString() + "</a>");
                strMarkup.Append("<p class=\"prDesc\">" + row["proDesc"].ToString() + "</p>");
                strMarkup.Append("</div>");
                strMarkup.Append("</div>");
                strMarkup.Append("<div class=\"float_clear\"></div>");
                strMarkup.Append("</div>");

                prMarkup = strMarkup.ToString();

            }
            else
            {
                prMarkup = "Invalid Product";
            }

        }
        catch (Exception ex)
        {
            prMarkup = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text == "" || txtMobile.Text == "" || txtCompany.Text == "" || txtCity.Text == "" || txtAddress.Text == "")
            {
                errMsg = c.ErrNotification(2, "All * Marked fields are mendatory");
                return;
            }

            string productName = "";

            StringBuilder strMarkup = new StringBuilder();
            strMarkup.Append("Dear Sir,");
            strMarkup.Append("<br/><br/>");
            strMarkup.Append("You have a new enquiry on your website.");
            strMarkup.Append("<br/>");

            if (Page.RouteData.Values["ProductId"] != null)
            {
                string[] arrLink = Page.RouteData.Values["ProductId"].ToString().Split('-');
                int proId = Convert.ToInt32(arrLink[arrLink.Length - 1]);

                productName = c.GetReqData("Products", "proName", "proId=" + proId).ToString();
                strMarkup.Append("Enquiry for : <b>" + productName + "</b>");
                strMarkup.Append("<br/>");
            }
            strMarkup.Append("Name : <b>" + txtName.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("Company Name : <b>" + txtCompany.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("City : <b>" + txtCity.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("Address : <b>" + txtAddress.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("Email Id : <b>" + txtEmail.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("Mobile No. : <b>" + txtMobile.Text + "</b>");
            strMarkup.Append("<br/>");
            strMarkup.Append("Message : <b>" + txtMessage.Text + "</b>");
            strMarkup.Append("<br/>");

            if (Page.RouteData.Values["ProductId"] != null)
            {
                c.SendMail("info@tusharent.in", "Tushar Ent", "pallavidhadake20@gmail.com", strMarkup.ToString(), "New Enquiry for " + productName, "klp_tusharent@yahoo.com", true, "", "");
            }
            else
            {
                c.SendMail("info@tusharent.in", "Tushar Ent", "pallavidhadake20@gmail.com", strMarkup.ToString(), "New Enquiry at Tushar Ent", "klp_tusharent@yahoo.com", true, "", "");
            }
            txtAddress.Text = txtCity.Text = txtCompany.Text = txtEmail.Text = txtMessage.Text = txtMobile.Text = txtName.Text = "";
            errMsg = c.ErrNotification(1, "Thank you for your enquiry. We will contact you soon.");


            //c.sendMail

        }
        catch (Exception ex)
        {
            errMsg = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }
}