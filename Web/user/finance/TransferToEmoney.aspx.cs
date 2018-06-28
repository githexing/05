using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;

namespace Web.user.finance
{
    public partial class TransferToEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
               // txtBonusAccount.Value = LoginUser.BonusAccount.ToString();//佣金币余额
                //txtEmoney.Value = LoginUser.Emoney.ToString();//现金币余额
               // txtStockMoney.Value = LoginUser.GLmoney.ToString();//购物币余额

                BindCurrency();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("TransferConfirm") + "')";
                btnSearch.Text = GetLanguage("Search");//搜索
              
            }
        }

        private void BindCurrency()
        {
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
                //dropCurrency.Items.Add(new ListItem("云图转换云盾", "1"));
                //dropCurrency.Items.Add(new ListItem("云图转云图", "2"));
                dropCurrency.Items.Add(new ListItem("云盾转给其他会员", "3"));
                //dropCurrency.Items.Add(new ListItem("云图转给其他会员", "4"));
                //dropCurrency.Items.Add(new ListItem("云图转其他会员", "5"));

                dropType.Items.Add(new ListItem("-请选择-", "0"));
                //dropType.Items.Add(new ListItem("云图转换云盾", "1"));
                //dropType.Items.Add(new ListItem("云图转云图", "2"));
                dropType.Items.Add(new ListItem("云盾转给其他会员", "3"));
                //dropType.Items.Add(new ListItem("云图转给其他会员", "4"));
                //dropType.Items.Add(new ListItem("云图转其他会员", "5"));
            }
            else
            {
                dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
                //dropCurrency.Items.Add(new ListItem("Currency to MDD drill", "1"));
                //dropCurrency.Items.Add(new ListItem("Currency to Registered currency", "2"));
                dropCurrency.Items.Add(new ListItem("Currency to shopping currency", "3"));
                //dropCurrency.Items.Add(new ListItem("Registered currency to shopping currency", "4"));
                //dropCurrency.Items.Add(new ListItem("Registered currency to other members", "5"));

                dropType.Items.Add(new ListItem("-Please choose-", "0"));
                //dropType.Items.Add(new ListItem("Currency", "1"));
                //dropType.Items.Add(new ListItem("MDD Drill", "2"));
                dropType.Items.Add(new ListItem("Platform cost", "3"));
                //dropType.Items.Add(new ListItem("Shopping currency", "4"));
                //dropType.Items.Add(new ListItem("Registered currency", "5"));
            }
        }

        private bool CheckOpen(string value)
        {
            switch (value)
            {
                case "1":
                    var iOpen1 = getParamInt("Transfer4");
                    if (iOpen1 != 1)//云图转换云盾
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case "2":
                    var iOpen2 = getParamAmount("Transfer5");
                    if (iOpen2 != 1)//云图转云图
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case "3":
                    var iOpen3 = getParamAmount("Transfer8");
                    if (iOpen3 != 1)//云盾转给其他会员
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case "4":
                    var iOpen4 = getParamAmount("Transfer7");
                    if (iOpen4 != 1)//云图转给其他会员
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case "5":
                    var iOpen5 = getParamAmount("Transfer8");
                    if (iOpen5 != 1)//云图转其他会员
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                default://请选择转账类型
                    MessageBox.ShowBox(this.Page, GetLanguage("ChooseTransfer"), Library.Enums.ModalTypes.warning);//请选择转账类型
                    return false;
            }
            return true;
        }

        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Text.Trim();
            var user = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (user != null)
            {
                txtTrueName.Text = user.NiceName;
            }
            else
            {
                txtTrueName.Text = string.Empty;
                MessageBox.ShowBox(this.Page, GetLanguage("numberIsExist"), Library.Enums.ModalTypes.warning);//会员编号不存在
        
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

            if (dropCurrency.SelectedValue == "0")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("ChooseTransfer"), Library.Enums.ModalTypes.warning);//请选择转账类型
                return;
            }
            if (!CheckOpen(dropCurrency.SelectedValue))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.warning);//该功能未开放
                return;
            }
            int iTypeID = int.Parse(dropCurrency.SelectedValue);
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("transferMoneyIsnull"), Library.Enums.ModalTypes.warning);//转账金额不能为空
                return;
            }
            if (string.IsNullOrEmpty(txtSecondPassword.Text.Trim()))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("SecondaryISNUll"), Library.Enums.ModalTypes.warning);//二级密码不能为空
                return;
            }
            
            decimal dResult = 0;
            if (decimal.TryParse(txtMoney.Text.Trim(), out dResult))
            {
                decimal dTrans = getParamAmount("Transfer1");//转账最低金额
                decimal d = getParamAmount("Transfer2");//转账倍数基数
                if (dResult < dTrans)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("equalTo") + dTrans , Library.Enums.ModalTypes.warning);//转账金额必须是大于等于XX的整数
                    return;
                }
                if (d != 0 && dResult % d != 0)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("amountMustbe") +  d + GetLanguage("Multiples"), Library.Enums.ModalTypes.warning);//转账金额必须是XX的倍数
                    return;
                }
            }

            if (iTypeID != 0)
            {
                if ((iTypeID == 1 || iTypeID == 2) && dResult > userInfo.BonusAccount)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("NotCurrent"), Library.Enums.ModalTypes.warning);//云图余额不足
                    return;
                }
                else if (iTypeID == 3 && dResult > userInfo.Emoney)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("moneyDollars"), Library.Enums.ModalTypes.warning);//云盾余额不足
                    return;
                }
                else if (iTypeID == 4 && dResult > userInfo.StockMoney)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("balanceDollars"), Library.Enums.ModalTypes.warning);//云图余额不足
                    return;
                }
                else if (iTypeID == 5 && dResult > userInfo.ShopAccount)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("NotCurrency"), Library.Enums.ModalTypes.warning);//云图余额不足
                    return;
                }
            }
            
            string strUserCode = txtUserCode.Text.Trim();
            var toUser = userBLL.GetModel(" UserCode='" + strUserCode + "'");
            if (toUser == null)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("numberIsExist"), Library.Enums.ModalTypes.warning);//会员编号不存在
                return;
            }
            else
            {
                toUserID = int.Parse(toUser.UserID.ToString());
            }

            if (toUserID <= 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                return;
            }

            if (dropCurrency.SelectedValue == "5")
            {
                if (toUserID == userInfo.UserID)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("TransferToOuner"), Library.Enums.ModalTypes.warning);//不能给自己转账
                    return;
                }

                if (!userBLL.OnRecommendSameLine(userInfo.UserID, toUserID))
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                    return;
                }
            }

            if(!userInfo.SecondPassword.Equals(PageValidate.GetMd5(txtSecondPassword.Text.Trim())))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PasswordError"), Library.Enums.ModalTypes.error);//二级密码错误
                return;
            }

            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = dResult;
            changeInfo.ChangeType = Convert.ToInt32(dropCurrency.SelectedValue);
            changeInfo.ChangeDate = DateTime.Now;
            changeInfo.Change005 = dResult - dResult * getParamAmount("Transfer3") / 100;

            if (changeBLL.Add(changeInfo) > 0)
            {
                try
                {
                    if (changeInfo.ChangeType == 1)//云图转换云盾
                    {
                        #region 云图转换云盾


                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（流通币减少）
                            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                            model.UserID = userInfo.UserID;
                            model.Remark = "云图转换云盾";
                            model.RemarkEn = "Cash register integral transform integral";
                            model.InAmount = 0;
                            model.OutAmount = changeInfo.Amount;

                            model.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            model.JournalDate = DateTime.Now;
                            model.JournalType = (int)Library.AccountType.云图;
                            model.Journal01 = toUserID;
                            journalBLL.Add(model);

                            //加入流水账表(购物币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "云图转换云盾";
                            journalInfo.RemarkEn = "Cash register integral transform integral";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = (int)Library.AccountType.云盾;
                            journalInfo.Journal01 = userInfo.UserID;

                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在

                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 2)//云图转云图
                    {
                        #region 云图转云图
                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("BonusAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockMoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "云图转云图";
                            jmodel.RemarkEn = "Cash conversion points";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;

                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "BonusAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = (int)Library.AccountType.云图;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "云图转云图";
                            journalInfo.RemarkEn = "Cash conversion points";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = (int)Library.AccountType.云图;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 3)//云盾转给其他会员
                    {
                        #region 云盾转给其他会员
                        decimal dBonusAccount = userBLL.GetMoney(getLoginID(), "Emoney");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("Emoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("Emoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "云盾转给" + txtUserCode.Text; ;
                            jmodel.RemarkEn = "Currency to shopping currency";
                            jmodel.InAmount = 0;  
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "Emoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = (int)Library.AccountType.云盾;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "获得" + LoginUser.UserCode + "转来云盾";
                            journalInfo.RemarkEn = "Currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "Emoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = (int)Library.AccountType.云盾;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 4)//云图转给其他会员
                    {
                        #region 云图转给其他会员
                        decimal dStockAccount = userBLL.GetMoney(getLoginID(), "StockMoney");
                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockMoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockMoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "云图转给" + txtUserCode.Text;
                            jmodel.RemarkEn = "Investment points transferred to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "StockMoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = (int)Library.AccountType.云图;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "获得" + LoginUser.UserCode + "转来云图";
                            journalInfo.RemarkEn = "Investment points transferred to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = (int)Library.AccountType.云图;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                            return;
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 5)//云图转其他会员
                    {
                        #region 云图转其他会员
                        decimal dStockAccount = userBLL.GetMoney(getLoginID(), "ShopAccount");
                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("ShopAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("ShopAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "云图转给" + txtUserCode.Text;
                            jmodel.RemarkEn = "Transaction code transfer to " + txtUserCode.Text;
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(getLoginID(), "ShopAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = (int)Library.AccountType.云图;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "获得" + LoginUser.UserCode + "转来云图";
                            journalInfo.RemarkEn = "Get " + LoginUser.UserCode + " Transaction code transfer";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "ShopAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = (int)Library.AccountType.云图;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                        }
                        #endregion
                    }
                }
                catch
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("addError"), Library.Enums.ModalTypes.error);//添加流水账错误
            
                }

                MessageBox.ShowBox(this.Page, GetLanguage("TransferSuccess"), Library.Enums.ModalTypes.success, "TransferToEmoney.aspx");//转账成功
        
            }
            else
            {
                MessageBox.ShowBox(this.Page, GetLanguage("addError"), Library.Enums.ModalTypes.error);//操作失败
               
            }
        }

        private string GetWhere()
        {
            string strWhere = string.Format(" and c.UserID=" + getLoginID());

            if (dropType.SelectedValue != "0")
            {
                strWhere += " AND c.ChangeType = " + dropType.SelectedValue + "";
            }

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            bind_repeater(changeBLL.GetDataSet2(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( dropCurrency.SelectedValue == "3" || dropCurrency.SelectedValue == "4" || dropCurrency.SelectedValue == "5")
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtTrueName.Text = string.Empty;
            }
            else
            {
                txtUserCode.Enabled = false;
                txtUserCode.Text = LoginUser.UserCode;
                txtTrueName.Text = LoginUser.NiceName;
            }
        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string strMoney = txtMoney.Text.Trim();
            if (strMoney != "")
            {
                decimal dMoney = decimal.Parse(strMoney);
                decimal dValue = dMoney - dMoney * getParamAmount("Transfer3") / 100;

                txtActualAmount.Value = dValue.ToString();
            }
        }

       
    }
}