using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.admin.finance
{
    public partial class JournalDetail : AdminPageBase//System.Web.UI.Page
    {
        protected int Journal02 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 20, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            long iUserID = Convert.ToInt64(Request.QueryString["UserID"].ToString());
            Journal02 = Convert.ToInt32(Request.QueryString["Journal02"].ToString());

            if (Journal02 == 1)
            {
                ltRemark.Text = "积分账户";
                ltIncome.Text = "积分账户";
                ltExpenditure.Text = "积分账户";
                ltBalance.Text = "积分账户";
            }
            else if (Journal02 == 2)
            {
                ltRemark.Text = "云图";
                ltIncome.Text = "云图";
                ltExpenditure.Text = "云图";
                ltBalance.Text = "云图";
            }
            else if (Journal02 == 3)
            {
                ltRemark.Text = "购物币(RGC)";
                ltIncome.Text = "购物币(RGC)";
                ltExpenditure.Text = "购物币(RGC)";
                ltBalance.Text = "购物币(RGC)";
            }
            else if (Journal02 == 4)
            {
                ltRemark.Text = "云图(HGW)";
                ltIncome.Text = "云图(HGW)";
                ltExpenditure.Text = "云图(HGW)";
                ltBalance.Text = "云图(HGW)";
            }
            else if (Journal02 == 5)
            {
                ltRemark.Text = "年分红动态钱包";
                ltIncome.Text = "年分红动态钱包";
                ltExpenditure.Text = "年分红动态钱包";
                ltBalance.Text = "年分红动态钱包";
            }

            string strWhere = string.Format("JournalType=" + Journal02 + " and j.UserID=" + iUserID);

            bind_repeater(journalBLL.GetList(strWhere), Repeater1, "JournalDate desc,id desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
