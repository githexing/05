using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:Cashsell
    /// </summary>
    public partial class Cashsell
    {
        private readonly lgk.DAL.Cashsell dal = new lgk.DAL.Cashsell();
        public Cashsell()
        { }
        #region Method

        public bool Exists(long CashsellID)
        {
            return dal.Exists(CashsellID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashsell model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashsell model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateUndo(long iCashsellID, int iIsUndo)
        {
            return dal.UpdateUndo(iCashsellID, iIsUndo);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long CashsellID)
        {
            return dal.Delete(CashsellID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CashsellIDlist)
        {
            return dal.DeleteList(CashsellIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashsell GetModel(long CashsellID)
        {
            return dal.GetModel(CashsellID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashsell GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 今日已挂卖数量
        /// </summary>
        public decimal GetAlready(long iUserID)
        {
            return dal.GetAlready(iUserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.Cashsell> DataTableToList(DataTable dt)
        {
            List<lgk.Model.Cashsell> modelList = new List<lgk.Model.Cashsell>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.Cashsell model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
        }

        /// <summary>
        /// 获得数据列表分页
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet GetInnerListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            return dal.GetInnerListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);
        }

        /// <summary>
        /// 获取数据列表（排序）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrderBy"></param>
        /// <returns></returns>
        public DataSet GetInnerListOrderBy(int top, string strWhere, string strOrderBy)
        {
            return dal.GetInnerListOrderBy(top, strWhere, strOrderBy);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
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
            return dal.TradingSell(UserID, SellPrice, SellNum);
        }

        public int GetJoinUserRecordCount(string strWhere)
        {
            return dal.GetJoinUserRecordCount(strWhere);
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion
    }
}
