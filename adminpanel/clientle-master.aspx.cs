using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminpanel_testimonials_master : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
      

        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Testimonials" : "Edit Testimonials";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
          
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                FillGrid();
                GetData(Convert.ToInt32(Request.QueryString["id"]));

                if (lblId.Text == "[New]")
                {
                    btnSave.Text = "Add";
                }
                else
                {
                    btnSave.Text = "Update";

                }

            }
            pgTitle = lblId.Text == "[New]" ? "Add Clients " : "Edit Clients";
            lblId.Visible = false;
            lblId.Visible = false;
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }

        //txtTesDesc.Attributes.Add("maxlength", "300");
    }

    private void FillGrid()
    {
        try
        {
            using (DataTable dtNws = c.GetDataTable("Select clId, clName, clCity From Clients Order By clId"))
            {
                gvClients.DataSource = dtNws;
                gvClients.DataBind();

                if (dtNws.Rows.Count > 0)
                {
                    gvClients.UseAccessibleHeader = true;
                    gvClients.HeaderRow.TableSection = TableRowSection.TableHeader;
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


    protected void gvClients_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"clientle-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";


            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvClients_RowDataBound", ex.Message.ToString());
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


    public void GetData(int TestiIdx)
    {
        try
        {
            using (DataTable dttesti = c.GetDataTable("select * from Clients where clId=" + TestiIdx))
            {
                if (dttesti.Rows.Count > 0)
                {
                    DataRow row = dttesti.Rows[0];
                    lblId.Text = TestiIdx.ToString();

                    txtPerNm.Text = row["clName"].ToString();
                    txtPlce.Text = row["clCity"].ToString();
                   
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
            //Empty Validations
            if (txtPerNm.Text == "" || txtPlce.Text == "" )
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * marked fields are mandatory');", true);
                return;
            }

            int maxId = lblId.Text == "[New]" ? c.NextId("Clients", "clId") : Convert.ToInt32(lblId.Text);

            //Insert Update data
            if (lblId.Text == "[New]")
            {
                c.ExecuteQuery("Insert into Clients(clId, clName, clCity)Values(" + maxId + ", '" + txtPerNm.Text + "',  '" + txtPlce.Text + "')");

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Client  Added');", true);
            }
            else
            {
                c.ExecuteQuery("Update Clients set clName='" + txtPerNm.Text + "', clCity='" + txtPlce.Text + "' where clId=" + maxId);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Client  Updated');", true);
            }

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('clientle-master.aspx', 2000);", true);

            txtPerNm.Text = txtPlce.Text = "";

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("clientle-master.aspx");
    }

    protected void gvClients_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            if (e.CommandName == "Update")
            {


                c.ExecuteQuery("Delete From Clients where clId=" + gRow.Cells[0].Text);
                //c.ExecuteQuery("Update ContactNumbers set contNumber='8888888888' where contId=" + gRow.Cells[0].Text);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Client  Updated');", true);

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Record Deleted');", true);
                Response.Redirect("clientle-master.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvClients_RowCommand", ex.Message.ToString());
            return;
        }
    }
}