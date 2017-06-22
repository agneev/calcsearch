using calcsearchweb.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace calcsearchweb
{
    public partial class result : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {
            jsonViewer jV = new jsonViewer();
            string[] calctrace;
            string[] eligtrace;
            string temp = (System.Configuration.ConfigurationManager.AppSettings["results"]).ToString();
            
            temp = temp.Replace("@", "");
            temp = temp.Replace("a.c", "ac");
            temp = temp.Replace("h.s", "hs");
            temp = temp.Replace("\"{", "{");
            temp = temp.Replace(" \"", "\"");
            temp = temp.Replace("}\"", "}");
            Table table = jV.deserialize(temp);
            calctrace = jV.ctraces;
            eligtrace = jV.etraces;
            Table tablenew = new Table();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            int count=0;
            temp = temp.Replace("\r\n", "<br />");

            if (table != null)
            {
                tablenew.ID = "t03";
                cell.Text = "CalcTrace";
                row.Controls.Add(cell);
                tablenew.Controls.Add(row);

                foreach (var item in calctrace.Zip(eligtrace,Tuple.Create))
                {
                    row = new TableRow();
                    cell = new TableCell();
                    Button b = new Button();
                    b.Text = "View trace";
                    b.CommandArgument = count.ToString();
                    b.CommandName = item.Item1+item.Item2;
                    b.Click += new EventHandler(this.clicked);
                    cell.Controls.Add(b);
                    row.Controls.Add(cell);
                    tablenew.Controls.Add(row);
                    count++;
                }
                res.Controls.Add(table);
                res.Controls.Add(tablenew);
            }
            else
            {
                HtmlGenericControl para = new HtmlGenericControl("p");
                para.InnerText = "Search Query did not match any records!";
                res.Controls.Add(para);
                Panel1.Visible = false;
            }
        }

        protected void clicked(object sender, EventArgs e)
        {
            calctracefinal.Controls.Clear();
            Panel1.Visible = true;
            Button button = (Button)sender;
            string id = button.CommandArgument;
            int pos = Convert.ToInt32(id);
            HtmlGenericControl para = new HtmlGenericControl("p");
            para.InnerHtml = button.CommandName;
            calctracefinal.Controls.Add(para);
        }
    }
}