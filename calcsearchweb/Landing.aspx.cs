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

namespace calcsearchweb
{
    public partial class Landing : System.Web.UI.Page
    {
        
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
            
        }
    }
}