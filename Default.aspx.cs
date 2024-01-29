using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath;
    public string Currentyear;
    protected void Page_Load(object sender, EventArgs e)
    {
        Currentyear = DateTime.Now.Year.ToString();
    }



    public string GetProjectsData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select Top 6 proId, proName, proDesc, proBrochure, proImage from Products where delMark=0 order by proId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {
                    //string className = "";
                    //int i = 0;
                    //strMarkup.Append("<div class=\"carousel-inner\">");
                    foreach (DataRow row in dttest.Rows)
                    {
                        
                        strMarkup.Append("<div class=\"swiper-slide\">");
                        strMarkup.Append("<div class=\"p-3\">");
                        strMarkup.Append("<a href=\"product\" class=\"text-decoration-none\">");
                        strMarkup.Append("<div class=\"border\" style=\"width:400px; height:350px; overflow:hidden\">");
                        strMarkup.Append("<div class=\"p-2\">");
                        strMarkup.Append("<img src=\""+rootPath+ "upload/product/gallery/"+row["proImage"].ToString()+ "\" class=\"d-block w-100 img-fluid\"/>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("</div>");
                        strMarkup.Append("<div class=\"px-4\" style=\"width:200px;\">");

                        strMarkup.Append("<div class=\"projectbox\">");

                        strMarkup.Append("<div class=\"p-3\">");

                        strMarkup.Append("<p class=\"semiBold semiMedium mb-2 colorSec\">"+row["proName"].ToString()+"</p>");
                        string testinfo = row["proDesc"].ToString().Length >= 89 ? row["proDesc"].ToString().Substring(0, 89) + "..." : row["proDesc"].ToString();

                        strMarkup.Append("<p class=\"fontRegular clrdarkgrey mb-2\">" + testinfo + "");
                        strMarkup.Append("<span class=\"space15\"></span>");
                        strMarkup.Append("<a href=\""+rootPath+ "upload/product/brochure/"+row["proBrochure"].ToString() +"\" class=\"btnEvent\">Brochure</a>");
                        strMarkup.Append("</p>");

                        strMarkup.Append("</div>");

                        strMarkup.Append("</div>");



                        strMarkup.Append("</div>");

                        strMarkup.Append("</a>");
                        strMarkup.Append("</div>");//p-3 close
                        strMarkup.Append("</div>");//swiper close
                       


                    }
                   // strMarkup.Append("</div>");

                    return strMarkup.ToString();
                }
                else
                {
                    return "No testimonials to display";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }

    }


    //Get News
    public string GetNewsData()
    {
        try
        {
            StringBuilder strMarkup = new StringBuilder();
            using (DataTable dttest = c.GetDataTable("select Top 3 newsId, newsDate,  newsTitle, newsDesc, newsPhoto from NewsData where delMark=0 order by newsId DESC"))
            {
                if (dttest.Rows.Count > 0)
                {
                    //string className = "";
                    //int i = 0;
                    //strMarkup.Append("<div class=\"carousel-inner\">");
                    foreach (DataRow row in dttest.Rows)
                    {
                        if (c.IsRecordExist("Select newsId From NewsData Where newsId=" + row["newsId"].ToString() + ""))
                        {
                            strMarkup.Append("<div class=\"col-lg-4\">");
                            strMarkup.Append("<div class=\"newsImg\">");
                            if (row["newsPhoto"]!=DBNull.Value && row["newsPhoto"]!=null && row["newsPhoto"].ToString()!="")
                            {
                                strMarkup.Append("<img src=\"" + rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + "\" class=\"img-fluid rounded mb-3 newsImg w-100\"/>");
                            }
                            else
                            {
                                strMarkup.Append("<img src=\"iamges/techsell-news.jpg\" class=\"img-fluid rounded mb-3 newsImg\" />");
                            }
                            strMarkup.Append("</div>");
                            DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                            strMarkup.Append("<span class=\"fontRegular small colorPrime\"> " + nDate.ToString("dd MMM yyyy") + " / <span class=\"small colorBlack\">Tushar Enterprises Techsell</span></span>");
                            strMarkup.Append("<span class=\"space10\"></span>");
                            string newsTitle = row["newsTitle"].ToString().Length >= 74 ? row["newsTitle"].ToString().Substring(0, 74) + "..." : row["newsTitle"].ToString();
                            strMarkup.Append("<h3 class=\"nwstitle semiBold semiMedium mb-2\">" + newsTitle + "</h3>");
                            string newsDesc = row["newsDesc"].ToString().Length >= 170 ? row["newsDesc"].ToString().Substring(0, 170) + "..." : row["newsDesc"].ToString();
                            strMarkup.Append("<p class=\"fontRegular small line-ht-5\">" + newsDesc + "</p>");
                            strMarkup.Append("<a href=\"news\" class=\"colorPrime text-decoration-none\">Read More</a>");

                            //strMarkup.Append("</div>");//p-3 close
                            strMarkup.Append("</div>");//col-lg-4
                       }
                    }
                    return strMarkup.ToString();
                }
                else
                {
                    return "No testimonials to display";
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }

    }
}