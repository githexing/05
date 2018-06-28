using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashbuy
    /// </summary>
    public partial class Cashbuy
    {
        public Cashbuy()
		{ }
        #region Method

        public bool Exists(long CashbuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashbuy where CashbuyID = @CashbuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashbuyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.Cashbuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashbuy(");
            strSql.Append("UserID,Amount,Price,Number,BuyNum,BuyDate,IsBuy,Phone,OrderCode)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Amount,@Price,@Number,@BuyNum,@BuyDate,@IsBuy,@Phone,@OrderCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Number", SqlDbType.Int,4),
                    new SqlParameter("@BuyNum", SqlDbType.Int,4),
                    new SqlParameter("@BuyDate", SqlDbType.DateTime),
                    new SqlParameter("@IsBuy", SqlDbType.Int,4),
                    new SqlParameter("@Phone", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.BuyNum;
            parameters[5].Value = model.BuyDate;
            parameters[6].Value = model.IsBuy;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.OrderCode;

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
		public bool Update(lgk.Model.Cashbuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashbuy set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("Price=@Price,");
            strSql.Append("Number=@Number,");
            strSql.Append("BuyNum=@BuyNum,");
            strSql.Append("BuyDate=@BuyDate,");
            strSql.Append("IsBuy=@IsBuy,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("OrderCode=@OrderCode");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Number", SqlDbType.Int,4),
                    new SqlParameter("@BuyNum", SqlDbType.Int,4),
                    new SqlParameter("@BuyDate", SqlDbType.DateTime),
                    new SqlParameter("@IsBuy", SqlDbType.Int,4),
                    new SqlParameter("@Phone", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.BuyNum;
            parameters[5].Value = model.BuyDate;
            parameters[6].Value = model.IsBuy;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.OrderCode;
            parameters[9].Value = model.CashbuyID;

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
        public bool Delete(long CashbuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashbuy ");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashbuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashbuyID;

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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CashbuyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashbuy ");
            strSql.Append(" where ID in (" + CashbuyIDlist + ")  ");
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
		public lgk.Model.Cashbuy GetModel(long CashbuyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CashbuyID,UserID,Amount,Price,Number,BuyNum,BuyDate,IsBuy,Phone,OrderCode from Cashbuy ");
            strSql.Append(" where CashbuyID=@CashbuyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CashbuyID", SqlDbType.BigInt)
            };
            parameters[0].Value = CashbuyID;

            lgk.Model.Cashbuy model = new lgk.Model.Cashbuy();
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

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.Cashbuy DataRowToModel(DataRow row)
        {
            lgk.Model.Cashbuy model = new lgk.Model.Cashbuy();
            if (row != null)
            {
                if (row["CashbuyID"] != null && row["CashbuyID"].ToString() != "")
                {
                    model.CashbuyID = long.Parse(row["CashbuyID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["BuyNum"] != null && row["BuyNum"].ToString() != "")
                {
                    model.BuyNum = int.Parse(row["BuyNum"].ToString());
                }
                if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                }
                if (row["IsBuy"] != null && row["IsBuy"].ToString() != "")
                {
                    model.IsBuy = int.Parse(row["IsBuy"].ToString());
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashbuy GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CashbuyID, CashsellID, UserID, Amount, Price, Number, BuyNum, BuyDate, IsBuy,Phone");
            strSql.Append(" from Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.Cashbuy model = new lgk.Model.Cashbuy();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Cashbuy");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.*,u.UserCode ");
            strSql.Append(" FROM [Cashbuy] as b inner JOIN tb_user as u ON b.UserID=u.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表分页
        /// </summary>
        public DataSet GetInnerListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
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
            string proc = "proc_Page_TradingBuyList";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "buy");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        /// <summary>
        /// 获得数据列表（可排序）
        /// </summary>
        public DataSet GetInnerListOrderBy(int top, string strWhere, string strOrderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" b.*, (IsNull(b.Number,0)-IsNull(b.BuyNum,0)) as SurplusNum, u.UserCode ");
            strSql.Append(" FROM Cashbuy as b inner JOIN tb_user as u ON b.UserID=u.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (strOrderBy.Trim() != "")
            {
                strSql.Append(strOrderBy);
            }
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 买入
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BuyPrice"></param>
        /// <param name="BuyNum"></param>
        /// <returns></returns>
        public string TradingBuy(long UserID, decimal BuyPrice, int BuyNum)
        {
            object[] obj = DbHelperSQLP.ExecuteSP_Param_Object("proc_TradingBuy", UserID, BuyPrice, BuyNum, "");
            if (obj != null && obj[1] != null)
            {
                return obj[1].ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Cashbuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetJoinUserRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Cashbuy as b ");
            strSql.Append(" inner join tb_user as u on b.UserID=u.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CashbuyID desc");
            }
            strSql.Append(")AS Row, T.*  from ");
            strSql.Append("(select b.*,(b.Number-b.BuyNum) as SurplusNum,u.UserCode,u.TrueName ");
            strSql.Append("from Cashbuy as b inner join tb_user as u on b.UserID=u.UserID");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) T");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        #endregion
    }
}
