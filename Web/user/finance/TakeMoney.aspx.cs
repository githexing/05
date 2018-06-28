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
using System.Collections.Generic;

namespace Web.user.finance
{
    public partial class TakeMoney : PageCore// System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                //ream.Text = "提现说明:月分红静态钱包需在每月的"+ getParamVarchar("ATM4") + "号提现，月分红动态钱包需在每月的"+ getParamVarchar("ATM5") + "号提现，年分红均需要在年底提现";
                ream.Text = "提现说明:月分红静态钱包需在每月的25，26号提现，月分红动态钱包需在每月的5,6|15.16|25.26号提现，年分红均需要在满一年提现";
                //ShowData();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 提现金额
        /// </summary>
        private void ShowData()
        {
            decimal dMin = getParamAmount("ATM1");

           // txtBonusAccount.Value = LoginUser.BonusAccount.ToString("0.00") + GetLanguage("USD");

            if (LoginUser.BonusAccount >= dMin)
            {
                btnSubmit.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
            }
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 2)
            {
                str = "月分红静态钱包";
            }
            if (type == 3)
            {
                str = "月分红动态钱包";
            }
            if (type == 4)
            {
                str = "年分红静态钱包";
            }
            if (type == 5)
            {
                str = "年分红动态钱包";
            }
            if (type == 6)
            {
                str = "本金提现";
            }
            return str;
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + "";
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "" && PageValidate.IsDateTime(strStart))
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "" && PageValidate.IsDateTime(strEnd))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "" && PageValidate.IsDateTime(strStart) && PageValidate.IsDateTime(strEnd))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStart + "' and '" + strEnd + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            //week = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            //var open2 = getParamAmount("extract4");
            //if (week != open2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请在提现日进行此功能操作，谢谢!');", true);
            //    return;
            //}
            string filename = "";
            lgk.Model.tb_user user = userBLL.GetModel(LoginUser.UserID);
            #region 提现金额验证
            if (txtTake.Text.Trim() == "")
            {
                MessageBox.MyShow(this, GetLanguage("WithdrawalIsnull"));//提现金额不能为空
                return;
            }
            decimal resultNum = 0;
            int Journal02 = 0;
            decimal tx_bs = getParamAmount("ATM2");//倍数基数
            if (user.Emoney == 0)
            {
                MessageBox.MyShow(this, "消费金为0，无法提现");//提现金额不能为空
                return;
            }
           
            if (decimal.TryParse(txtTake.Text.Trim(), out resultNum))
            {
                if (resultNum < getParamAmount("ATM1"))
                {
                    MessageBox.MyShow(this, "提现金额必须大于最低提现金额");//提现金额必须大于最低提现金额!
                    return;
                }
               
                    if (resultNum > user.Emoney)
                    {

                        MessageBox.MyShow(this, "云盾余额不足");//提现金额必须小于消费金金额!
                        return;
                    }
                 
                    lgk.Model.tb_takeMoney takemodel = takeBLL.GetModel(" UserID=" + LoginUser.UserID + " and Flag=0");
                    if (takemodel != null)
                    {
                        MessageBox.MyShow(this, "您有待审核的申请记录，请等待后台审核后再申请！");//提现金额必须大于最低提现金额!
                        return;
                    }
                    user.Emoney = user.Emoney - resultNum;
                    userBLL.Update(user);

                 
            }
            else
            {
                MessageBox.MyShow(this, GetLanguage("AmountErrors"));//金额格式输入错误
                return;
            }

       
            #endregion

            #endregion

            #region 提现申请
            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakePoundage = getParamAmount("ATM3") / 100;
            takeMoneyInfo.TakeMoney = resultNum;
            takeMoneyInfo.RealityMoney = Convert.ToDecimal(txtExtMoney.Value);
            takeMoneyInfo.Flag = 0;
            takeMoneyInfo.UserID = getLoginID();
            takeMoneyInfo.BonusBalance = user.Emoney - takeMoneyInfo.TakeMoney;

            takeMoneyInfo.BankName = user.BankName;
            takeMoneyInfo.Take003 = user.BankBranch;
            takeMoneyInfo.BankAccount = user.BankAccount;
            takeMoneyInfo.BankAccountUser = user.BankAccountUser;
            takeMoneyInfo.Take001 = Journal02;
            #endregion

            #region 加入流水账表


            journalInfo.UserID = takeMoneyInfo.UserID;
            journalInfo.Remark = "会员提现";
            journalInfo.RemarkEn = "Cash withdrawal";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = takeMoneyInfo.TakeMoney;
            journalInfo.BalanceAmount = takeMoneyInfo.BonusBalance;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = 1;
            journalInfo.Journal01 = takeMoneyInfo.UserID;
            journalInfo.Journal02 = Journal02;
            #endregion

            if (takeBLL.Add(takeMoneyInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount(filename, getLoginID(), takeMoneyInfo.TakeMoney, 0) > 0 )
            {

                //string ss = (GetLanguage("MessageTakeMoney").Replace("{username}", LoginUser.UserCode)).Replace("{time}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(journalInfo.JournalDate).ToString("yyyy/MM/dd HH:mm"));//添加短信内容
                //SendMessage((int)LoginUser.UserID, LoginUser.PhoneNum, ss);
                
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='TakeMoney.aspx';", true);//申请提现成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
            }
        }
        public string dateStr(int Month ,string day)
        {
            string str = "";
            if (DateTime.Now.Month < 10)
            {
                str = DateTime.Now.Year+ "-" + "0" + Month + "-" + day;
            }else
            {
                str = DateTime.Now.Year+"-" + Month+"-" + day;
            }
            return str;
        }
        protected void txtTake_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            
            if (txtTake.Text.Trim() != "")
            {
                decimal money = Convert.ToDecimal(txtTake.Text);

                value = (money * (getParamAmount("ATM3") / 100));//提现手续费

                lblFee.Text = (money - value).ToString();
                txtExtMoney.Value = value.ToString();
            }
            else
            {
                txtExtMoney.Value = "";
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string filename = "";
            if (e.CommandName == "change")
            {
                long iID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_takeMoney take = takeBLL.GetModel(iID);
                if (take == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (take.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(take.UserID));
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();               
                model.BalanceAmount = user.Emoney + take.TakeMoney;
                filename = "Emoney";
                user.Emoney = user.Emoney + take.RealityMoney;
                model.Journal02 = take.Take001;

                if (take.Take001 < 6)
                {
                    model.UserID = take.UserID;
                    model.Remark = "取消提现";
                    model.InAmount = take.TakeMoney;
                    model.OutAmount = 0;
                    model.JournalDate = DateTime.Now;
                    model.JournalType = 1;
                    model.Journal01 = take.UserID;
                    if (journalBLL.Add(model) > 0 && userBLL.Update(user) && UpdateAccount(filename, take.UserID, take.TakeMoney, 1) > 0 && takeBLL.Delete(iID))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='TakeMoney.aspx';", true);//取消成功  
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('你已经取消提现申请，请等待审核...');", true);//取消失败
                }
            }
        }

        

        protected void dropShore_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTake.Text = "";
            txtExtMoney.Value = "";//本金提现手续费
        }
    }
}