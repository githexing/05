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
    public partial class Cashsell
    {
        public Cashsell()
		{ }
        #region Method

        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CashsellID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashsell");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CashsellID", SqlDbType.BigInt)
            };
            parameters[0].Value = CashsellID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashsell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashsell(");
            strSql.Append("UserID,Amount,Price,Number,UnitNum,SaleNum,Charge,SellDate,Remark,IsSell,IsUndo,PurchaseID,Phone,OrderCode)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Amount,@Price,@Number,@UnitNum,@SaleNum,@Charge,@SellDate,@Remark,@IsSell,@IsUndo,@PurchaseID,@Phone,@OrderCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Number", SqlDbType.Int,4),
                    new SqlParameter("@UnitNum", SqlDbType.Int,4),
                    new SqlParameter("@SaleNum", SqlDbType.Int,4),
                    new SqlParameter("@Charge", SqlDbType.Decimal,9),
                    new SqlParameter("@SellDate", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@IsSell", SqlDbType.Int,4),
                    new SqlParameter("@IsUndo", SqlDbType.Int,4),
                    new SqlParameter("@PurchaseID", SqlDbType.BigInt,8),
                    new SqlParameter("@Phone", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.UnitNum;
            parameters[5].Value = model.SaleNum;
            parameters[6].Value = model.Charge;
            parameters[7].Value = model.SellDate;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.IsSell;
            parameters[10].Value = model.IsUndo;
            parameters[11].Value = model.PurchaseID;
            parameters[12].Value = model.Phone;
            parameters[13].Value = model.OrderCode;

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
        public bool Update(lgk.Model.Cashsell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashsell set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("Price=@Price,");
            strSql.Append("Number=@Number,");
            strSql.Append("UnitNum=@UnitNum,");
            strSql.Append("SaleNum=@SaleNum,");
            strSql.Append("Charge=@Charge,");
            strSql.Append("SellDate=@SellDate,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsSell=@IsSell,");
            strSql.Append("IsUndo=@IsUndo,");
            strSql.Append("PurchaseID=@PurchaseID,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("OrderCode=@OrderCode");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Number", SqlDbType.Int,4),
                    new SqlParameter("@UnitNum", SqlDbType.Int,4),
                    new SqlParameter("@SaleNum", SqlDbType.Int,4),
                    new SqlParameter("@Charge", SqlDbType.Decimal,9),
                    new SqlParameter("@SellDate", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@IsSell", SqlDbType.Int,4),
                    new SqlParameter("@IsUndo", SqlDbType.Int,4),
                    new SqlParameter("@PurchaseID", SqlDbType.BigInt,8),
                    new SqlParameter("@Phone", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@CashsellID", SqlDbType.BigInt,8)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.UnitNum;
            parameters[5].Value = model.SaleNum;
            parameters[6].Value = model.Charge;
            parameters[7].Value = model.SellDate;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.IsSell;
            parameters[10].Value = model.IsUndo;
            parameters[11].Value = model.PurchaseID;
            parameters[12].Value = model.Phone;
            parameters[13].Value = model.OrderCode;
            parameters[14].Value = model.CashsellID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateUndo(long iCashsellID, int iIsUndo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashsell set ");
            strSql.Append(" IsUndo = @IsUndo");
            strSql.Append(" where CashsellID=@CashsellID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = iCashsellID;
            parameters[1].Value = iIsUndo;

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
        public bool Delete(long CashsellID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashsell");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashsellID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashsellID;

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
        public bool DeleteList(string CashsellIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashsell");
            strSql.Append(" where ID in (" + CashsellIDlist + ")  ");
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
		public lgk.Model.Cashsell GetModel(long CashsellID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CashsellID,UserID,Amount,Price,Number,UnitNum,SaleNum,Charge,SellDate,Remark,IsSell,IsUndo,PurchaseID,Phone,OrderCode from Cashsell ");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
                    new SqlParameter("@CashsellID", SqlDbType.BigInt)
            };
            parameters[0].Value = CashsellID;

            lgk.Model.Cashsell model = new lgk.Model.Cashsell();
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
		public lgk.Model.Cashsell DataRowToModel(DataRow row)
        {
            lgk.Model.Cashsell model = new lgk.Model.Cashsell();
            if (row != null)
            {
                if (row["CashsellID"] != null && row["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(row["CashsellID"].ToString());
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
                if (row["UnitNum"] != null && row["UnitNum"].ToString() != "")
                {
                    model.UnitNum = int.Parse(row["UnitNum"].ToString());
                }
                if (row["SaleNum"] != null && row["SaleNum"].ToString() != "")
                {
                    model.SaleNum = int.Parse(row["SaleNum"].ToString());
                }
                if (row["Charge"] != null && row["Charge"].ToString() != "")
                {
                    model.Charge = decimal.Parse(row["Charge"].ToString());
                }
                if (row["SellDate"] != null && row["SellDate"].ToString() != "")
                {
                    model.SellDate = DateTime.Parse(row["SellDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["IsSell"] != null && row["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(row["IsSell"].ToString());
                }
                if (row["IsUndo"] != null && row["IsUndo"].ToString() != "")
                {
                    model.IsUndo = int.Parse(row["IsUndo"].ToString());
                }
                if (row["PurchaseID"] != null && row["PurchaseID"].ToString() != "")
                {
                    model.PurchaseID = long.Parse(row["PurchaseID"].ToString());
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
        public lgk.Model.Cashsell GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 CashsellID, UserID, Amount, Price, Number, UnitNum, SaleNum, Charge, SellDate, Remark, IsSell, IsUndo, PurchaseID,Phone");
            strSql.Append(" from Cashsell");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.Cashsell model = new lgk.Model.Cashsell();
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
        /// 今日已挂卖数量
        /// </summary>
        public decimal GetAlready(long iUserID)
        {
            decimal dEMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(SUM([Number]),0) FROM Cashsell");
            strSql.Append(" WHERE UserID=@UserID");
            strSql.Append(" AND IsUndo=@IsUndo");
            strSql.Append(" AND DATEDIFF (DAY , SellDate, GETDATE()) = 0");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = iUserID;
            parameters[1].Value = 0;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dEMoney = decimal.Parse(obj.ToString());
            }

            return dEMoney;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Cashsell");
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
            strSql.Append("SELECT s.*,Number - SaleNum as Balance,u.UserCode");
            strSql.Append(" FROM [Cashsell] as s inner JOIN [tb_user] as u ON u.UserID=s.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(" ORDER BY s.[Price] ASC");
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
            string proc = "proc_Page_TradingSellList";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "sell");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerListOrderBy(int top, string strWhere, string strOrderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" s.*, (IsNull(Number,0) - IsNull(SaleNum,0)) as SurplusNum, u.UserCode ");
            strSql.Append(" FROM [Cashsell] as s inner JOIN [tb_user] as u ON u.UserID=s.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(strOrderBy);
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
            strSql.Append(" FROM Cashsell ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 卖出
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="SellPrice"></param>
        /// <param name="SellNum"></param>
        /// <returns></returns>
        public string TradingSell(long UserID, decimal SellPrice, int SellNum)
        {
            object[] obj = DbHelperSQLP.ExecuteSP_Param_Object("proc_TradingSell", UserID, SellPrice, SellNum, "");
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
        public int GetJoinUserRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Cashsell as s ");
            strSql.Append(" inner join tb_user as u on s.UserID=u.UserID");
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
            strSql.Append("(select s.*,(s.Number-s.SaleNum) as SurplusNum,u.UserCode,u.TrueName ");
            strSql.Append("from Cashsell as s inner join tb_user as u on s.UserID=u.UserID");
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
