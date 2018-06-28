/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-16 11:51:31 
 * 文 件 名：		index.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user
{
    public partial class index : PageCore
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //DataInit();
            
            btnSubmit.Text = GetLanguage("Submit");
            btnActive.Text = GetLanguage("ActiveUser");
            btnActive.Visible = LoginUser.IsOpend == 0;

            
            if (!IsPostBack)
            {
                BindData();
                BindData_Rank();
                string culture;
                if (HttpContext.Current.Request.Cookies["Culture"] != null)
                {
                    culture = HttpContext.Current.Request.Cookies["Culture"].Value;
                    if (culture == "zh-cn")
                    {
                        LangType.SelectedIndex = 0;
                    }
                    else
                    {
                        LangType.SelectedIndex = 1;
                    }
                }
            }
        }
        //private void DataInit()
        //{
        //    string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
        //    strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
        //    rem_url = strNewUrl + "user/LinkRegist.aspx?i=" + LoginUser.UserID;
        //}

        //public string rem_url = "";

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            if (Language == "zh-cn")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=0", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }
            else if (Language == "en-us")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=1", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }

        }
        protected void BindData_Rank()
        {
            if (Language == "zh-cn")
            {
                bind_repeater(newsBLL.GetList_Rank(60, "", ""), Repeater2, "RankID asc", tr2, AspNetPager1);
           
            }
            else if (Language == "en-us")
            {
                bind_repeater(newsBLL.GetList_Rank(60, "", ""), Repeater2, "RankID asc", tr2, AspNetPager1);
            }

        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData_Rank();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie Culture;

            if (HttpContext.Current.Request.Cookies["Culture"] == null)
                Culture = new HttpCookie("Culture");
            else
                Culture = HttpContext.Current.Request.Cookies["Culture"];

            if (LangType.Value != "2")
            {
                Culture.Value = "zh-cn";//中文
            }
            else
            {
                Culture.Value = "en-us";//英文

            }
           
            Response.AppendCookie(Culture);
            Response.Redirect("index.aspx");
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            decimal regopen = getParamAmount("RegOpen");
            if (LoginUser.Emoney < regopen)
            {
                MessageBox.ShowAndRedirect(this.Page, GetLanguage("RegOpenMust"), "index.aspx");//云盾不足
                return ;
            }

            int flag = flag_ActivationUser(LoginUser.UserID, LoginUser.UserID);
            if (flag != 0)
            {
                if (flag == -1)
                {
                    MessageBox.ShowAndRedirect(this.Page, GetLanguage("ActivationUserFail"), "index.aspx");//激活会员失败
                }
                else
                {
                    MessageBox.ShowAndRedirect(this.Page, GetLanguage("RegOpenMust"), "index.aspx");//云盾不足
                }
                return;
            }
            else
                MessageBox.ShowAndRedirect(this.Page, GetLanguage("Congratulations"), "index.aspx");//恭喜您激活成功
        }

    }
}