using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:Cashorder
    /// </summary>
    public partial class Cashorder
    {
        private readonly lgk.DAL.Cashorder dal = new lgk.DAL.Cashorder();
        public Cashorder()
        { }
        #region Method

        public bool Exists(long OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashorder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashorder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderID)
        {
            return dal.Delete(OrderID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            return dal.DeleteList(OrderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashorder GetModel(long OrderID)
        {
            return dal.GetModel(OrderID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(int top, string strWhere, string orderby)
        {
            return dal.GetOrderList(top, strWhere, orderby);
        }

        /// <summary>
        /// 查询交易订单，分页
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="TypeID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet GetOrderListByPage(long UserID, long OrderID, int TypeID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string fromwhere)
        {
            return dal.GetOrderListByPage(UserID, OrderID, TypeID, PageIndex, PageSize, out PageCount, out TotalCount, fromwhere);
        }

        /// <summary>
        /// 获取最新交易价格（以卖出为准）
        /// </summary>
        /// <returns></returns>
        public decimal GetLatestPrice()
        {
            return dal.GetLatestPrice();
        }

        /// <summary>
        /// 获取 买入/卖出 联合数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetBuyAndSellList(long UserID)
        {
            return dal.GetBuyAndSellList(UserID);
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
            return dal.GetBuyAndSellListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);
        }

        #endregion
    }
}
