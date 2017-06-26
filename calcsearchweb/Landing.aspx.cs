using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace calcsearchweb
{
    public partial class Landing : System.Web.UI.Page
    {
        int clickdone = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            int count = 0;
            string val="";
            foreach (var key in System.Configuration.ConfigurationManager.AppSettings)
            {
                if (!(key.ToString().Equals("results")))
                {
                    TableRow row = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Text = key.ToString();
                    row.Cells.Add(cell1);

                    TableCell cell2 = new TableCell();
                    TextBox t = new TextBox();
                    val = count.ToString();
                    t.ID = val;  
                    cell2.Controls.Add(t);
                    row.Cells.Add(cell2);

                    t01.Rows.Add(row);
                    count++;
                }
            }
                       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            clickdone = 1;
            int count = 0;
            querybuilder qb = new querybuilder();
            
            for (int i = 1; i < t01.Rows.Count; i++)
            {
                TableRow dr = t01.Rows[i];
                TableCell tc = dr.Cells[1];
                String textCell = ((TextBox)tc.FindControl((i-1).ToString())).Text;

                if (String.IsNullOrEmpty(textCell))
                {
                    continue;
                }
                else
                {
                    qb.read_query(dr.Cells[0].Text, textCell, count);
                    count++;
                }
            }

            string resp = qb.exec_query();
            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            webConfigApp.AppSettings.Settings["results"].Value = resp;
            webConfigApp.Save();
            ClientScript.RegisterStartupScript(GetType(), "SomeNameForThisScript","window.open('result.aspx');", true);
            /*jsonViewer jV = new jsonViewer();
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
            int count1 = 0;
            temp = temp.Replace("\r\n", "<br />");

            if (table != null)
            {
                tablenew.ID = "t03";
                cell.Text = "CalcTrace";
                row.Controls.Add(cell);
                tablenew.Controls.Add(row);

                foreach (var item in calctrace.Zip(eligtrace, Tuple.Create))
                {
                    row = new TableRow();
                    cell = new TableCell();
                    Button b = new Button();
                    b.Text = "View trace";
                    b.CommandArgument = count.ToString();
                    b.CommandName = item.Item1 + item.Item2;
                    b.Click += new EventHandler(this.clicked);
                    cell.Controls.Add(b);
                    row.Controls.Add(cell);
                    tablenew.Controls.Add(row);
                    count1++;
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
            }*/
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
