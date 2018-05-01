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
    public partial class Add : DtCms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkLoginLevel("addManage");
            }
        }
        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DtCms.Model.Societies model = new DtCms.Model.Societies();
            DtCms.BLL.Societies bll = new DtCms.BLL.Societies();
            string SocietiesName = txtSocietiesName.Text.Trim();
            string SocietiesRemark = txtContent.Value.Trim();

            model.SocietiesName = SocietiesName;
            model.SocietiesRemark = SocietiesRemark;

            bll.Add(model);
            JscriptPrint("添加社团成功啦！", "list.aspx", "Success");
        }
    }
}
