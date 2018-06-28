using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class CalcPowerList : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            string strWhere = " UserID=" + getLoginID();
            AspNetPager1.RecordCount = suanliJournalBLL.GetRecordCount(strWhere);
            if (AspNetPager1.RecordCount > 0)
            {
                tr1.Visible = false;
            }
            else
            {
                tr1.Visible = true;
            }
            int i = AspNetPager1.CurrentPageIndex - 1;
            int startRecord = AspNetPager1.PageSize * i + 1;
            int endRecord = startRecord + AspNetPager1.PageSize - 1;
            DataSet ds = suanliJournalBLL.GetListByPage(strWhere, "", startRecord, endRecord);

            //bind_repeater(ds, Repeater1, "JoinTime desc", tr1, AspNetPager1);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        public string GetMoneyTypeName(object obj)
        {
            string strRe = "";
            string strobj = obj.ToString();
            if (strobj == "0")
            {
                strRe = "购买矿机";
            }
            else if (strobj == "1")
            {
                strRe = "推荐赠送";
            }
            else if (strobj == "2")
            {
                strRe = "签到赠送";
            }
            else if (strobj == "3")
            {
                strRe = "注册赠送";
            }
            return strRe;
        }

    }
}