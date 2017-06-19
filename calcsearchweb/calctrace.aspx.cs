using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace calcsearchweb
{
    public partial class calctrace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl para = new HtmlGenericControl("p");
            jsonViewer jv = new jsonViewer();
            para.InnerHtml = jv.calcres;
            calcres.Controls.Add(para);
        }

        public void disp(string json)
        {
            /*HtmlGenericControl para = new HtmlGenericControl("p");
            para.InnerText = "ttt";
            calcres.Controls.Add(para);*/
        }
    }
}