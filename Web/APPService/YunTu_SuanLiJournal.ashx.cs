using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace Web.APPService
{
    /// <summary>
    /// YuTu_Recommend 的摘要说明
    /// </summary>
    public class YunTu_SuanLiJournal : IHttpHandler
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
            string message = "暂无数据";
            string dates = "";
            string User = context.Request["UserID"];
            string Page_1 = context.Request["Page"];
            string Mumber_1 = context.Request["Mumber"];
            int Page = 0;
            int Mumber = 0;
            long UserID = 0;
            if (string.IsNullOrEmpty(User) || User.Trim() == string.Empty)
            {
                message = "账号不存在";
                SendResponse(context, result, message, dates);
                return;
            }
            try
            {
                UserID = long.Parse(User);

            }
            catch (Exception)
            {
                UserID = 0;
            }
            try
            {
                Page = int.Parse(Page_1);
                Mumber = int.Parse(Mumber_1);
            }
            catch (Exception)
            {
                message = "页码错误！";
                SendResponse(context, result, message, dates);
            }
            if (Page == 0)
            {
                Page = 1;
            }
            int Start = (Page - 1) * Mumber;
            int YM = Page * Mumber;

            AllCore AC = new AllCore();
            var model = AC.userBLL.GetModel(UserID);//-查询是否有这个人。
            if (model == null)
            {
                message = "账号不存在";
                SendResponse(context, result, message, dates);
                return;
            }
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("  select * from tb_SuanliJournal where userid= " + UserID + " order by ID desc ;");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dates += "\"NotesList\":[";
            decimal dd = dt.Rows.Count / Mumber;
            int yu = dt.Rows.Count % Mumber;
            int GG = 0;
            if (YM > dt.Rows.Count)//最后一页处理
            {
                if (YM - dt.Rows.Count > Mumber)
                {
                    GG = 1;
                }
                Page = (int)Math.Floor(dd);
                Start = Mumber * Page;
                Mumber = yu;
            }
            if (yu > 0)
            {
                dd += 1;
            }
            if (dt.Rows.Count > 0)
            {
                if (GG == 1)
                {
                    Mumber = 0;
                }
                for (int i = Start; i < Start + Mumber; i++)
                {
                    if (Mumber == 1)
                    {
                        string a = dt.Rows[i]["ReduceAmount"].ToString() == "0" ? "{\"SuanLi\":\"+" + dt.Rows[i]["AddAmount"].ToString() : "{\"SuanLi\":\"-" + dt.Rows[i]["ReduceAmount"].ToString();
                        string b= "";
                        if (dt.Rows[i]["AddAmount"].ToString() == "0")
                        {
                            b = dt.Rows[i]["MoneyType"].ToString() == "0" ? "生长云图" : "";
                        }
                        else
                        {
                            b += GetMoneyTypeName(dt.Rows[i]["MoneyType"].ToString());
                        }

                        dates += a + "\",\"Total\":\"" + dt.Rows[i]["SurplusAmount"].ToString() + "\",\"Suanli_Type\":\"" + b + "\",\"Remark\":\"" + dt.Rows[i]["Remark"].ToString() + "\",\"Time\":\"" + dt.Rows[i]["JoinTime"].ToString() + "\"}";
                        continue;
                    }
                    if (i == Start + Mumber - 1)
                    {
                        string a = dt.Rows[i]["ReduceAmount"].ToString() == "0" ? "{\"SuanLi\":\"+" + dt.Rows[i]["AddAmount"].ToString() : "{\"SuanLi\":\"-" + dt.Rows[i]["ReduceAmount"].ToString();

                        string b = "";
                        if (dt.Rows[i]["AddAmount"].ToString() == "0")
                        {
                            b = dt.Rows[i]["MoneyType"].ToString() == "0" ? "生长云图" : "";
                        }
                        else
                        {
                            b += GetMoneyTypeName(dt.Rows[i]["MoneyType"].ToString());
                        }
                        dates += a+ "\",\"Total\":\"" + dt.Rows[i]["SurplusAmount"].ToString() + "\",\"Suanli_Type\":\"" + b + "\",\"Remark\":\"" + dt.Rows[i]["Remark"].ToString() + "\",\"Time\":\"" + dt.Rows[i]["JoinTime"].ToString() + "\"}";
                        continue;
                    }
                    if (Mumber > 1)
                    { 
                        string a = dt.Rows[i]["ReduceAmount"].ToString() == "0" ? "{\"SuanLi\":\"+" + dt.Rows[i]["AddAmount"].ToString() : "{\"SuanLi\":\"-" + dt.Rows[i]["ReduceAmount"].ToString();
                        string b = "";
                        if (dt.Rows[i]["AddAmount"].ToString() == "0")
                        {
                            b = dt.Rows[i]["MoneyType"].ToString() == "0" ? "生长云图" : "";
                        }
                        else
                        {
                            b += GetMoneyTypeName(dt.Rows[i]["MoneyType"].ToString());
                        }
                        dates += a + "\",\"Total\":\"" + dt.Rows[i]["SurplusAmount"].ToString() + "\",\"Suanli_Type\":\"" + b + "\",\"Remark\":\"" + dt.Rows[i]["Remark"].ToString() + "\",\"Time\":\"" + dt.Rows[i]["JoinTime"].ToString() + "\"},";

                    }
                }
                result = "success";
                message = "查询成功";
            }
            dates += "]";
            dates += ",\"CountPage\":" + dd + "";
            SendResponse(context, result, message, dates);
        }

        /// <summary>
        /// 获取算力方式
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string GetMoneyTypeName(string strType)
        {
            string strName = "";
            if(strType == "0")
            {
                strName = "购买矿机";
            }
            else if (strType == "1")
            {
                strName = "推荐获得";
            }
            else if (strType == "2")
            {
                strName = "签到";
            }
            else if (strType == "3")
            {
                strName = "注册赠送";
            }
            return strName;
        }

        private void SendResponse(HttpContext context, string result, string returnString, string dates)
        {
            context.Response.Clear();
            string json = "{\"state\":\"" + result.ToString() + "\",\"message\":\"" + returnString + "\",\"data\":{" + dates + "}}";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.Serialize(json);
            context.Response.Write(json);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}