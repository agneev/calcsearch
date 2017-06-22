using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Providers.Entities;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;

namespace calcsearchweb {
    public class Value
    {
        public double searchscore { get; set; }
        public string CalcRunId { get; set; }
        public string TraceId { get; set; }
        public string ProgramCode { get; set; }
        public string TransactionId { get; set; }
        public string LeverCode { get; set; }
        public string ParticipantId { get; set; }
        public string Date { get; set; }
        public string TransactionVersionNumber { get; set; }
        public object CalcTrace { get; set; }
        public object EligTrace { get; set; }
    }

    public class RootObject
    {
        public string odatacontext { get; set; }
        public List<Value> value { get; set; }
    }

    public class jsonViewer
    {
        public string calcres = "";
        public string []ctraces;
        public string []etraces;
        public Table deserialize(string json)
        {
            Table table = new Table();
            table.ID = "t02";
            TableRow row;
            TableCell cell;
            List<Value> val;
            int count = 0,ecount=0;
            
            
            calctrace calc = new calctrace();
            RootObject rootobject = JsonConvert.DeserializeObject<RootObject>(json);
            result trace = new result();
            
            val = rootobject.value;
            ctraces = new string[val.Count];
            etraces = new string[val.Count];
            table.BorderWidth = 1;
            row = new TableRow();

            if (val.Count > 0)
            {
               

                PropertyInfo[] proper = val[0].GetType().GetProperties();
                foreach (PropertyInfo property in proper)
                {
                    if (!(property.Name.Equals("CalcTrace")) && !(property.Name.Equals("EligTrace")))
                    {
                        cell = new TableCell();
                        cell.Text = property.Name;
                        row.Cells.Add(cell);

                    }
                }
                table.Rows.Add(row);

                foreach (var item in val)
                {

                    row = new TableRow();
                    PropertyInfo[] prop = item.GetType().GetProperties();

                    foreach (PropertyInfo property in prop)
                    {

                        if (property.Name.Equals("CalcTrace"))
                        {
                            string ress = property.GetValue(item).ToString();
                            ctraces[count] = ress;
                            count++;
                        }
                        else if (property.Name.Equals("EligTrace"))
                        {
                            string ress = property.GetValue(item).ToString();
                            etraces[ecount] = ress;
                            ecount++;
                        }

                        else
                        {
                            cell = new TableCell();
                            if (property.GetValue(item) == null)
                                cell.Text = "null";
                            else
                                cell.Text = (property.GetValue(item)).ToString();

                            row.Cells.Add(cell);
                        }
                    }

                    table.Rows.Add(row);
                }
            }
            else
            {
                return null;
            }

            return table;
        }
        /*public string calctraces(Value item)
        {
            PropertyInfo[] calcprop = item.calctrace.GetType().GetProperties();
            calcres = "";
            calcres += "<b>" + "calres :" + "</b>" + "<br />";
            foreach (PropertyInfo inner in calcprop)
            {

                if (inner.Name.Equals("CalculationTrace"))
                {
                    if (inner.GetValue(item.calctrace) == null)
                        calcres += "<b>"+inner.Name + "</b>"+" : " + "null" + "<br />";
                    else
                    {
                        calcres+="<b>" + "CalculationTrace :" + "</b>" + "<br />";
                        PropertyInfo[] innertrace = item.calctrace.CalculationTrace.GetType().GetProperties();

                        foreach (PropertyInfo fininner in innertrace)
                        {
                            if (fininner.GetValue(item.calctrace.CalculationTrace) == null)
                                calcres += fininner.Name + " : " + "null" + "<br />";
                            else
                                calcres += fininner.Name + " : " + fininner.GetValue(item.calctrace.CalculationTrace) + "<br />";
                        }
                    }
                }
                else if (inner.Name.Equals("EligibilityTrace"))
                {
                    calcres += "<b>" + "EligibilityTrace :" + "</b>" + "<br />";
                    PropertyInfo[] innertrace = item.calctrace.EligibilityTrace.GetType().GetProperties();
                    foreach (PropertyInfo fininner in innertrace)
                    {
                        if (fininner.GetValue(item.calctrace.EligibilityTrace) == null)
                            calcres += fininner.Name + " : " + "null" + "<br />";
                        else
                            calcres += fininner.Name + " : " + fininner.GetValue(item.calctrace.EligibilityTrace) + "<br />";
                    }
                }
                else
                {
                    if (inner.GetValue(item.calctrace) == null)
                        calcres += inner.Name + " : " + "null" + "<br />";
                    else
                        calcres += inner.Name + " : " + inner.GetValue(item.calctrace) + "<br />";
                }
            }
            return calcres;
        }*/
    }
}