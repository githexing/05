using Library;
using Library.ThirdPartyAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.member
{
    public partial class MyIDAuthentication : PageCore//System.Web.UI.Page
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
            lgk.Model.tb_user userModel = userBLL.GetModel(getLoginID());
            if(userModel != null)
            {
                if (!string.IsNullOrEmpty(userModel.IdenCode))
                {
                    txtIdCard.Text = userModel.IdenCode;
                    txtRealName.Text = userModel.TrueName;
                    txtIdCard.Enabled = true;
                    txtRealName.Enabled = true;
                    btnSubmit.Visible = false;
                }
                else
                {
                    txtIdCard.Text = "";
                    txtRealName.Text = "";
                    txtIdCard.Enabled = true;
                    txtRealName.Enabled = true;
                    btnSubmit.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strIDcard = txtIdCard.Text.Trim();
            if (string.IsNullOrEmpty(strIDcard))
            {
                MessageBox.ShowBox(this.Page, "请输入身份证号码", Library.Enums.ModalTypes.warning);//云盾余额不足
                return;
            }
            string strRealName = txtRealName.Text.Trim();
            if (string.IsNullOrEmpty(strRealName))
            {
                MessageBox.ShowBox(this.Page, "请输入真实姓名", Library.Enums.ModalTypes.warning);//云盾余额不足
                return;
            }
            lgk.Model.tb_user userModel = userBLL.GetModel(getLoginID());
            if (!string.IsNullOrEmpty(userModel.IdenCode))
            {
                MessageBox.ShowBox(this.Page, "您的身份证已通过验证", Library.Enums.ModalTypes.warning);//云盾余额不足
                return;
            }

            string message = "";
            string strswitch = System.Configuration.ConfigurationManager.AppSettings["IDCARD_SWITCH"];
            if (strswitch == "OPEN")
            {
                IDAuthentication ida = new IDAuthentication();
                message = ida.AuthenticationIDAndName(strIDcard, strRealName);
            }
            else
            {
                message = "success";
            }
            
            if(message == "success")
            {
                bool flag = userBLL.UpdateIdCardAndTrueName(getLoginID(), strIDcard, strRealName);
                if (flag)
                {
                    MessageBox.ShowBox(this.Page, "验证成功", Library.Enums.ModalTypes.success, "/user/finance/Invest.aspx");//投资成功
                    //MessageBox.ShowAndRedirect(this.Page, "验证成功", );
                    return;
                }
                else
                {
                    MessageBox.ShowBox(this.Page, "验证失败", Library.Enums.ModalTypes.error);//投资成功
                    return;
                }
            }
            else
            {
                MessageBox.ShowBox(this.Page, message, Library.Enums.ModalTypes.warning);//
                return;
            }
            
        }

    }
}