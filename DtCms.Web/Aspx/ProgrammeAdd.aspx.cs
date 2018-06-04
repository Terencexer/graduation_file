using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DtCms.Web.Aspx
{
    public partial class ProgrammeAdd : DtCms.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PanelAdd.Visible = false;
                PanelActor.Visible = false;
               
            }
        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
            {
                Button buttonadd = e.Row.FindControl("ButtonAdd") as Button;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonAdd")
            {
                PanelAdd.Visible = true;
                int dataItemIndex = Convert.ToInt32(e.CommandArgument);
                int papeSize = GridView1.PageSize;
                int pageIndex = GridView1.PageIndex;
                int rowIndex = dataItemIndex - papeSize * pageIndex;
                string activityId = GridView1.Rows[rowIndex].Cells[0].Text;
                HiddenFieldP.Value = activityId;
                DtCms.BLL.Programme programme = new DtCms.BLL.Programme();
                if(programme.PExists(activityId, activityId.ToString() + "1")==true)
                TextBox1.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "1").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "2") == true)
                TextBox2.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "2").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "3") == true)
                TextBox3.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "3").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "4") == true)
                TextBox4.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "4").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "5") == true)
                TextBox5.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "5").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "6") == true)
                TextBox6.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "6").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "7") == true)
                TextBox7.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "7").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "8") == true)
                TextBox8.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "8").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "9") == true)
                TextBox9.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "9").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "10") == true)
                TextBox10.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "10").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "11") == true)
                TextBox11.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "11").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "12") == true)
                TextBox12.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "12").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "13") == true)
                TextBox13.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "13").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "14") == true)
                TextBox14.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "14").ProgrammeName.ToString();
                if (programme.PExists(activityId, activityId.ToString() + "15") == true)
                TextBox15.Text = programme.QueryOneRecord(activityId, activityId.ToString() + "15").ProgrammeName.ToString();

            }
        }

        protected void ButtonPSub_Click(object sender, EventArgs e)
        {
            
            if (TextBox1.Text != "")
            {    DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label1.Text.ToString()) == true)
                {
                    programme1.ProgrammeName = TextBox1.Text.ToString();
                    programme1.ProgrammeId = HiddenFieldP.Value + Label1.Text.ToString();
                    programme1Bll.Update(programme1);
                   
                }

                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label1.Text.ToString();
                    programme1.ProgrammeName = TextBox1.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox2.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label2.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label2.Text.ToString();
                    programme1.ProgrammeName = TextBox2.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label2.Text.ToString();
                    programme1.ProgrammeName = TextBox2.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox3.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label3.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label3.Text.ToString();
                    programme1.ProgrammeName = TextBox3.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                   
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label3.Text.ToString();
                    programme1.ProgrammeName = TextBox3.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox4.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label4.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label4.Text.ToString();
                    programme1.ProgrammeName = TextBox4.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label4.Text.ToString();
                    programme1.ProgrammeName = TextBox4.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox5.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label5.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label5.Text.ToString();
                    programme1.ProgrammeName = TextBox5.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label5.Text.ToString();
                    programme1.ProgrammeName = TextBox5.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox6.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label6.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label6.Text.ToString();
                    programme1.ProgrammeName = TextBox6.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label6.Text.ToString();
                    programme1.ProgrammeName = TextBox6.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox7.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label7.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label7.Text.ToString();
                    programme1.ProgrammeName = TextBox7.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label7.Text.ToString();
                    programme1.ProgrammeName = TextBox7.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox8.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label8.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label8.Text.ToString();
                    programme1.ProgrammeName = TextBox8.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label8.Text.ToString();
                    programme1.ProgrammeName = TextBox8.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox9.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label9.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label9.Text.ToString();
                    programme1.ProgrammeName = TextBox9.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label9.Text.ToString();
                    programme1.ProgrammeName = TextBox9.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox10.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label10.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label10.Text.ToString();
                    programme1.ProgrammeName = TextBox10.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label10.Text.ToString();
                    programme1.ProgrammeName = TextBox10.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox11.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label11.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label11.Text.ToString();
                    programme1.ProgrammeName = TextBox11.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label11.Text.ToString();
                    programme1.ProgrammeName = TextBox11.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox12.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label12.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label12.Text.ToString();
                    programme1.ProgrammeName = TextBox12.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label12.Text.ToString();
                    programme1.ProgrammeName = TextBox12.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox13.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label13.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label13.Text.ToString();
                    programme1.ProgrammeName = TextBox13.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label13.Text.ToString();
                    programme1.ProgrammeName = TextBox13.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox14.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label14.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label14.Text.ToString();
                    programme1.ProgrammeName = TextBox14.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label14.Text.ToString();
                    programme1.ProgrammeName = TextBox14.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }
            }

            if (TextBox15.Text != "")
            {
                DtCms.Model.Programme programme1 = new DtCms.Model.Programme();
                DtCms.BLL.Programme programme1Bll = new DtCms.BLL.Programme();
                if (programme1Bll.PExists(HiddenFieldP.Value, HiddenFieldP.Value + Label15.Text.ToString()) == true)
                {
                    programme1.ProgrammeId = HiddenFieldP.Value + Label15.Text.ToString();
                    programme1.ProgrammeName = TextBox15.Text.ToString();
                    programme1Bll.Update(programme1);
                }
                else
                {
                    programme1.ActivityId = HiddenFieldP.Value;
                    programme1.ProgrammeId = HiddenFieldP.Value + Label15.Text.ToString();
                    programme1.ProgrammeName = TextBox15.Text.ToString();

                    DtCms.BLL.Programme bll = new DtCms.BLL.Programme();
                    bll.Add(programme1);
                }

            }
            Response.Write("<script>alert('提交成功。')</script>");
            PanelAdd.Visible = false;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "1";
            
        }

        protected void ButtonSub_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewActor.Rows.Count; i++)
            {

                CheckBox checkboxselect = GridViewActor.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (checkboxselect.Checked == true)
                {
                    string actorname = GridViewActor.Rows[i].Cells[1].Text;
                    string programid = HiddenFieldP.Value + HiddenFieldActor.Value;
                    DtCms.BLL.Actor actorBll = new DtCms.BLL.Actor();
                    bool isexist = actorBll.AcExists(programid, actorname);
                    if (isexist == false)
                    {
                        DtCms.Model.Actor actor = new DtCms.Model.Actor();
                        actor.ActivityId = HiddenFieldP.Value;
                        actor.ProgrammeId = programid;
                        actor.UserName = actorname;
                        actor.TureName = GridViewActor.Rows[i].Cells[2].Text;
                        actor.UserTel = GridViewActor.Rows[i].Cells[3].Text;
                        actorBll.Add(actor);
                        ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('提交成功！')</script>");
                    }
                    else ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('提交失败！您已选择了该人员，请不要重复选择！')</script>");
                }
            }

            
        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "2";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "3";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "4";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "5";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "6";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "7";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "8";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "9";
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "10";
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "11";
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "12";
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "13";
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "14";
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            PanelActor.Visible = true;
            HiddenFieldActor.Value = "15";
        }
    }
}