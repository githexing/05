using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// Cashbuy
    /// </summary>
    public partial class Cashbuy
    {
        private readonly lgk.DAL.Cashbuy dal = new lgk.DAL.Cashbuy();
        public Cashbuy()
        { }
        #region Method

        public bool Exists(long CashbuyID)
        {
            return dal.Exists(CashbuyID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashbuy model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashbuy model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long CashbuyID)
        {
            return dal.Delete(CashbuyID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CashbuyIDlist)
        {
            return dal.DeleteList(CashbuyIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashbuy GetModel(long CashbuyID)
        {
            return dal.GetModel(CashbuyID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashbuy GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
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
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
        }

        /// <summary>
        /// 获得数据列表分页
        /// </summary>
        public DataSet GetInnerListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            return dal.GetInnerListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.Cashbuy> DataTableToList(DataTable dt)
        {
            List<lgk.Model.Cashbuy> modelList = new List<lgk.Model.Cashbuy>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.Cashbuy model;
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
        /// 获得数据列表（排序）
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
        public DataSet GetList(int Top, string strWhere, string strFiledOrder)
        {
            return dal.GetList(Top, strWhere, strFiledOrder);
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
            return dal.TradingBuy(UserID, BuyPrice, BuyNum);
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
