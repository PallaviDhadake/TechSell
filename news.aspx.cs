using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public partial class news : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, newsstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Page.RouteData.Values["newsId"].ToString()))
                {
                    NewsMarkup();
                }
                else
                {
                    string[] arrLinks = Page.RouteData.Values["newsId"].ToString().Split('-');
                    GetNewsDetails(Convert.ToInt32(arrLinks[arrLinks.Length - 1]));

                }
            }
        }
        catch (Exception ex)
        {
            newsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void NewsMarkup()
    {
        try
        {
            using (DataTable dtevnt = c.GetDataTable("select newsId, Convert(varchar(20), newsDate ,103) as newsDate, newsTitle, newsDesc, newsPhoto From NewsData where delMark=0 Order By newsDate desc, newsId desc"))
            {
                if (dtevnt.Rows.Count > 0)
                {
                    StringBuilder strMarkup = new StringBuilder();
                    int counter = 1;
                    foreach (DataRow row in dtevnt.Rows)
                    {
                        strMarkup.Append("<div class=\"col-md-4\">");
                        if (row["newsPhoto"] != DBNull.Value && row["newsPhoto"].ToString() != "" && row["newsPhoto"].ToString() != "no-photo.png" && row["newsPhoto"] != null)
                        {
                            strMarkup.Append("<img src=\"" + Master.rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + " \" alt=\"" + row["newsPhoto"].ToString() + " \"  class=\"img-fluid w-100 newsborder\" >");
                        }
                        else
                        {
                            strMarkup.Append("<img src=\"images/techsell-news.jpg\" class=\"img-fluid\">");
                        }
                        strMarkup.Append("</div>");
                        strMarkup.Append("<div class=\"col-md-8\">");

                        string newsTitle = row["newsTitle"].ToString().Length >= 72 ? row["newsTitle"].ToString().Substring(0, 72) + "..." : row["newsTitle"].ToString();

                       string existUrl = Master.rootPath + "news/";

                        string nUrl = existUrl + c.UrlGenerator(row["newsTitle"].ToString().ToLower() + "-" + row["newsId"].ToString());

                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"semiBold semiMedium colorPrime text-decoration-none eventtitle\">" + newsTitle + "</a>");

                        strMarkup.Append("<span class=\"space5\"></span>");

                        //DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                        //DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                        //strMarkup.Append("<span class=\"clrGrey small fst-italic\">" + nDate.ToString("dd MMM yyyy") + "</span>");

                        string newsdesc = row["newsDesc"].ToString().Length >= 72 ? row["newsDesc"].ToString().Substring(0, 254) + "..." : row["newsDesc"].ToString();

                        strMarkup.Append("<p class=\"fontRegular light  line-ht-7 mt-3 mb-4\">" + newsdesc + "</p>");
                        strMarkup.Append("<a href=\"" + nUrl + "\" class=\"btnexplore\">Explore</a>");
                        strMarkup.Append("</div>");

                        if (counter < dtevnt.Rows.Count)
                        {
                            strMarkup.Append("<span class=\"greyLine\"></span>");
                        }
                        counter++;

                    }
                    newsstr = strMarkup.ToString();
                }
                else
                {
                    newsstr = "<span class=\"infoClr\">Nothing to display come back later.....</span>";
                }
            }
        }
        catch (Exception ex)
        {
            newsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }

    private void GetNewsDetails(int NewsIdx)
    {
        try
        {
            //c.ExecuteQuery("Update NewsData Set readCount=readCount+1 Where newsId=" + EvntIdx);
            using (DataTable dtNws = c.GetDataTable("Select * From NewsData Where newsId=" + NewsIdx))
            {
                if (dtNws.Rows.Count > 0)
                {
                    DataRow row = dtNws.Rows[0];
                    StringBuilder strMarkup = new StringBuilder();

                    this.Title = row["newsTitle"].ToString() + "| Latest News of TechSell | Tushar Enterprises.";

                    strMarkup.Append("<h2 class=\"pageH2 themeClrPrime mrg_B_5 capitalize\">" + row["newsTitle"].ToString() + "</h2>");
                    DateTime nDate = Convert.ToDateTime(row["newsDate"]);
                    strMarkup.Append("<span class=\"newspost\">Admin | " + nDate.ToString("dd MMM yyyy") + "</span>");

                    strMarkup.Append("<span class=\"space5\"></span>");

                    //Sharing Options
                    strMarkup.Append("<div class=\"a2a_kit a2a_kit_size_24 a2a_default_style\" >");
                    strMarkup.Append("<a class=\"a2a_dd\" href=\"https://www.addtoany.com/share\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_facebook\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_twitter\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_google_plus\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_pinterest\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_email\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_linkedin\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_reddit\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_stumbleupon\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_digg\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_tumblr\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_whatsapp\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_blogger_post\"></a>");
                    strMarkup.Append("<a class=\"a2a_button_delicious\"></a>");
                    strMarkup.Append("</div>");
                    strMarkup.Append("<script async src=\"https://static.addtoany.com/menu/page.js\"></script>");

                    //Add Page sharing links code here
                    strMarkup.Append("<div class=\"float_clear\"></div>");
                    strMarkup.Append("<div class=\"space15\"></div>");

                    if (row["newsPhoto"] != DBNull.Value && row["newsPhoto"].ToString() != "" && row["newsPhoto"].ToString() != "no-photo.png" && row["newsPhoto"] != null)
                    {
                        strMarkup.Append("<img src=\"" + Master.rootPath + "upload/news/thumb/" + row["newsPhoto"].ToString() + " \" alt=\"" + row["newsPhoto"].ToString() + " \"  class=\"img-fluid w-100 newsborder\" >");
                    }
                    strMarkup.Append("<span class=\"\"></span>");
                    strMarkup.Append("<p class=\"paraTxt\">" + Regex.Replace(row["newsDesc"].ToString(), @"\r\n?|\n", "<br />") + "</p>");
                    strMarkup.Append("<span class=\"space10\"></span>");


                    //using (DataTable dttest = c.GetDataTable("Select EvntGalPhotoId, FK_EvntId, EvntGalPhoto  from EventGalleryPhotos Where FK_EvntId=" + NewsIdx + ""))
                    //{
                    //    if (dttest.Rows.Count > 0)
                    //    {


                    //        strMarkup.Append("<div class=\"row\">");


                    //        foreach (DataRow prow in dttest.Rows)
                    //        {
                    //            strMarkup.Append("<div class=\"col-md-3\">");
                    //            strMarkup.Append("<div class=\"border\">");
                    //            strMarkup.Append("<div class=\"p-2\">");

                    //            if (prow["EvntGalPhoto"] != DBNull.Value && prow["EvntGalPhoto"].ToString() != "" && prow["EvntGalPhoto"].ToString() != "no-photo.png" && prow["EvntGalPhoto"] != null)
                    //            {

                    //                strMarkup.Append("<a href=\"" + Master.rootPath + "upload/events/" + prow["EvntGalPhoto"].ToString() + "\"  data-fancybox=\"imggroup\">");
                    //                strMarkup.Append("<img src=\"" + Master.rootPath + "upload/events/" + prow["EvntGalPhoto"].ToString() + "\" alt=\"" + prow["EvntGalPhoto"].ToString() + "\" class=\"img-fluid w-100\">");
                    //                strMarkup.Append("</a>");

                    //            }
                    //            strMarkup.Append("</div>");
                    //            strMarkup.Append("</div>");
                    //            strMarkup.Append("</div>");

                    //        }

                    //        strMarkup.Append("</div>");
                    //    }
                    //}

                    newsstr = strMarkup.ToString();
                    strMarkup.Append("<div class=\"float_clear\">");
                }
            }

        }
        catch (Exception ex)
        {
            newsstr = c.ErrNotification(3, ex.Message.ToString());
            return;
        }

    }

}