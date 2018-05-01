using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtCms.Web.Admin.Advertising
{
    public partial class AdvAdd : DtCms.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkLoginLevel("addAdvertising");
        }

        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DtCms.Model.Advertising model = new DtCms.Model.Advertising();
            DtCms.BLL.Advertising bll = new DtCms.BLL.Advertising();
            model.Title = this.txtTitle.Text.Trim();
            model.AdType = int.Parse(this.rblAdType.SelectedValue);
            model.AdRemark = this.txtAdRemark.Text;
            model.AdNum = int.Parse(this.txtAdNum.Text.Trim());
            model.AdPrice = decimal.Parse(this.txtAdPrice.Text);
            model.AdWidth = int.Parse(this.txtAdWidth.Text);
            model.AdHeight = int.Parse(this.txtAdHeight.Text);
            model.AdTarget = this.rblAdTarget.SelectedValue;
            bll.Add(model);
            //保存日志
            SaveLogs("[首页图片管理]增加首页图片：" + model.Title);
            JscriptPrint("首页图片位增加成功啦！", "AdvAdd.aspx", "Success");
        }
    }
}
