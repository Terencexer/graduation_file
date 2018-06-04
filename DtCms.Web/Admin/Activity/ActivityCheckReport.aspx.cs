using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Data.OleDb;
using DtCms.BLL;
using DtCms.Model;
using System.Web.UI.DataVisualization.Charting;

namespace DtCms.Web.Admin.Activity
{
    public partial class ActivityCheckReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.BackColor = Color.Moccasin;
            Chart1.BackGradientStyle = GradientStyle.DiagonalRight;
          Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
           Chart1.BorderlineColor = Color.Gray;
           Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
           DateTime dt = Convert.ToDateTime(DropDownList1.SelectedValue);
            // forma the chart area
           Chart1.ChartAreas[0].BackColor = Color.Wheat;
            // add and format the title
            Chart1.Titles.Add("年度审核情况表");
           // Chart1.Titles[0].Font = new Font("Utopia", 14, FontStyle.Bold);

            Chart1.Series.Add(new Series("Pie")
            {
                ChartType = SeriesChartType.Pie,
                ShadowOffset = 2
            });
            DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
            
            Chart1.Series[0].Label = "#VALX \n\n #PERCENT{P}";//显示百分比和说明
            Chart1.Series[0].LegendText = "#VALX";
            int a = activity.GetCountMode("审核通过",dt);
            int b = activity.GetCountMode("不批准", dt);
            int c = activity.GetCountMode("退回修改", dt);
            int d = activity.GetCountMode("未审核", dt);
            int f = activity.GetCountMode("再次提交", dt);
            double[] yValues = { a, b, c, d, f };
            string[] xValues = { "审核通过", "不批准", "退回修改", "未审核","再次提交" };
            //饼状图的标签方位
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Series[0]["PieLineColor"] = "Black";
            Chart1.Series[0].Points.DataBindXY(xValues, yValues);

            //每个部分开花
            foreach (DataPoint point in Chart1.Series[0].Points)
            {
                point["Exploded"] = "true";
            }
        }
    }
}