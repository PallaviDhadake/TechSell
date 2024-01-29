using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class adminpanel_products_data : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, prodPhoto, videoPreview, brochure;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Products" : "Edit Products";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    editinfo.Visible = true;
                    viewinfo.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        GetData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
                else
                {
                    editinfo.Visible = false;
                    viewinfo.Visible = true;
                    FillGrid();
                }

                c.FillComboBox("catName", "catId", "ProCategory", "delMark=0", "catName", 0, ddrProdCat);
                c.FillComboBox("brandName", "brandId", "Brands", "delMark=0", "brandName", 0, ddrbrand);
            }
            lblId.Visible = false;

          
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }


    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select a.proId, a.proName, b.catName, c.brandName From Products a Inner Join ProCategory b on a.catId=b.catId Inner Join Brands c on a.brandId=c.brandId"))
            {
                gvProducts.DataSource = dtNws;
                gvProducts.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvProducts.UseAccessibleHeader = true;
                    gvProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }


    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"products-data.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";


                //Literal litAnchphto = new Literal();
                //litAnchphto = (Literal)e.Row.FindControl("litAnchphto");
                //litAnchphto.Text = "<a href=\"add-product-photos.aspx?albumId=" + e.Row.Cells[0].Text + "\" class=\"addPhoto\" title=\"Add Photos \"></a>";

                object Vidioflag = c.GetReqData("Products", "proVideo", "proId=" + e.Row.Cells[0].Text) ?? "";

                Literal litVideoLink = (Literal)e.Row.FindControl("litVideoLink");

                if (Vidioflag != DBNull.Value && Vidioflag != null && Vidioflag.ToString() != "")
                {


                    if (Vidioflag.ToString() == "")
                    {

                        litVideoLink.Text = "";
                    }
                    else
                    {
                        litVideoLink.Text = "<img src=\"images/icons/mark.gif\">";
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvProducts_RowDataBound", ex.Message.ToString());
            return;
        }
    }

    public void GetAllControls(ControlCollection ctrs)
    {
        foreach (Control c in ctrs)
        {
            if (c is System.Web.UI.WebControls.TextBox)
            {
                TextBox tt = c as TextBox;
                tt.Text = tt.Text.Trim().Replace("'", "");
            }
            if (c.HasControls())
            {
                GetAllControls(c.Controls);
            }
        }
    }

    public void GetData(int ProductIdx)
    {
        try
        {
            using (DataTable dtprod = c.GetDataTable("select * from Products where proId=" + ProductIdx))
            {
                if (dtprod.Rows.Count > 0)
                {
                    DataRow row = dtprod.Rows[0];
                    lblId.Text = ProductIdx.ToString();

                    ddrProdCat.SelectedValue = row["catId"].ToString();
                    ddrbrand.SelectedValue = row["brandId"].ToString();
                    txtProdName.Text = row["proName"].ToString();
                    txtProdDesc.Text = row["proDesc"].ToString();
                    txtProdSpec.Text = row["proSpecs"].ToString();
                    txtProdFeature.Text = row["proFeatures"].ToString();
                    //txtVidLink.Text = row["proVideo"].ToString();
                    //txtDate.Text = Convert.ToDateTime(row["projDate"]).ToString("dd/MM/yyyy");

                    if (row["proImage"] != DBNull.Value && row["proImage"] != null && row["proImage"].ToString() != "" && row["proImage"].ToString() != "no-photo.png")
                    {
                        prodPhoto = "<img src=\"" + Master.rootPath + "upload/product/gallery/thumb/" + row["proImage"].ToString() + "\" width=\"200\" />";
                        
                    }
                    

                    if (row["proBrochure"] != DBNull.Value && row["proBrochure"] != null && row["proBrochure"].ToString() != "" && row["proBrochure"].ToString() != "no-photo.png")
                    {
                        prodPhoto = "<img src=\"" + Master.rootPath + "upload/product/brochure/" + row["proBrochure"].ToString() + "\" width=\"200\" />";
                     
                    }
                    
                    //if (row["proVideo"] != DBNull.Value && row["proVideo"] != null && row["proVideo"].ToString() != "")
                    //{
                    //    txtVidLink.Text = "www.youtube.com/watch?v=" + row["proVideo"].ToString();

                    //    videoPreview = "<iframe width=\"400\" height=\"220\" src=\"https://www.youtube.com/embed/" + row["proVideo"].ToString() + "\"frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\"allowfullscreen></iframe>";

                    //}

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetData", ex.Message.ToString());
            return;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllControls(this.Controls);
            if (txtProdName.Text == "" || ddrProdCat.SelectedIndex == 0 || ddrbrand.SelectedIndex == 0  || txtProdDesc.Text == "" || txtProdFeature.Text=="" || txtProdSpec.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * marked fields are mandatory');", true);
                return;
            }

            string videoLink = "";
            if (txtVidLink.Text != "")
            {
                if (txtVidLink.Text.Contains("www.youtube.com") == true)
                {
                    string[] arrLink = txtVidLink.Text.Split('/');
                    string[] arrKey = arrLink[arrLink.Length - 1].Split('=');
                    videoLink = arrKey[arrKey.Length - 1];
                }
                else if (txtVidLink.Text.Contains("youtu.be"))
                {
                    string[] arrVidLink = txtVidLink.Text.Split('/');
                    string tempvidLink = arrVidLink[arrVidLink.Length - 1];

                    if (tempvidLink.ToString().Contains("?"))
                    {
                        string[] arrFinalLink = tempvidLink.ToString().Split('?');
                        videoLink = arrFinalLink[0];

                    }
                    else
                    {
                        videoLink = tempvidLink.ToString();
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid video link entered');", true);
                    return;
                }
            }
            

                int maxId = lblId.Text == "[New]" ? c.NextId("Products", "proId") : Convert.ToInt32(lblId.Text);
                string productImage = "";
                if (fuImage.HasFile)
                {
                    string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();

                    if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                    {
                        productImage = "pro-photo-" + maxId + fExt;
                        ImageUploadProcess(productImage);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                        return;

                    }
                }
                else if (fuImage.HasFile == false && lblId.Text == "[New]")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select project image ');", true);
                    return;
                }

            string DocBrochure = "";

            if (fuBrocure.HasFile)
            {
                string fExt = Path.GetExtension(fuBrocure.FileName).ToString().ToLower();

                if (fExt == ".pdf")
                {
                    DocBrochure = "pro-brochure-" + maxId + fExt;
                   // ImageUploadProcess(brochure);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .pdf files are allowed');", true);
                    return;

                }
            }
            else if (fuBrocure.HasFile == false && lblId.Text == "[New]")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select Brocure to upload ');", true);
                return;
            }


            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert Into Products (proId, brandId, catId, proName, proDesc, proFeatures, proSpecs, proVideo, delMark) Values ( " + maxId + ", " + Convert.ToInt32(ddrbrand.SelectedValue) + ", " + Convert.ToInt32(ddrProdCat.SelectedValue) + ", '" + txtProdName.Text + "', '" + txtProdDesc.Text + "', '" + txtProdFeature.Text + "', '" + txtProdSpec.Text + "', '" + txtVidLink.Text + "', 0)");

                if (fuBrocure.HasFile)
                {
                    c.ExecuteQuery("Update Products Set proBrochure='" + DocBrochure + "' Where proId=" + maxId);
                    fuImage.SaveAs(Server.MapPath("~/upload/product/brochure/") + DocBrochure);
                }
                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update Products Set proImage='" + productImage + "' Where proId=" + maxId);
                    //ImageUploadProcess(prodPhoto);
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product  Added');", true);

            }
            else
            {

                c.ExecuteQuery("Update Products Set brandId=" + Convert.ToInt32(ddrbrand.SelectedValue) + ", catId=" + Convert.ToInt32(ddrProdCat.SelectedValue) + ", proName='" + txtProdName.Text + "', proDesc='" + txtProdDesc.Text + "', proFeatures='" + txtProdFeature.Text + "', proSpecs='" + txtProdSpec.Text + "', proVideo='" + txtVidLink.Text + "' Where proId=" + maxId);


                if (fuBrocure.HasFile)
                {
                    c.ExecuteQuery("Update Products Set proBrochure='" + DocBrochure + "' Where proId=" + maxId);
                    fuImage.SaveAs(Server.MapPath("~/upload/product/brochure/") + DocBrochure);
                }
                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update Products Set proImage='" + productImage + "' Where proId=" + maxId);
                    //ImageUploadProcess(prodPhoto);
                }

            }
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product  Updated');", true);
                

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);

                txtProdName.Text = "";
                ddrProdCat.SelectedIndex = 0;

          //  }
        
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }


    private void ImageUploadProcess(string imgName)
    {
        try
        {
            string origImgPath = "~/upload/product/gallery/original/";
            string thumbImgPath = "~/upload/product/gallery/thumb/";
            string normalImgPath = "~/upload/product/gallery/";

            fuImage.SaveAs(Server.MapPath(origImgPath) + imgName);
            c.ImageOptimizer(imgName, origImgPath, normalImgPath, 420, false);
            c.CenterCropImage(imgName, normalImgPath, thumbImgPath, 120, 120);

            File.Delete(Server.MapPath(origImgPath) + imgName);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Delete From Products Where proId=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Product Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("products-data.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update ProductsData set ProductPhoto='no-photo.png' where ProductId=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Photo Removed');", true);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('products-data.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;

        }
    }
}