using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashorder:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cashorder
    {
        public Cashorder()
        { }
        #region Model
        private long _orderid;
        private long _cashbuyid = 0;
        private long _cashsellid = 0;
        private long _buserid = 0;
        private long _suserid = 0;
        private string _ordercode;
        private DateTime _orderdate;
        private int _bstatus = 0;
        private string _bremark;
        private int _sstatus = 0;
        private string _sremark;
        private int _status = 0;
        private int _tradingnum = 0;
        private decimal _sprice = 0M;
        /// <summary>
        /// 
        /// </summary>
        public long OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long CashbuyID
        {
            set { _cashbuyid = value; }
            get { return _cashbuyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long CashsellID
        {
            set { _cashsellid = value; }
            get { return _cashsellid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long BUserID
        {
            set { _buserid = value; }
            get { return _buserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long SUserID
        {
            set { _suserid = value; }
            get { return _suserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BStatus
        {
            set { _bstatus = value; }
            get { return _bstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BRemark
        {
            set { _bremark = value; }
            get { return _bremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SStatus
        {
            set { _sstatus = value; }
            get { return _sstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SRemark
        {
            set { _sremark = value; }
            get { return _sremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TradingNum
        {
            set { _tradingnum = value; }
            get { return _tradingnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SPrice
        {
            set { _sprice = value; }
            get { return _sprice; }
        }
        #endregion Model
    }
}
