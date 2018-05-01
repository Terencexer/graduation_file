using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DtCms.Web.Admin.Societies
{
    public partial class edit : DtCms.Web.UI.ManagePage
    {
        public int Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["id"] as string, out this.Id))
            {
                JscriptMsg(350, 230, "错误提示", "<b>出现错误啦！</b>您要修改的信息不存在或参数不正确。", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(this.Id);
            }
        }
        //赋值操作
        private void ShowInfo(int editID)
        {
            DtCms.BLL.Societies bll = new DtCms.BLL.Societies();
            DtCms.Model.Societies model = new DtCms.Model.Societies();
            model = bll.GetModel(editID);
            txtSocietiesName.Text = model.SocietiesName;
            txtContent.Value = model.SocietiesRemark;
        }
        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DtCms.Model.Societies model = new DtCms.Model.Societies();
            DtCms.BLL.Societies bll = new DtCms.BLL.Societies();
            string SocietiesName = txtSocietiesName.Text.Trim();
            string SocietiesRemark = txtContent.Value.Trim();

            model.Id = Id;
            model.SocietiesName = SocietiesName;
            model.SocietiesRemark = SocietiesRemark;

            bll.Update(model);
            JscriptPrint("修改社团成功啦！", "list.aspx", "Success");
        }
    }
}
