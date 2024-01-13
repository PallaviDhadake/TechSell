using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterParent : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string rootPath, Currentyear;
    protected void Page_Load(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        Currentyear = DateTime.Now.Year.ToString();
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //currentYear = DateTime.Now.Year.ToString();
        rootPath = c.ReturnHttp();
    }
}
