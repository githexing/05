using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class TradingService : AllCore
    {
        public bool ExistsByUserID(long userid)
        {
            return userBLL.Exists(userid);
        }

        public int pagesize = 5;

        #region 交易大厅买卖记录
        /// <summary>
        /// 交易大厅买卖记录
        /// </summary>
        /// <returns></returns>
        public TradingHallModel TradingHall(int top, long userid, out bool flag, out string message)
        {
            TradingHallModel model = new TradingHallModel();
            var usermodel = userBLL.GetModel(userid);
            if (usermodel == null)
            {
                flag = false;
                message = "用户ID不存在";
            }
            else
            {
                string strSellWhere = " s.IsSell=0 and s.IsUndo=0 ";
                string strBuyWhere = " b.IsBuy=0 ";

                var sd = cashsellBLL.GetInnerListOrderBy(pagesize, strSellWhere, " order by s.Price desc ");
                var bd = cashbuyBLL.GetInnerListOrderBy(pagesize, strBuyWhere, " order by b.Price asc ");
                model.SellList = DataTableHallToList(sd.Tables[0], 2);
                model.BuyList = DataTableHallToList(bd.Tables[0], 1);
                model.LatestPrice = cashorderBLL.GetLatestPrice();//最新的交易价格
                model.YT = usermodel.BonusAccount;//云图
                model.YD = usermodel.Emoney;//云盾
                flag = true;
                message = "";
            }
            return model;
        }
        #endregion

        #region 买入/卖出 列表
        public List<TradingBuyAndSellModel> TradingBuyAndSellList(long userid, int pageindex, int pagesize, out int pagecount, out int totalcount, out bool flag, out string message)
        {
            List<TradingBuyAndSellModel> list = new List<TradingBuyAndSellModel>();
            var usermodel = userBLL.GetModel(userid);
            if (usermodel == null)
            {
                flag = false;
                message = "用户ID不存在";
                pagecount = 0;
                totalcount = 0;
            }
            else
            {
                var dt = cashorderBLL.GetBuyAndSellListByPage(userid, pageindex, pagesize, out pagecount, out totalcount);

                list = BuyAndSellTableToOrderList(dt.Tables[0]);
                flag = true;
                message = "";
            }
            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TradingBuyAndSellModel> BuyAndSellTableToOrderList(DataTable dt)
        {
            List<TradingBuyAndSellModel> modelList = new List<TradingBuyAndSellModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TradingBuyAndSellModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TradingBuyAndSellModel();

                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt64(dt.Rows[n]["OrderID"]);
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Number = Convert.ToInt32(dt.Rows[n]["Number"]);
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                    }
                    if (dt.Rows[n]["SurplusNum"] != null && dt.Rows[n]["SurplusNum"].ToString() != "")
                    {
                        model.SurplusNum = Convert.ToInt32(dt.Rows[n]["SurplusNum"]);
                    }
                    if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = Convert.ToInt32(dt.Rows[n]["TypeID"]);
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = Convert.ToInt32(dt.Rows[n]["Status"]);
                        model.StatusText = GetSellStatus(model.Status);
                    }
                    if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = Convert.ToDateTime(dt.Rows[n]["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

        #region 交易大厅获取数据
        /// <summary>
        /// 交易大厅获取数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<NowHallData> DataTableHallToList(DataTable dt, int typeid)
        {
            List<NowHallData> modelList = new List<NowHallData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NowHallData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NowHallData();
                    if (typeid == 1)
                    {
                        model.UserCode = GetLanguage("Buyers") + (n + 1);//买家
                    }
                    else
                    {
                        model.UserCode = GetLanguage("Seller") + (n + 1);//卖
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = dt.Rows[n]["Price"].ToString();
                    }
                    if (dt.Rows[n]["SurplusNum"] != null && dt.Rows[n]["SurplusNum"].ToString() != "")
                    {
                        model.SurplusNum = dt.Rows[n]["SurplusNum"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 获取数据对象
        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public CashOrderModel OrderTableToModel(DataTable dt)
        {
            int n = 0;
            CashOrderModel model = new CashOrderModel();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                {
                    model.OrderID = Convert.ToInt64(dt.Rows[n]["OrderID"]);
                }
                if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                }
                if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                {
                    model.UserCode = dt.Rows[n]["UserCode"].ToString();
                }
                if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                {
                    model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                }
                if (dt.Rows[n]["TradingNum"] != null && dt.Rows[n]["TradingNum"].ToString() != "")
                {
                    model.Number = Convert.ToInt32(dt.Rows[n]["TradingNum"]);
                }
                if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                {
                    model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                }
                if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                {
                    model.TypeID = Convert.ToInt32(dt.Rows[n]["TypeID"]);
                    model.TypeIDName = GetOrderTypeName(model.TypeID);
                }
                if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = Convert.ToDateTime(dt.Rows[n]["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CashOrderModel> DataTableToOrderList(DataTable dt)
        {
            List<CashOrderModel> modelList = new List<CashOrderModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CashOrderModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CashOrderModel();

                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt64(dt.Rows[n]["OrderID"]);
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["TradingNum"] != null && dt.Rows[n]["TradingNum"].ToString() != "")
                    {
                        model.Number = Convert.ToInt32(dt.Rows[n]["TradingNum"]);
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                    }
                    if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = Convert.ToInt32(dt.Rows[n]["TypeID"]);
                        model.TypeIDName = GetOrderTypeName(model.TypeID);
                    }
                    if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = Convert.ToDateTime(dt.Rows[n]["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 卖出模块

        #region 挂卖
        /// <summary>
        /// 挂卖
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Price"></param>
        /// <param name="BuyNum"></param>
        /// <param name="PayPwd"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TradingHallModel Sell(long UserID, decimal Price, int Number, string PayPwd, out bool flag, out string message)
        {
            TradingHallModel model = new TradingHallModel();
            var usermodel = userBLL.GetModel(UserID);
            if (usermodel == null)
            {
                message = "该账号不存在";
                flag = false;
            }
            else if (usermodel.SecondPassword != PayPwd)
            {
                message = "支付密码错误";
                flag = false;
            }
            else if (usermodel.IsOpend == 0)
            {
                message = GetLanguage("AccountNoActiveInfo");//您的帐号未激活
                flag = false;
            }
            else if (usermodel.IsLock == 1)
            {
                message = "账户已冻结，挂卖失败";
                flag = false;
            }
            else if (getParamInt("Gold") == 0)
            {
                message = GetLanguage("Feature");//该功能未开放
                flag = false;
            }
            else
            {
                string remsg = cashsellBLL.TradingSell(UserID, Price, Number);
                if (remsg == "ok")
                {
                    flag = true;
                    message = "卖出成功";

                    string strSellWhere = " s.IsSell=0 and s.IsUndo=0 ";
                    string strBuyWhere = " b.IsBuy=0 ";
                    var sd = cashsellBLL.GetInnerListOrderBy(pagesize, strSellWhere, " order by s.Price desc ");
                    var bd = cashbuyBLL.GetInnerListOrderBy(pagesize, strBuyWhere, " order by b.Price asc ");
                    model.SellList = DataTableHallToList(sd.Tables[0], 2);
                    model.BuyList = DataTableHallToList(bd.Tables[0], 1);
                    model.LatestPrice = cashorderBLL.GetLatestPrice();//最新的交易价格
                    model.YT = userBLL.GetMoney(usermodel.UserID, "BonusAccount");//云图
                    model.YD = userBLL.GetMoney(usermodel.UserID, "Emoney");//云盾
                }
                else if (!string.IsNullOrEmpty(remsg))
                {
                    flag = false;
                    message = remsg;
                }
                else
                {
                    flag = false;
                    message = "买入失败";
                }
            }
            return model;
        }
        #endregion

        #region 卖出订单状态
        //卖出订单状态
        private string GetSellStatus(int Status)
        {
            if (Status == -1)
            {
                return "已撤消";
            }
            else if (Status == 1)
            {
                return "已完成";
            }
            else
            {
                return "挂单中";//0
            }
        }
        #endregion

        #region 卖出记录
        //卖出记录列表
        public List<CashSellInfoModel> SellList(long userid, int pageindex, int pagesize, out int pagecount, out int totalcount)
        {
            string strWhere = "s.UserID=" + userid;
            var dt = cashsellBLL.GetInnerListByPage(userid, pageindex, pagesize, out pagecount, out totalcount);
            return SellTableToList(dt.Tables[0]);
        }

        #endregion

        #region 获得卖出数据对象
        /// <summary>
        /// 获得卖出数据对象
        /// </summary>
        public CashSellInfoModel SellTableToModel(DataTable dt)
        {
            int n = 0;
            CashSellInfoModel model = new CashSellInfoModel();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[n]["CashsellID"] != null && dt.Rows[n]["CashsellID"].ToString() != "")
                {
                    model.OrderID = Convert.ToInt64(dt.Rows[n]["CashsellID"]);
                }
                if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                }
                if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                {
                    model.UserCode = dt.Rows[n]["UserCode"].ToString();
                }
                if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                {
                    model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                }
                if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                {
                    model.Number = Convert.ToInt32(dt.Rows[n]["Number"]);
                }
                if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                {
                    model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                }
                if (dt.Rows[n]["BuyNum"] != null && dt.Rows[n]["BuyNum"].ToString() != "")
                {
                    model.SaleNum = Convert.ToInt32(dt.Rows[n]["BuyNum"]);
                }
                if (dt.Rows[n]["SellDate"] != null && dt.Rows[n]["SellDate"].ToString() != "")
                {
                    model.SellDate = Convert.ToDateTime(dt.Rows[n]["SellDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                model.SurplusNum = model.Number - model.SaleNum;
                if (dt.Rows[n]["IsSell"] != null && dt.Rows[n]["IsSell"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(dt.Rows[n]["IsSell"]);
                    model.StatusText = GetSellStatus(model.Status);//Enum.GetName(typeof(Library.Enums.CashSellStatusTypes), int.Parse(model.Status));
                }
            }
            return model;
        }
        #endregion

        #region 获得卖出数据列表
        /// <summary>
        /// 获得卖出数据列表
        /// </summary>
        public List<CashSellInfoModel> SellTableToList(DataTable dt)
        {
            List<CashSellInfoModel> modelList = new List<CashSellInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CashSellInfoModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CashSellInfoModel();
                    if (dt.Rows[n]["CashsellID"] != null && dt.Rows[n]["CashsellID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt64(dt.Rows[n]["CashsellID"]);
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                    }
                    if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Number = Convert.ToInt32(dt.Rows[n]["Number"]);
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                    }
                    if (dt.Rows[n]["SaleNum"] != null && dt.Rows[n]["SaleNum"].ToString() != "")
                    {
                        model.SaleNum = Convert.ToInt32(dt.Rows[n]["SaleNum"]);
                    }
                    model.SurplusNum = model.Number - model.SaleNum;
                    if (dt.Rows[n]["SellDate"] != null && dt.Rows[n]["SellDate"].ToString() != "")
                    {
                        model.SellDate = Convert.ToDateTime(dt.Rows[n]["SellDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    if (dt.Rows[n]["IsSell"] != null && dt.Rows[n]["IsSell"].ToString() != "")
                    {
                        model.StatusText = GetSellStatus(int.Parse(dt.Rows[n]["IsSell"].ToString()));
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 撤销挂卖订单
        //撤销挂卖订单
        public bool SellCancel(long userid, long orderid, out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，撤销挂卖订单失败";
                return false;
            }
            var cashsellinfo = cashsellBLL.GetModel(orderid);

            if (cashsellinfo == null)
            {
                message = "订单不存在";
                return false;
            }
            if (cashsellinfo.IsSell == -1)
            {
                message = "订单已撤销，请勿重复操作";
                return false;
            }
            else if (cashsellinfo.IsSell == 1)
            {
                message = "订单已完成，无法撤销";
                return false;
            }
            else if (cashsellinfo.IsSell == 0)
            {
                int SurplusNum = cashsellinfo.Number - cashsellinfo.SaleNum;
                string strRemark = "卖家已撤销订单[" + cashsellinfo.OrderCode + "]的挂卖，返还剩余云图[" + SurplusNum + "]";
                //修改订单状态
                cashsellinfo.IsUndo = 1;
                cashsellinfo.IsSell = -1;
                cashsellBLL.Update(cashsellinfo);

                int iJtype = (int)Library.AccountType.云图;//币种
                UpdateAccount("BonusAccount", userid, SurplusNum, iJtype);//终止交易，将云图返还卖家
                SetAccount(userid, Convert.ToDecimal(SurplusNum * 1.00), strRemark, userid, iJtype);//插入流水

                lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                log.LogMsg = strRemark;
                log.LogType = 24;//
                log.LogLeve = 0;//
                log.LogDate = DateTime.Now;
                log.LogCode = "卖家已撤销订单";//
                log.IsDeleted = 0;
                log.Log1 = cashsellinfo.CashsellID.ToString();//用户UserID
                log.Log2 = "";// BrowserHelper.UserHostIP(this.Page);
                log.Log3 = "";//BrowserHelper.UserHostName();
                log.Log4 = "";
                syslogBLL.Add(log);

                message = "撤销成功！";
                return true;
            }

            message = "该订单不能撤销";
            return false;
        }
        #endregion

        #endregion

        #region 买入模块

        #region 买入
        /// <summary>
        /// 买入
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Price"></param>
        /// <param name="Number"></param>
        /// <param name="paypassword"></param>
        /// <param name="orderid"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TradingHallModel Buy(long UserID, decimal Price, int Number, string paypassword, out bool flag, out string message)
        {
            TradingHallModel model = new TradingHallModel();
            var usermodel = userBLL.GetModel(UserID);
            if (usermodel == null)
            {
                message = "该账号不存在";
                flag = false;
            }
            else if (usermodel.SecondPassword != paypassword)
            {
                message = "支付密码错误";
                flag = false;
            }
            else if (usermodel.IsOpend == 0)
            {
                message = GetLanguage("AccountNoActiveInfo");//您的帐号未激活
                flag = false;
            }
            else if (usermodel.IsLock == 1)
            {
                message = "账户已冻结，买入失败";
                flag = false;
            }
            else if (getParamInt("Gold") == 0)
            {
                message = GetLanguage("Feature");//该功能未开放
                flag = false;
            }
            else
            {
                string remsg = cashbuyBLL.TradingBuy(UserID, Price, Number);
                if (remsg == "ok")
                {
                    flag = true;
                    message = "买入成功";

                    string strSellWhere = " s.IsSell=0 and s.IsUndo=0 ";
                    string strBuyWhere = " b.IsBuy=0 ";
                    var sd = cashsellBLL.GetInnerListOrderBy(pagesize, strSellWhere, " order by s.Price desc ");
                    var bd = cashbuyBLL.GetInnerListOrderBy(pagesize, strBuyWhere, " order by b.Price asc ");
                    model.SellList = DataTableHallToList(sd.Tables[0], 2);
                    model.BuyList = DataTableHallToList(bd.Tables[0], 1);
                    model.LatestPrice = cashorderBLL.GetLatestPrice();//最新的交易价格
                    model.YT = userBLL.GetMoney(usermodel.UserID, "BonusAccount");//云图
                    model.YD = userBLL.GetMoney(usermodel.UserID, "Emoney");//云盾
                }
                else if (!string.IsNullOrEmpty(remsg))
                {
                    flag = false;
                    message = remsg;
                }
                else
                {
                    flag = false;
                    message = "买入失败";
                }
            }
            return model;
        }
        #endregion

        #region 买入订单状态
        //卖出订单状态
        private string GetBuyStatus(int Status)
        {
            if (Status == -1)
            {
                return "已撤消";
            }
            else if (Status == 1)
            {
                return "已完成";
            }
            else
            {
                return "挂买中";//0
            }
        }
        #endregion

        #region 买入记录
        //卖出记录列表
        public List<CashBuyInfoModel> BuyList(long userid, int pageindex, int pagesize, out int pagecount, out int totalcount)
        {
            var dt = cashbuyBLL.GetInnerListByPage(userid, pageindex, pagesize, out pagecount, out totalcount);
            return BuyTableToList(dt.Tables[0]);
        }

        #endregion

        #region 获得买入数据对象
        /// <summary>
        /// 获得买入数据对象
        /// </summary>
        public CashBuyInfoModel BuyTableToModel(DataTable dt)
        {
            int n = 0;
            CashBuyInfoModel model = new CashBuyInfoModel();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[n]["CashbuyID"] != null && dt.Rows[n]["CashbuyID"].ToString() != "")
                {
                    model.OrderID = Convert.ToInt64(dt.Rows[n]["CashbuyID"]);
                }
                if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                {
                    model.UserCode = dt.Rows[n]["UserCode"].ToString();
                }
                if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                }
                if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                {
                    model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                }
                if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                {
                    model.Number = Convert.ToInt32(dt.Rows[n]["Number"]);
                }
                if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                {
                    model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                }
                if (dt.Rows[n]["BuyNum"] != null && dt.Rows[n]["BuyNum"].ToString() != "")
                {
                    model.BuyNum = Convert.ToInt32(dt.Rows[n]["BuyNum"]);
                }
                model.SurplusNum = model.Number - model.BuyNum;
                if (dt.Rows[n]["BuyDate"] != null && dt.Rows[n]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = Convert.ToDateTime(dt.Rows[n]["BuyDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (dt.Rows[n]["IsBuy"] != null && dt.Rows[n]["IsBuy"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(dt.Rows[n]["IsBuy"]);
                    model.StatusText = GetBuyStatus(model.Status);
                }
            }
            return model;
        }
        #endregion

        #region 获得买入数据列表
        /// <summary>
        /// 获得买入数据列表
        /// </summary>
        public List<CashBuyInfoModel> BuyTableToList(DataTable dt)
        {
            List<CashBuyInfoModel> modelList = new List<CashBuyInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CashBuyInfoModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CashBuyInfoModel();
                    if (dt.Rows[n]["CashbuyID"] != null && dt.Rows[n]["CashbuyID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt64(dt.Rows[n]["CashbuyID"]);
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = Convert.ToDecimal(dt.Rows[n]["Price"]);
                    }
                    if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Number = Convert.ToInt32(dt.Rows[n]["Number"]);
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = Convert.ToDecimal(dt.Rows[n]["Amount"]);
                    }
                    if (dt.Rows[n]["BuyNum"] != null && dt.Rows[n]["BuyNum"].ToString() != "")
                    {
                        model.BuyNum = Convert.ToInt32(dt.Rows[n]["BuyNum"]);
                    }
                    model.SurplusNum = model.Number - model.BuyNum;
                    if (dt.Rows[n]["BuyDate"] != null && dt.Rows[n]["BuyDate"].ToString() != "")
                    {
                        model.BuyDate = Convert.ToDateTime(dt.Rows[n]["BuyDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    if (dt.Rows[n]["IsBuy"] != null && dt.Rows[n]["IsBuy"].ToString() != "")
                    {
                        model.Status = Convert.ToInt32(dt.Rows[n]["IsBuy"]);
                        model.StatusText = GetBuyStatus(model.Status);
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 撤销买入订单
        //撤销买入订单
        public bool BuyCancel(long userid, long orderid, out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                message = "账户不存在";
                return false;
            }
            if (user.IsLock == 1)
            {
                message = "账户已冻结，撤销买入订单失败";
                return false;
            }

            lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(orderid);
            if (cashbuyInfo == null)
            {
                message = "订单不存在";
                return false;
            }
            if (cashbuyInfo.IsBuy == -1)
            {
                message = "订单已撤销，请勿重复操作";
                return false;
            }
            else if (cashbuyInfo.IsBuy == 1)
            {
                message = "订单已完成，无法撤销";
                return false;
            }
            else
            {
                int SurplusNum = cashbuyInfo.Number - cashbuyInfo.BuyNum;
                decimal iAmount = SurplusNum * cashbuyInfo.Price;
                string strRemark = "买家已撤销订单[" + cashbuyInfo.OrderCode + "]的买入，返还剩余云盾[" + iAmount + "]";

                //修改买入订单记录
                cashbuyInfo.IsBuy = -1;//买家已取消
                cashbuyBLL.Update(cashbuyInfo);

                int iJtype = (int)Library.AccountType.云盾;//币种
                UpdateAccount("BonusAccount", userid, iAmount, iJtype);//终止交易，将剩余花费的云盾返还买家
                SetAccount(userid, iAmount, strRemark, userid, iJtype);//插入流水

                lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                log.LogMsg = "买家撤销订单【" + cashbuyInfo.OrderCode + "】";
                log.LogType = 23;//
                log.LogLeve = 0;//
                log.LogDate = DateTime.Now;
                log.LogCode = "买家撤销订单";//
                log.IsDeleted = 0;
                log.Log1 = cashbuyInfo.CashbuyID.ToString();//用户UserID
                log.Log2 = ""; // BrowserHelper.UserHostIP(this.Page);
                log.Log3 = ""; //BrowserHelper.UserHostName();
                log.Log4 = "";
                syslogBLL.Add(log);

                message = "买家撤销成功";
                return true;
            }
        }
        #endregion

        #endregion

        #region 交易订单类别
        //卖出订单状态
        private string GetOrderTypeName(int TypeID)
        {
            if (TypeID == 1)
            {
                return "买入";
            }
            else
            {
                return "卖出";
            }
        }
        #endregion

        #region 交易记录
        /// <summary>
        /// 交易记录详情
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public List<CashOrderModel> TradeOrderList(long userid, long orderid, int typeid, int pageindex, int pagesize, out int pagecount, out int totalcount, string fromwhere)
        {
            var dt = cashorderBLL.GetOrderListByPage(userid, orderid, typeid, pageindex, pagesize, out pagecount, out totalcount, fromwhere);

            return DataTableToOrderList(dt.Tables[0]);
        }
        #endregion

        #region 交易记录详情
        /// <summary>
        /// 交易记录详情
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public CashOrderModel TradeOrderDetails(long orderid)
        {
            string strWhere = " o.OrderID =" + orderid;
            var dt = cashorderBLL.GetOrderList(20, strWhere, "");
            //decimal price = getParamAmount("Exchange");
            return DataTableToOrderList(dt.Tables[0]).FirstOrDefault();
        }
        #endregion

        #region 加入流水账表
        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, long iFromUserID, int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;//"EP币发货";
            journalInfo.RemarkEn = "Gold coin receipt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.Emoney;//EP币收货！
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iFromUserID;
            journalBLL.Add(journalInfo);
            #endregion
        }
        #endregion

    }
}