using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DtCms.Common;

namespace DtCms.Web.Admin.Article
{
    public partial class Add : DtCms.Web.UI.ManagePage
    {
        public DtCms.BLL.Article bll = new DtCms.BLL.Article();
        public DtCms.Model.Article model = new DtCms.Model.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("addArticle");
                //绑定类别
                ChannelTreeBind(0, "请选择所属类别...", (int)Channel.Article, this.ddlClassId);
                if (!string.IsNullOrEmpty(Request.Params["classId"]))
                {
                    ddlClassId.SelectedValue = Request.Params["classId"].Trim();
                }
            }
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.Author = txtAuthor.Text.Trim();
            model.Form = txtForm.Text.Trim();
            //自动提取关健字
            if (txtKeyword.Text.Trim() != string.Empty)
            {
                model.Keyword = txtKeyword.Text.Trim();
            }
            else
            {
                model.Keyword = txtTitle.Text.Trim();
            }
            //自动提取摘要
            if (txtZhaiyao.Text.Trim() != string.Empty)
            {
                model.Zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 250);
            }
            else
            {
                model.Zhaiyao = Utils.DropHTML(txtContent.Value, 250);
            }
            //自动提取导读
            if (txtDaodu.Text.Trim() != string.Empty)
            {
                model.Daodu = Utils.DropHTML(txtDaodu.Text, 250);
            }
            else
            {
                model.Daodu = Utils.DropHTML(txtContent.Value, 250);
            }
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.Content = txtContent.Value;
            model.Click = int.Parse(txtClick.Text.Trim());

            model.IsMsg = 0;
            model.IsTop = 0;
            model.IsRed = 0;
            model.IsHot = 0;
            model.IsSlide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.IsMsg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.IsTop = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.IsRed = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.IsHot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.IsSlide = 1;
            }
            bll.Add(model);
            //保存日志
            SaveLogs("[资讯模块]添加文章：" + model.Title);
            JscriptPrint("文章发布成功啦！", "Add.aspx?classId=" + ddlClassId.SelectedValue, "Success");
        }

    }
}
