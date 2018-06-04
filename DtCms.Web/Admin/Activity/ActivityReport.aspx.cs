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

namespace DtCms.Web.Admin.Activity
{
    public partial class ActivityReport : DtCms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DtCms.BLL.Activity activity = new DtCms.BLL.Activity();
            

            
        
            int[] icount = new int[4];
            string[] irange=new string[4];

            icount[0] = activity.GetCountMode("审核通过");
            icount[1] = activity.GetCountMode("不批准");
            icount[2] = activity.GetCountMode("退回修改");
            icount[3] = activity.GetCountMode("未审核");
            


        
            Bitmap bm = new Bitmap(700, 300);

            Graphics g;
            g = Graphics.FromImage(bm);
            //由此Bitmap实例创建Graphic实例
            g.Clear(Color.White);

            g.DrawString("活动审核情况", new Font("微软雅黑", 16), Brushes.Black, new Point(150, 5));

            irange[0] = "审核通过";
            irange[1] = "不批准";
            irange[2] = "退回修改";
            irange[3] = "未审核";
            
 

            Point myRec = new Point(515, 34);
            Point myDec = new Point(540, 30);
            Point myTxt = new Point(628, 30);
            g.DrawString("单位：个", new Font("微软雅黑", 9), Brushes.Black, new Point(555, 12));

            for (int i = 0; i < 4; i++)
            {
                g.FillRectangle(new SolidBrush(GetColor(i)), myRec.X, myRec.Y, 20, 10);
                //填充小方块
                g.DrawRectangle(Pens.Black, myRec.X, myRec.Y, 20, 10);
                //绘制小方块
                g.DrawString(irange[i].ToString()+"", new Font("微软雅黑", 9), Brushes.Black, myDec);
                //绘制小方块右边的文字
                g.DrawString(icount[i].ToString(), new Font("微软雅黑", 9), Brushes.Black, myTxt);
                myRec.Y += 15;
                myDec.Y += 15;
                myTxt.Y += 15;
            }
            //从数据库中得到的数值大小，绘制扇型，并以相应色彩填充扇型
            int iTatal = 0;
            float fCurrentAngle = 0;
            float fStartAngle = 0;
            for (int i = 0; i < icount.Length; i++)
            {
                iTatal = iTatal + icount[i];
            }
            for (int i = 0; i < icount.Length; i++)
            {
                //以下代码是获得要绘制扇型的开始角度
                if (i == icount.Length - 1)
                {
                    fCurrentAngle = 360 - fStartAngle;
                }
                else
                {
                    int iTemp = icount[i];
                    fCurrentAngle = (iTemp * 360) / iTatal;
                }


                g.FillPie(new SolidBrush(GetColor(i)), 100, 40, 250, 250, fStartAngle, fCurrentAngle);
                fStartAngle += fCurrentAngle;
            }

            Pen p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, 1, 1, 698, 298);
           // filestream fs = new filestream(Pie.jpg, filemode.create);
           // System.Drawing.Image originalImage = System.Drawing.Bitmap.FromStream(file.InputStream);
               // pbphoto.image.save(fs, imageformat.jpeg);
            bm.Save(@"D:\gradution_file\Dtcms.Web\Admin\Images\Pie.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
           
           // bm.Save(Response.OutputStream, ImageFormat.Jpeg);
            g.Dispose();

        }
        private Color GetColor(int itemIndex)
        {
            Color MyColor;
            int i = itemIndex;
            switch (i)
            {
                case 0:
                    MyColor = Color.FromArgb(229, 187, 129);
                    return MyColor;
                case 1:
                    MyColor = Color.FromArgb(131, 175, 155);

                    return MyColor;
                case 2:
                    MyColor = Color.FromArgb(196, 226, 216);
                    return MyColor;
                case 3:
                    MyColor = Color.FromArgb(173, 137, 118);
                    return MyColor;
                case 4:
                    MyColor = Color.FromArgb(224, 160, 158);
                    return MyColor;
                case 5:
                    MyColor = Color.FromArgb(255, 150, 128);
                    return MyColor;
                case 6:
                    MyColor = Color.FromArgb(255, 255, 255);
                    return MyColor;
                case 7:
                    MyColor = Color.FromArgb(96, 143, 159);
                    return MyColor;
                case 8:
                    MyColor = Color.FromArgb(252, 157, 154);
                    return MyColor;
                case 9:
                    MyColor = Color.FromArgb(131, 175, 155);
                    return MyColor;
                case 10:
                    MyColor = Color.FromArgb(200, 200, 169);
                    return MyColor;
                case 11:
                    MyColor = Color.FromArgb(249, 205, 173);
                    return MyColor;
                case 12:
                    MyColor = Color.FromArgb(254, 67, 101);
                    return MyColor;
                default:
                    MyColor = Color.FromArgb(200, 200, 200);
                    return MyColor;
            }
        
        }
    }
}