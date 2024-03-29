﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

using System.Net;
using System.Net.Mail;
/// <summary>
/// Summary description for iClass
/// </summary>
public class iClass : IDisposable
{
    public iClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    void IDisposable.Dispose()
    {

    }
    /// <summary>
    /// Opens connection to database
    /// </summary>
    /// <returns>connection string</returns>
    public string OpenConnection()
    {
        return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TusharEntData"].ConnectionString;
    }

    /// <summary>
    /// Executes a SQL Query
    /// </summary>
    /// <param name="strQuery">SQL Query as String</param>
    public void ExecuteQuery(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Used to check if record exists or not
    /// </summary>
    /// <param name="strQuery">SQL Query as string</param>
    /// <returns>True/False</returns>
    public bool IsRecordExist(string strQuery)
    {
        try
        {

            bool rValue = false;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);

            cmd.CommandText = strQuery;
            dr = cmd.ExecuteReader();

            rValue = dr.HasRows;
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Gets next Id in column(Integer)
    /// </summary>
    /// <param name="tableName">Name of Table in Databse</param>
    /// <param name="fieldName">Name of Column</param>
    /// <returns>Next value in column</returns>
    public int NextId(string tableName, string fieldName)
    {
        try
        {
            int retValue = 1;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = default(SqlDataReader);
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MAX(" + fieldName + ") as maxNo From " + tableName;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if ((dr["maxNo"]) != System.DBNull.Value)
                    {
                        retValue = Convert.ToInt32(dr["maxNo"]) + 1;
                    }
                    else
                    {
                        retValue = 1;
                    }
                }
            }
            else
            {
                retValue = 1;
            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Used to get single value from databse table
    /// </summary>
    /// <param name="tableName">Name of Database Table</param>
    /// <param name="fieldName">Naem of Column</param>
    /// <param name="whereCon">Where Condition</param>
    /// <returns>Value as object</returns>
    public object GetReqData(string tableName, string fieldName, string whereCon)
    {
        try
        {
            object retValue = null;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = default(SqlDataReader);
            cmd.CommandText = whereCon == "" ? "Select " + fieldName + " as colName From " + tableName : "Select " + fieldName + " as colName From " + tableName + " Where " + whereCon;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["colName"] == DBNull.Value)
                {
                    retValue = null;
                }
                else
                {
                    retValue = dr["colName"];
                }

            }
            dr.Close();
            cmd.Dispose();
            con.Close();
            con = null;
            return retValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Used to display error Messagge on Client Side
    /// </summary>
    /// <param name="errType">Error Type as byte 1 for Succes/2 for Warning/3 for Error</param>
    /// <param name="errMsgStr">Message to display</param>
    /// <returns>Markup as string</returns>
    public string ErrNotification(byte errType, string errMsgStr)
    {
        try
        {
            string rValue = "";

            switch (errType)
            {
                case 1:
                    rValue = "<span class='success'><b>Success:</b> " + errMsgStr + "</span>";
                    break;
                case 2:
                    rValue = "<span class='warning'><b>Warning:</b> " + errMsgStr + "</span>";
                    break;
                case 3:
                    rValue = "<span class='error'><b>Error:</b> " + errMsgStr + "</span>";
                    break;
            }

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Checks if input Email Id is in standard email format
    /// </summary>
    /// <param name="emailAddress">input Email</param>
    /// <returns>Status(True/False)</returns>
    public bool EmailAddressCheck(string emailAddress)
    {
        try
        {
            bool rValue = false;
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(emailAddress, pattern);


            if (emailAddressMatch.Success)
            {
                rValue = true;
            }
            else
            {
                rValue = false;
            }

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public long returnAggregate(string strQuery)
    {
        try
        {
            long rValue = 0;
            SqlConnection con = new SqlConnection(OpenConnection());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;

            object result = cmd.ExecuteScalar();

            if (result.GetType() != typeof(DBNull))
            {
                rValue = Convert.ToInt32(result);
            }
            else
            {
                rValue = 0;

            }

            con.Close();
            con = null;
            cmd.Dispose();
            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    /// <summary>
    /// Returns Datatable using String query
    /// </summary>
    /// <param name="strQuery">Query</param>
    /// <returns>Datatable</returns>
    public DataTable GetDataTable(string strQuery)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());

            SqlDataAdapter da = new SqlDataAdapter(strQuery, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();
            con = null;

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void ErrorLogHandler(string pageName, string funcName, string errMsg)
    {
        string rootPath = ReturnHttp();

        string filePath = HttpContext.Current.Server.MapPath("~/error_log.txt");
        if (File.Exists(filePath))
        {
            StreamWriter writer = new StreamWriter(filePath, true);
            StringBuilder strError = new StringBuilder();

            strError.Append(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
            strError.Append(Environment.NewLine);
            strError.Append(pageName);
            strError.Append(Environment.NewLine);
            strError.Append(funcName);
            strError.Append(Environment.NewLine);
            strError.Append(errMsg);
            strError.Append(Environment.NewLine);
            strError.Append(Environment.NewLine);
            strError.Append(Environment.NewLine);
            writer.Write(strError.ToString());
            writer.Flush();
            writer.Close();
        }

    }


    /// <summary>
    /// Route Path of Project
    /// </summary>
    /// <param name="reqType">Type(0-Routepath/1-CSS/2-Javascript)</param>
    /// <returns>Domain Path(LocalHost/Online)</returns>
    public string ReturnHttp()
    {
        try
        {
            string rValue = null;
            string domain = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            string localFolder;

            if (domain.Contains("localhost") == true)
            {
                localFolder = "/";
                //localFolder = "/NNSW/";
            }
            else
            {
                localFolder = "/";
            }

            rValue = domain + localFolder;

            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    /// <summary>
    /// Creates SEO friendly url (Removes special characters from url)
    /// </summary>
    /// <param name="oldUrl">Current Url</param>
    /// <returns>Modified Url</returns>
    public string UrlGenerator(string oldUrl)
    {
        try
        {
            if (oldUrl.Contains("$") == true)
            {
                oldUrl = oldUrl.Replace("$", "");
            }
            if (oldUrl.Contains(" ") == true)
            {
                oldUrl = oldUrl.Replace(" ", "-");
            }
            if (oldUrl.Contains("+") == true)
            {
                oldUrl = oldUrl.Replace("+", "");
            }
            if (oldUrl.Contains(";") == true)
            {
                oldUrl = oldUrl.Replace(";", "");
            }
            if (oldUrl.Contains("=") == true)
            {
                oldUrl = oldUrl.Replace("=", "");
            }
            if (oldUrl.Contains("?") == true)
            {
                oldUrl = oldUrl.Replace("?", "");
            }
            if (oldUrl.Contains("@") == true)
            {
                oldUrl = oldUrl.Replace("@", "");
            }
            if (oldUrl.Contains("<") == true)
            {
                oldUrl = oldUrl.Replace("<", "");
            }
            if (oldUrl.Contains('"') == true)
            {
                oldUrl = oldUrl.Replace('"', '-');
            }
            if (oldUrl.Contains("'") == true)
            {
                oldUrl = oldUrl.Replace("'", "-");
            }
            if (oldUrl.Contains(">") == true)
            {
                oldUrl = oldUrl.Replace(">", "");
            }
            if (oldUrl.Contains("#") == true)
            {
                oldUrl = oldUrl.Replace("#", "");
            }
            if (oldUrl.Contains("{") == true)
            {
                oldUrl = oldUrl.Replace("{", "");
            }
            if (oldUrl.Contains("}") == true)
            {
                oldUrl = oldUrl.Replace("}", "");
            }
            if (oldUrl.Contains("|") == true)
            {
                oldUrl = oldUrl.Replace("|", "");
            }
            if (oldUrl.Contains("\\") == true)
            {
                oldUrl = oldUrl.Replace("\\", "");
            }
            if (oldUrl.Contains("^") == true)
            {
                oldUrl = oldUrl.Replace("^", "");
            }
            if (oldUrl.Contains("~") == true)
            {
                oldUrl = oldUrl.Replace("~", "");
            }
            if (oldUrl.Contains("[") == true)
            {
                oldUrl = oldUrl.Replace("[", "");
            }
            if (oldUrl.Contains("]") == true)
            {
                oldUrl = oldUrl.Replace("]", "");
            }
            if (oldUrl.Contains("`") == true)
            {
                oldUrl = oldUrl.Replace("`", "");
            }
            if (oldUrl.Contains("%") == true)
            {
                oldUrl = oldUrl.Replace("%", "percent");
            }
            if (oldUrl.Contains("&") == true)
            {
                oldUrl = oldUrl.Replace("&", "and");
            }
            if (oldUrl.Contains(":") == true)
            {
                oldUrl = oldUrl.Replace(":", "");
            }
            if (oldUrl.Contains(".") == true)
            {
                oldUrl = oldUrl.Replace(".", "-");
            }
            if (oldUrl.Contains(",") == true)
            {
                oldUrl = oldUrl.Replace(",", "-");
            }
            if (oldUrl.Contains("/") == true)
            {
                oldUrl = oldUrl.Replace("/", "");
            }

            if (oldUrl.Contains("(") == true)
            {
                oldUrl = oldUrl.Replace("(", "");
            }
            if (oldUrl.Contains(")") == true)
            {
                oldUrl = oldUrl.Replace(")", "");
            }
            if (oldUrl.Contains("--") == true)
            {
                oldUrl = oldUrl.Replace("--", "-");
            }
            if (oldUrl.EndsWith("-") == true)
            {
                oldUrl = oldUrl.Substring(0, oldUrl.Length - 1);
            }

            return oldUrl.ToLower();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// date Validation
    /// </summary>
    /// <param name="date">Date</param>
    /// <returns>True / False</returns>
    public bool IsDate(string date)
    {
        try
        {
            DateTime dt = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Function validates Mobile number
    /// </summary>
    /// <param name="mobileNo">mobile number</param>
    /// <returns>true/false</returns>
    public bool ValidateMobile(string mobileNo)
    {

        if (mobileNo.Length != 10)
        {
            return false;
        }
        char[] mobDigits = mobileNo.ToCharArray();

        if (mobDigits[0] == '0')
        {
            return false;
        }
        if (mobDigits[0] != '9' && mobDigits[0] != '8' && mobDigits[0] != '7')
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Used to fill DropDownList
    /// </summary>
    /// <param name="fieldStr">Display Contents(Column Name)</param>
    /// <param name="fieldVal">Value Content(Column Name)</param>
    /// <param name="tableName">Database Table Name</param>
    /// <param name="whereCond">Specific Condition (SQL Where Condition)</param>
    /// <param name="myComboBox">Name of DropDownList</param>
    public void FillComboBox(string fieldStr, string fieldVal, string tableName, string whereCond, string sortColumn, int ordType, DropDownList myComboBox)
    {
        try
        {
            SqlConnection con = new SqlConnection(OpenConnection());
            string strSql = "";
            if (whereCond == "")
            {
                if (sortColumn == "")
                {
                    strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName;
                }
                else
                {
                    if (ordType == 0)
                    {
                        strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Order By " + sortColumn;
                    }
                    else
                    {
                        strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Order By " + sortColumn + " Desc";
                    }
                }
            }
            else
            {
                if (sortColumn == "")
                {
                    strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Where " + whereCond;
                }
                else
                {
                    if (ordType == 0)
                    {
                        strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Where " + whereCond + " Order By " + sortColumn;
                    }
                    else
                    {
                        strSql = "SELECT " + fieldStr + ", " + fieldVal + " From " + tableName + " Where " + whereCond + " Order By " + sortColumn + " Desc";
                    }
                }

            }
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "myCombo");
            myComboBox.DataSource = ds.Tables[0];
            myComboBox.DataTextField = ds.Tables[0].Columns[fieldStr].ColumnName.ToString();
            myComboBox.DataValueField = ds.Tables[0].Columns[fieldVal].ColumnName.ToString();
            myComboBox.DataBind();

            myComboBox.Items.Insert(0, "<-Select->");
            myComboBox.Items[0].Value = "0";

            con.Close();
            con = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Optimizes the uploaded image
    /// </summary>
    /// <param name="imgName">Image Name</param>
    /// <param name="srcPath">Path of source file</param>
    /// <param name="destPath">Path where u want to save the optimized file</param>
    /// <param name="widthLimit">Target width limit</param>
    /// <param name="imageProportion">Either to maintain proportion of Width and height</param>
    public void ImageOptimizer(string imgName, string srcPath, string destPath, float widthLimit, bool imageProportion)
    {
        try
        {
            string src = HttpContext.Current.Server.MapPath(srcPath + imgName);
            FileStream fs = new FileStream(src, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs, true, false);

            float srcWidth = image.Width;
            float srcHeight = image.Height;
            image.Dispose();
            fs.Close();

            float percentWidth = 0;
            float percentHeight = 0;
            float thumbWidth = widthLimit;
            float thumbHeight;

            if (imageProportion == true)
            {
                if (srcWidth >= srcHeight)
                {
                    thumbHeight = 0;
                }
                else
                {
                    thumbWidth = 0;
                    thumbHeight = widthLimit;
                    goto heightProcess;
                }
            }


            if (srcWidth > widthLimit)
            {
                //float tvar1 = (100 * widthLimit) / srcWidth;
                //percentWidth = Convert.ToInt32( Math.Round(tvar1));
                ////percentWidth = Convert.ToInt32( Math.Round(percentWidth));
                //thumbWidth = (srcWidth * percentWidth) / 100;

                //New
                percentWidth = (100 * widthLimit) / srcWidth;
                thumbWidth = (srcWidth * percentWidth) / 100;



                //float tvar2 = (thumbWidth * srcHeight) / srcWidth;
                //thumbHeight = Convert.ToInt32(Math.Round(tvar2));
                thumbHeight = (thumbWidth * srcHeight) / srcWidth;

                //thumbprocess
                ThumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            else
            {

                thumbWidth = srcWidth;
                thumbHeight = srcHeight;
                //thumbprocess
                ThumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            return;



        heightProcess:
            if (srcHeight > widthLimit)
            {
                //float tvar3 = (100 * widthLimit) / srcHeight;
                //percentHeight = Convert.ToInt32( Math.Round( tvar3 ));
                percentHeight = (100 * widthLimit) / srcHeight;

                thumbHeight = (srcHeight * percentHeight) / 100;

                //float tvar4 = (thumbHeight * srcWidth) / srcHeight;
                //thumbWidth = Convert.ToInt32( Math.Round(tvar4) );

                thumbWidth = (thumbHeight * srcWidth) / srcHeight;

                //thumbnailprocessor
                ThumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            else
            {
                thumbWidth = srcWidth;
                thumbHeight = srcHeight;

                //thumbnailprocessor
                ThumbnailProcessor(imgName, srcPath, destPath, Convert.ToInt32(thumbWidth), Convert.ToInt32(thumbHeight));
            }
            return;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ThumbnailProcessor(string imgName, string testPath, string deployImgPath, int thumbWidth, int thumbHeight)
    {
        try
        {
            //string sImageName = imgName;

            // ORIGINAL WIDTH AND HEIGHT.
            //Bitmap bitmap = new Bitmap(Server.MapPath("~/" + Path.GetFileName(hpf.FileName)));
            Bitmap bitmap = new Bitmap(HttpContext.Current.Server.MapPath(testPath + imgName));
            string extn = Path.GetExtension(testPath + imgName);

            int iwidth = thumbWidth;
            int iheight = thumbHeight;

            bitmap.Dispose();

            // CREATE AN IMAGE OBJECT USING ORIGINAL WIDTH AND HEIGHT.
            // ALSO DEFINE A PIXEL FORMAT (FOR RICH RGB COLOR).

            System.Drawing.Image objOptImage = new System.Drawing.Bitmap(iwidth, iheight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            // GET THE ORIGINAL IMAGE.
            using (System.Drawing.Image objImg = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(testPath + imgName)))
            {

                // RE-DRAW THE IMAGE USING THE NEWLY OBTAINED PIXEL FORMAT.
                using (System.Drawing.Graphics oGraphic = System.Drawing.Graphics.FromImage(objOptImage))
                {
                    var _1 = oGraphic;
                    System.Drawing.Rectangle oRectangle = new System.Drawing.Rectangle(0, 0, iwidth, iheight);

                    _1.DrawImage(objImg, oRectangle);
                }

                // SAVE THE OPTIMIZED IMAGE.
                switch (extn.ToLower())
                {
                    case ".jpg":

                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".jpeg":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".png":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".gif":
                        objOptImage.Save(HttpContext.Current.Server.MapPath(deployImgPath + imgName), System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                objImg.Dispose();

            }

            objOptImage.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Crops the image & maintains the center
    /// </summary>
    /// <param name="imageName">Name of Image</param>
    /// <param name="srcPath">Source path of target image</param>
    /// <param name="destPath">Path where you want to save the cropeed image</param>
    /// <param name="targetW">Target width</param>
    /// <param name="targetH">Target height</param>
    public void CenterCropImage(string imageName, string srcPath, string destPath, int targetW, int targetH)
    {
        try
        {
            string src = HttpContext.Current.Server.MapPath(srcPath + imageName);
            string dest = HttpContext.Current.Server.MapPath(destPath + imageName);

            FileStream fsCrop = new FileStream(src, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(fsCrop, true, false);

            int targetX = (imgPhoto.Width - targetW) / 2;
            int targetY = (imgPhoto.Height - targetH) / 2;

            System.Drawing.Bitmap bmPhoto = new Bitmap(targetW, targetH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(72, 72);

            System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);

            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

            grPhoto.Clear(System.Drawing.Color.FromArgb(255, 255, 255, 255));
            grPhoto.DrawImage(imgPhoto, new System.Drawing.Rectangle(0, 0, targetW, targetH), targetX, targetY, targetW, targetH, System.Drawing.GraphicsUnit.Pixel);

            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt64(100));

            imgPhoto.Dispose();
            grPhoto.Dispose();
            grPhoto = null;
            bmPhoto.Save(dest);
            bmPhoto.Dispose();
            bmPhoto = null;

            fsCrop.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string EncryptData(string originalStr)
    {
        try
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[originalStr.Length];
            encode = Encoding.UTF8.GetBytes(originalStr);
            strmsg = Convert.ToBase64String(encode);
            strmsg = strmsg.Replace("=", "");
            return strmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Send SMS
    /// </summary>
    /// <param name="msgData">SMS Data</param>
    /// <param name="recNumber">Receipant Number</param>
    //public void SendSMS(string msgData, string recNumber)
    //{
    //    try
    //    {
    //        WebClient wbClient = new WebClient();
    //        string baseUrl = "http://sms1.macdysaa.com/api/sendhttp.php?authkey=8639AnVOncJZJuq559d0690&mobiles=" + recNumber + "&message=" + msgData + "&sender=INTSYS&route=4";
    //        Stream dStream = wbClient.OpenRead(baseUrl);
    //        StreamReader strReader = new StreamReader(dStream);
    //        string s = strReader.ReadToEnd();

    //        dStream.Close();
    //        strReader.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    /// <summary>
    /// Sends an Email
    /// </summary>
    /// <param name="fromEmail">Sender Email Id</param>
    /// <param name="toEmail">Receipant Email Id</param>
    /// <param name="msgData">Message Details</param>
    /// <param name="mailSubject">Subject Line</param>
    /// <param name="bccEmail">BCC Email Id</param>
    /// <param name="isHtmlEmail">True/False</param>
    /// <param name="attachStr">path of attachment file</param>
    /// <param name="documentName">Name of document</param>
    public void SendMail(string fromEmail, string MailerName, string toEmail, string msgData, string mailSubject, string bccEmail, bool isHtmlEmail, string attachStr, string documentName)
    {
        try
        {
            MailMessage msg = new MailMessage();
            string totalMessage;
            msg.From = new MailAddress(fromEmail, MailerName);
            msg.To.Add(toEmail);
            msg.Subject = mailSubject;

            totalMessage = msgData + Environment.NewLine + Environment.NewLine;

            if (bccEmail != "")
            {
                msg.Bcc.Add(bccEmail);
            }

            msg.Body = (totalMessage.ToString()).Trim();
            msg.IsBodyHtml = isHtmlEmail;

            if (attachStr != "")
            {
                FileStream fs = new FileStream(attachStr, FileMode.Open, FileAccess.Read);
                Attachment file = new Attachment(fs, documentName);
                msg.Attachments.Add(file);
            }
           // SmtpClient smtp = new SmtpClient("mail.intellect-systems.com", 25);
            SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587);
            smtp.Credentials = new NetworkCredential("info@intellect-systems.com", "iTrans@2017");

            smtp.EnableSsl = true;
            smtp.Send(msg);
            msg = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Creates Email Markup //here used for JobNiti.com
    /// </summary>
    /// <param name="fromEmail">Sender Email Id</param>
    /// <param name="toEmail">Receipant Email Id</param>
    /// <param name="subjectLine">Subject Line</param>
    /// <param name="subjectBrief">Short Details</param>
    /// <param name="msgData">Detail Message</param>
    /// <param name="bccEMail">BCC Email Id</param>
    public void EmailHttpMarkup(string fromEmail, string mailerName, string toEmail, string subjectLine, string subjectBrief, string msgData, string bccEMail, string attchStr, string docName)
    {
        try
        {
            StringBuilder strMail = new StringBuilder();

            strMail.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            strMail.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");

            //Head tag starts
            strMail.Append("<head>");
            strMail.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            strMail.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>");
            strMail.Append("</head>");
            //Head tag Ends

            //Body tag starts
            strMail.Append("<body style=\"margin:0;padding:0;\">");

            //Main table wrapper starts
            strMail.Append("<table style=\"background-color:#f4f4f4 \" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            strMail.Append("<tr>");
            strMail.Append("<td style=\"padding:10px 0 30px 0px\">");

            //Container Table wrapper starts
            strMail.Append("<table border=\"0\" width=\"600\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"border-collapse:collapse\">");

            //Header starts
            strMail.Append("<tr>");
            strMail.Append("<td style=\"background:#579936;padding:20px 0px 20px 20px;\">");

            strMail.Append("<table style=\"width:100%\">");
            strMail.Append("<tr>");
            strMail.Append("<td align=\"left\" style=\"width:50%\">");
            strMail.Append("<img src=\"http://www.intellect-systems.com/images/intellect-logo-white.png\" alt=\"Intellect Systems\" width=\"150\" style=\"display:block;\" />");
            strMail.Append("</td>");
            strMail.Append("<td align=\"right\" style=\"width:50%;\">");

            strMail.Append("<a href=\"https://www.facebook.com/insyslabs\" style=\"margin-right:10px;\" ><img src=\"http://www.intellect-systems.comn/images/icons/fb_mail.png\" title=\"Intellect Systems on Facebook\" /></a>");

            strMail.Append("</td>");
            strMail.Append("</tr>");
            strMail.Append("</table>");

            strMail.Append("</td>");
            strMail.Append("</tr>");
            //Header ends

            //Email message data starts
            strMail.Append("<tr>");
            strMail.Append("<td bgcolor=\"#ffffff\" style=\"padding:40px 30px 40px 30px; background-color:#ffffff\">");

            //4 rows table starts
            strMail.Append("<table border=\"0\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");

            //Subject Title starts 
            strMail.Append("<tr>");
            strMail.Append("<td style=\"color:#222;font-family:Arial,Sans-Serif;font-size:20px;padding-bottom:5px\">");

            strMail.Append(subjectLine);

            strMail.Append("</td>");
            strMail.Append("</tr>");
            //Subject Title ends

            //Subject subtitle starts
            strMail.Append("<tr>");
            strMail.Append("<td style=\"color:#555;font-size:14px;font-family:Arial,Sans-Serif;\">");

            strMail.Append(subjectBrief);

            strMail.Append("</td>");
            strMail.Append("</tr>");
            //Subject subtitle ends

            //Separator line
            strMail.Append("<tr><td style=\"height:15px\"></td></tr>");
            strMail.Append("<tr><td style=\"background-color:#ececec;height:1px\"></td></tr>");
            strMail.Append("<tr><td style=\"height:15px\"></td></tr>");

            //Actual Template Message from Database

            strMail.Append("<tr>");
            strMail.Append("<td style=\"color:#555;font-size:14px; line-height:1.5; font-family:Arial,Sans-Serif;\">");

            strMail.Append(msgData);

            strMail.Append("</td>");
            strMail.Append("</tr>");
            strMail.Append("</table>");
            //4 rows table ends

            strMail.Append("</td>");
            strMail.Append("</tr>");
            //Email Message data ends

            //Footer starts
            strMail.Append("<tr>");
            strMail.Append("<td bgcolor=\"#eeeeee\" style=\"text-align:center;padding:20px 20px 20px 20px\">");
            strMail.Append("<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");

            strMail.Append("<tr>");
            strMail.Append("<td style=\"padding:0px 0px 10px 0px;font-family:Arial,Sans-Serif;font-size:13px;color:#525252\">For any queries, complains or suggestions, please feel free to contact us at <a href=\"mailto:info@intellect-systems.com\" style=\"font-family:Arial,Sans-Serif;font-size:13px;\">info@intellect-systems.com</a></td>");
            strMail.Append("</tr>");
            strMail.Append("<tr>");
            strMail.Append("<td style=\"font-family:Arial,Sans-Serif;font-size:14px;color:#579936;padding-bottom:10px\">Intellect Systems (Sangli-MH)</td>");
            strMail.Append("</tr>");
            strMail.Append("</table>");
            strMail.Append("</td>");
            strMail.Append("</tr>");
            //Footer ends

            strMail.Append("</table>");
            //Container Table wrapper ends

            strMail.Append("</td>");
            strMail.Append("</tr>");
            strMail.Append("</table>");
            //Main Table wrapper ends

            strMail.Append("</body>");
            //Body tag ends

            strMail.Append("</html>");


            string msgData1 = strMail.ToString();

            SendMail(fromEmail, mailerName, toEmail, msgData1, subjectLine, bccEMail, true, attchStr, docName);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Timespan between specific date and current date
    /// </summary>
    /// <param name="startDate">Start Date</param>
    /// <returns>Timespan (String)</returns>
    public string GetTimeSpan(DateTime startDate)
    {
        try
        {

            startDate = Convert.ToDateTime(startDate);

            DateTime curDate = Convert.ToDateTime(DateTime.Now);

            //TimeSpan timeSince = new TimeSpan();
            TimeSpan timeSince = curDate.Subtract(startDate);

            if (timeSince.TotalMinutes < 1)
            {
                return "Just now";
            }

            if (timeSince.TotalMinutes < 2)
            {
                return "1 minute ago";
            }
            if (timeSince.TotalMinutes < 60)
            {
                return string.Format("{0} minutes ago", timeSince.Minutes);
            }
            if (timeSince.TotalMinutes < 120)
            {
                return "1 hour ago";
            }
            if (timeSince.TotalHours < 24)
            {
                return string.Format("{0} hours ago", timeSince.Hours);
            }
            //if (timeSince.TotalDays == 1)
            //{
            //    return "Yesterday";
            //}
            if (timeSince.TotalDays < 7)
            {
                return string.Format("{0} days ago", timeSince.Days);
            }
            if (timeSince.TotalDays < 14)
            {
                return "1 week ago";
            }
            if (timeSince.TotalDays < 21)
            {
                return "2 weeks ago";
            }
            if (timeSince.TotalDays < 28)
            {
                return "3 weeks ago";
            }
            if (timeSince.TotalDays < 60)
            {
                return "1 month ago";
            }
            if (timeSince.TotalDays < 365)
            {
                return String.Format("{0} months ago", Math.Round(timeSince.TotalDays / 30));
            }
            if (timeSince.TotalDays < 730)
            {
                return "1 year ago";
            }
            return string.Format("{0} years ago", Math.Round(timeSince.TotalDays / 365));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //private void IsNumeric(
    //public static bool IsNumeric(this string s)
    //{
    //    float output;
    //    return float.TryParse(s, out output);
    //}

    public bool IsNumeric(String num)
    {
        try
        {

            bool rValue;
            double result;
            bool isNum = double.TryParse(num, out result);
            if (isNum)
            {
                rValue = true;
            }
            else
            {
                rValue = false;
            }
            return rValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}