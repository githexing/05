using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class Invest : PageCore
    {
        lgk.BLL.tb_BuyMachine buymacBLL = new lgk.BLL.tb_BuyMachine();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInvest();
                BindData();
                btnInvest.Text = GetLanguage("Investments");//购买
            }
        }

        private void BindData()
        {
            bind_repeater(buymacBLL.GetList("UserID=" + getLoginID()), Repeater1, "BuyTime desc", tr1, AspNetPager1);
        }

        private void BindInvest()
        {
            int price = getParamInt("InvestPrice");
            lblPrice.Text = price.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnInvest_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user userModel = userBLL.GetModel(getLoginID());
            if (userModel.IsLock == 1)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountLock"), GetLanguage("AccountLockInfo"), Library.Enums.ModalTypes.error);//您的帐号已冻结，不能进行操作
                return;
            }

            if (string.IsNullOrEmpty(userModel.IdenCode))
            {
                MessageBox.ShowBox(this.Page, "您的身份证尚未验证", GetLanguage("AccountLockInfo"), Library.Enums.ModalTypes.warning, "/user/member/MyIDAuthentication.aspx");
                return;
            }

            int num = 0;
            int.TryParse(txtNum.Text, out num);

            if (num <= 0)
            {
                MessageBox.ShowBox(this.Page, "请输入购买数量", Library.Enums.ModalTypes.warning);//请选择投资积分
                return;
            }

            decimal price = getParamAmount("InvestPrice");
            decimal amount = price * num;
            if (userModel.Emoney < amount)
            {
                MessageBox.ShowBox(this.Page, "云盾余额不足", Library.Enums.ModalTypes.warning);//云盾余额不足
                return;
            }

            int flag = proc_BuyMachine(LoginUser.UserID, num);

            if (flag == 0)
            {
                MessageBox.ShowBox(this.Page, "购买成功", Library.Enums.ModalTypes.success ,"/user/finance/Invest.aspx");//投资成功
                BindData();
                return;
            }
            else
            {
                MessageBox.ShowBox(this.Page, "购买失败", Library.Enums.ModalTypes.error);//投资失败
                return;
            }
        }
    }
}