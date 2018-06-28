using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashorder
    /// </summary>
    public partial class Cashorder
    {
        public Cashorder()
		{ }
        #region Method

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashorder");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.BigInt)
            };
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashorder(");
            strSql.Append("CashbuyID,CashsellID,BUserID,SUserID,OrderCode,OrderDate,BStatus,BRemark,SStatus,SRemark,Status,TradingNum,SPrice)");
            strSql.Append(" values (");
            strSql.Append("@CashbuyID,@CashsellID,@BUserID,@SUserID,@OrderCode,@OrderDate,@BStatus,@BRemark,@SStatus,@SRemark,@Status,@TradingNum,@SPrice)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CashbuyID", SqlDbType.BigInt,8),
                    new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                    new SqlParameter("@BUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@BStatus", SqlDbType.Int,4),
                    new SqlParameter("@BRemark", SqlDbType.VarChar,500),
                    new SqlParameter("@SStatus", SqlDbType.Int,4),
                    new SqlParameter("@SRemark", SqlDbType.VarChar,500),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@TradingNum", SqlDbType.Int,4),
                    new SqlParameter("@SPrice", SqlDbType.Decimal,9)
            };
            parameters[0].Value = model.CashbuyID;
            parameters[1].Value = model.CashsellID;
            parameters[2].Value = model.BUserID;
            parameters[3].Value = model.SUserID;
            parameters[4].Value = model.OrderCode;
            parameters[5].Value = model.OrderDate;
            parameters[6].Value = model.BStatus;
            parameters[7].Value = model.BRemark;
            parameters[8].Value = model.SStatus;
            parameters[9].Value = model.SRemark;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.TradingNum;
            parameters[12].Value = model.SPrice;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.Cashorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashorder set ");
            strSql.Append("CashbuyID=@CashbuyID,");
            strSql.Append("CashsellID=@CashsellID,");
            strSql.Append("BUserID=@BUserID,");
            strSql.Append("SUserID=@SUserID,");
            strSql.Append("OrderCode=@OrderCode,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("BStatus=@BStatus,");
            strSql.Append("BRemark=@BRemark,");
            strSql.Append("SStatus=@SStatus,");
            strSql.Append("SRemark=@SRemark,");
            strSql.Append("Status=@Status,");
            strSql.Append("TradingNum=@TradingNum,");
            strSql.Append("SPrice=@SPrice");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CashbuyID", SqlDbType.BigInt,8),
                    new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                    new SqlParameter("@BUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@SUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@BStatus", SqlDbType.Int,4),
                    new SqlParameter("@BRemark", SqlDbType.VarChar,500),
                    new SqlParameter("@SStatus", SqlDbType.Int,4),
                    new SqlParameter("@SRemark", SqlDbType.VarChar,500),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@TradingNum", SqlDbType.Int,4),
                    new SqlParameter("@SPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@OrderID", SqlDbType.BigInt,8)
            };
            parameters[0].Value = model.CashbuyID;
            parameters[1].Value = model.CashsellID;
            parameters[2].Value = model.BUserID;
            parameters[3].Value = model.SUserID;
            parameters[4].Value = model.OrderCode;
            parameters[5].Value = model.OrderDate;
            parameters[6].Value = model.BStatus;
            parameters[7].Value = model.BRemark;
            parameters[8].Value = model.SStatus;
            parameters[9].Value = model.SRemark;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.TradingNum;
            parameters[12].Value = model.SPrice;
            parameters[13].Value = model.OrderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashorder ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.BigInt)
            };
            parameters[0].Value = OrderID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashorder ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashorder GetModel(long OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,CashbuyID,CashsellID,BUserID,SUserID,OrderCode,OrderDate,BStatus,BRemark,SStatus,SRemark,Status,TradingNum,SPrice from Cashorder ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.BigInt)
            };
            parameters[0].Value = OrderID;

            lgk.Model.Cashorder model = new lgk.Model.Cashorder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashorder DataRowToModel(DataRow row)
        {
            lgk.Model.Cashorder model = new lgk.Model.Cashorder();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(row["OrderID"].ToString());
                }
                if (row["CashbuyID"] != null && row["CashbuyID"].ToString() != "")
                {
                    model.CashbuyID = long.Parse(row["CashbuyID"].ToString());
                }
                if (row["CashsellID"] != null && row["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(row["CashsellID"].ToString());
                }
                if (row["BUserID"] != null && row["BUserID"].ToString() != "")
                {
                    model.BUserID = long.Parse(row["BUserID"].ToString());
                }
                if (row["SUserID"] != null && row["SUserID"].ToString() != "")
                {
                    model.SUserID = long.Parse(row["SUserID"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                }
                if (row["BStatus"] != null && row["BStatus"].ToString() != "")
                {
                    model.BStatus = int.Parse(row["BStatus"].ToString());
                }
                if (row["BRemark"] != null)
                {
                    model.BRemark = row["BRemark"].ToString();
                }
                if (row["SStatus"] != null && row["SStatus"].ToString() != "")
                {
                    model.SStatus = int.Parse(row["SStatus"].ToString());
                }
                if (row["SRemark"] != null)
                {
                    model.SRemark = row["SRemark"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["TradingNum"] != null && row["TradingNum"].ToString() != "")
                {
                    model.TradingNum = int.Parse(row["TradingNum"].ToString());
                }
                if (row["SPrice"] != null && row["SPrice"].ToString() != "")
                {
                    model.SPrice = int.Parse(row["SPrice"].ToString());
                }
            }
            return model;
        } 
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderID,CashbuyID,CashsellID,BUserID,SUserID,OrderCode,OrderDate,BStatus,BRemark,SStatus,SRemark,Status,TradingNum,SPrice  FROM Cashorder");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Cashorder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(int top,string strWhere,string strOrderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top "+top.ToString());
            }
            strSql.Append(" o.OrderID, o.OrderCode, o.TradingNum, o.CashbuyID, o.CashsellID, o.OrderDate, o.SPrice as Price, o.TradingNum*o.SPrice as Amount,");
            strSql.Append(" b.OrderCode as BuyOrderCode, s.OrderCode as SellOrderCode, bu.UserCode as BuyUserCode, su.UserCode as SellUserCode ");
            strSql.Append(" from Cashorder as o inner join Cashbuy as b on o.CashbuyID=b.CashbuyID  ");
            strSql.Append(" inner join Cashsell as s on o.CashsellID=s.CashsellID  ");
            strSql.Append(" inner join tb_user as bu on o.BUserID=bu.UserID  ");
            strSql.Append(" inner join tb_user as su on o.SUserID=su.UserID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if(strOrderBy.Trim()!= "")
            {
                strSql.Append(strOrderBy);
            }
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderListByPage(long UserID, long OrderID, int TypeID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string fromwhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@OrderID", SqlDbType.BigInt),
                    new SqlParameter("@TypeID", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FromWhere", SqlDbType.VarChar, 50)
            };
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = OrderID;
            parameters[2].Value = TypeID;
            parameters[3].Value = PageIndex;
            parameters[4].Value = PageSize;
            parameters[7].Value = fromwhere;
            string proc = "proc_Page_TradingOrder";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "order");

            PageCount = int.Parse(parameters[5].Value.ToString());
            TotalCount = int.Parse(parameters[6].Value.ToString());

            return ds;
        }

        /// <summary>
        /// 获取最新交易价格（以卖出方为准）
        /// </summary>
        /// <returns></returns>
        public decimal GetLatestPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 s.Price FROM Cashorder as o inner join Cashsell as s on o.CashSellID=s.CashSellID ");
            strSql.Append(" order by o.OrderDate desc ");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if(obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取 买入/卖出 联合数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetBuyAndSellList(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CashbuyID as OrderID,OrderCode,Number,Price,(Number-BuyNum) as SurplusNum,TypeID=1,BuyDate as OrderDate,IsBuy as [Status] ");
            strSql.Append(" from Cashbuy where UserID="+ UserID);
            strSql.Append(" union ");
            strSql.Append(" select CashSellID as OrderID,OrderCode,Number,Price,(Number-SaleNum) as SurplusNum,TypeID=2,SellDate as OrderDate,IsSell as [Status] ");
            strSql.Append(" from Cashsell where UserID=" + UserID);
            strSql.Append(" order by OrderDate desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取 买入/卖出 联合数据（分页）
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet GetBuyAndSellListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;

            string proc = "proc_Page_TradingBuyAndSell";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "buyandsell");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        #endregion
    }
}
