using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class Bonusff : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_Award_Team"));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('奖金结算成功!');", true);
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    MySQL(string.Format(" exec proc_fenhong"));
        //    //  MySQL(string.Format(" exec proc_datebonus"));
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('分红发放成功!');", true);
        //}
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_lingshou"));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('零售积分结算成功!');", true);
        }

        protected void lbtnShareOut_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlParameter[] param = {
                //new System.Data.SqlClient.SqlParameter("@IsAuto",SqlDbType.Int,4)
            };
            param[0].Value = 1;//手动
            int iResult = bonusBLL.ExecProcedure("[proc_Award_Team]", param);

            if (iResult == 1)
            {
                MessageBox.Show(this, "发放成功！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "发放失败！");
            }
        }

        private void BindData()
        {
            bind_repeater(sysLogBLL.GetList("LogType = 1000"), Repeater1, "LogDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
