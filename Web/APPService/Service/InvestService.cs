using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class InvestService :AllCore
    {
        public bool Invest(long userid, int num,string paypassword,out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                message = "用户ID不存在";
                return false;
            }

            if (user.SecondPassword != paypassword)
            {
                message = "支付密码错误";
                return false;
            }
            if (user.IsLock == 1)
            {
                message = "账户已冻结，购买失败";
                return false;
            }

            decimal price = getParamAmount("InvestPrice");
            decimal amount = price * num;
            if (user.Emoney < amount)
            {
                message =  "云盾余额不足";//云盾余额不足
                return false;
            }

            //string maxdate = GetInvestMaxDate(LoginUser.UserID);
            //if (!string.IsNullOrEmpty(maxdate))
            //{
            //    int InvestPrimaryInterval = getParamInt("InvestPrimaryInterval");
            //    if (DateTime.Now.Subtract(DateTime.Parse(maxdate)).TotalHours < InvestPrimaryInterval) //用投资积分投单每 3 天投一单)
            //    {
            //        MessageBox.ShowBox(this.Page, string.Format("用投资积分投单每{0}小时投一单", InvestPrimaryInterval), Library.Enums.ModalTypes.warning);//用投资积分投单每 3 天投一单
            //        return;
            //    }
            //}

            //decimal lastMaxAmount = GetInvestMaxAmount(LoginUser.UserID);
            //if (InvestPrimaryAmount < lastMaxAmount)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("MustLastMaxAmount"), Library.Enums.ModalTypes.warning);//额度要大于或者等于上次投资的额度。
            //    return;
            //}

            int flag = proc_BuyMachine(user.UserID, num);

            if (flag == 0)
            {
                message = "购买成功";
                return true;
            }
            else
            {
                message = "购买失败";
                return false;
            }
        }

        public object InvestList(long userid, int PageIndex, int PageSize, string FindKey)
        {
            lgk.BLL.tb_BuyMachine buyMachineBLL = new lgk.BLL.tb_BuyMachine();

            int PageCount;
            int TotalCount;

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = buyMachineBLL.GetListByPage(userid, PageIndex, PageSize, out PageCount, out TotalCount, FindKey);

            var list = FillBuyMachineList(ds.Tables[0]);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", list);

            return dic;


            //var list = buyMachineBLL.GetModelList("userid ="+userid);
            //return list.Select(s => new { s.Price,s.Num, s.Amount, s.BuyTime ,s.CalcPower }).OrderByDescending(s=>s.BuyTime).ToList();
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BuyMachineListModel> FillBuyMachineList(DataTable dt)
        {
            List<BuyMachineListModel> modelList = new List<BuyMachineListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BuyMachineListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BuyMachineListModel();
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = dt.Rows[n]["Price"].ToString();
                    }
                    if (dt.Rows[n]["Num"] != null && dt.Rows[n]["Num"].ToString() != "")
                    {
                        model.Num = dt.Rows[n]["Num"].ToString();
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = dt.Rows[n]["Amount"].ToString();
                    }

                    if (dt.Rows[n]["BuyTime"] != null && dt.Rows[n]["BuyTime"].ToString() != "")
                    {
                        model.BuyTime = dt.Rows[n]["BuyTime"].ToString();
                    }
                    if (dt.Rows[n]["CalcPower"] != null && dt.Rows[n]["CalcPower"].ToString() != "")
                    {
                        model.CalcPower = dt.Rows[n]["CalcPower"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        public decimal GetMachinePrice( )
        {
            decimal price = getParamAmount("InvestPrice"); ;
            return price;
        }


    }
}