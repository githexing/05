using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.cash
{
    public partial class CashSellList : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 46, getLoginID());//权限

            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 查询条件
        public string GetWhere()
        {
            string strWhere = " 1=1 ";

            int type = Convert.ToInt32(dropType.SelectedValue);
            string strInput = txtInput.Value.Trim();
            if (!string.IsNullOrEmpty(strInput))
            {
                if (type == 1)
                {
                    strWhere += " and u.UserCode like '%" + strInput + "%'";
                }
                else if (type == 2)
                {
                    strWhere += " and u.TrueName like '%" + strInput + "%'";
                }
                else if (type == 3)
                {
                    strWhere += " and s.OrderCode like '%" + strInput + "%'";
                }
            }
            int state = Convert.ToInt32(dropState.SelectedValue);
            if (state > -2)
            {
                strWhere += " and s.IsSell=" + state;
            }

            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),s.SellDate,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),s.SellDate,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),s.SellDate,120) between '" + strStart + "' and '" + strEnd + "'");
            }

            return strWhere;
        }
        #endregion

        public void BindData()
        {
            int PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = cashsellBLL.GetJoinUserRecordCount(GetWhere());
            if (AspNetPager1.RecordCount > 0)
            {
                tr1.Visible = false;
            }
            else
            {
                tr1.Visible = true;
            }
            if (AspNetPager1.RecordCount > PageSize)
            {
                AspNetPager1.Visible = true;
            }
            else
            {
                AspNetPager1.Visible = false;
            }

            int i = AspNetPager1.CurrentPageIndex - 1;
            int startRecord = AspNetPager1.PageSize * i + 1;
            int endRecord = startRecord + AspNetPager1.PageSize - 1;

            DataSet ds = cashsellBLL.GetListByPage(GetWhere(), "SellDate desc", startRecord, endRecord);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long id = Convert.ToInt64(e.CommandArgument);
            string tag = e.CommandName;
            if (tag.Equals("cancel"))
            {
                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(id);
                if (cashsellInfo == null)
                {
                    MessageBox.ShowBox(this.Page, "订单不存在", Library.Enums.ModalTypes.warning);
                    return;
                }
                if (cashsellInfo.IsSell == -1)
                {
                    MessageBox.ShowBox(this.Page, "订单已撤销，请勿重复操作", Library.Enums.ModalTypes.warning);
                    return;
                }
                else if (cashsellInfo.IsSell == 1)
                {
                    MessageBox.ShowBox(this.Page, "订单已完成，无法撤销", Library.Enums.ModalTypes.warning);
                    return;
                }
                else if (cashsellInfo.IsSell == 0)
                {
                    int SurplusNum = cashsellInfo.Number - cashsellInfo.SaleNum;
                    string strRemark = "后台已撤销卖出订单[" + cashsellInfo.OrderCode + "]，返还剩余云图[" + SurplusNum + "]";
                    string strRemarkEn = "The manager has revoked the seller's order [" + cashsellInfo.OrderCode + "] and returned the remaining YT [" + SurplusNum + "]";
                    //修改订单状态
                    cashsellInfo.IsUndo = 1;
                    cashsellInfo.IsSell = -1;
                    cashsellBLL.Update(cashsellInfo);

                    int iJtype = (int)Library.AccountType.云图;//币种
                    UpdateAccount("BonusAccount", cashsellInfo.UserID, SurplusNum, iJtype);//终止交易，将云图返还卖家
                    SetAccount(cashsellInfo.UserID, Convert.ToDecimal(SurplusNum * 1.00), strRemark, strRemarkEn, cashsellInfo.UserID, iJtype);//插入流水

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = strRemark;
                    log.LogType = 24;//
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "卖家已撤销订单";//
                    log.IsDeleted = 0;
                    log.Log1 = cashsellInfo.CashsellID.ToString();//用户UserID
                    log.Log2 = "";// BrowserHelper.UserHostIP(this.Page);
                    log.Log3 = "";//BrowserHelper.UserHostName();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    BindData();
                }
            }
        }

        #region 加入流水账表
        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, string strRemarkEn, long iFromUserID, int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;
            journalInfo.RemarkEn = strRemarkEn;
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.Emoney;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iFromUserID;
            journalBLL.Add(journalInfo);
            #endregion
        }
        #endregion

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string iState = DataBinder.Eval(e.Item.DataItem, "IsSell").ToString();

                Literal ltStateName = e.Item.FindControl("ltStateName") as Literal;
                if (ltStateName != null)
                {
                    ltStateName.Text = GetTradongOrderStateName(iState);
                }
            }
        }
    }
}