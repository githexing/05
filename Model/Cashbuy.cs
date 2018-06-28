using System;

namespace lgk.Model
{
    /// <summary>
	/// Cashbuy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Cashbuy
    {
        public Cashbuy()
        { }
        #region Model
        private long _cashbuyid;
        private long _userid = 0;
        private decimal _amount = 0M;
        private decimal _price = 0M;
        private int _number;
        private int _buynum = 0;
        private DateTime _buydate;
        private int _isbuy = 0;
        private string _phone;
        private string _ordercode;
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
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BuyNum
        {
            set { _buynum = value; }
            get { return _buynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsBuy
        {
            set { _isbuy = value; }
            get { return _isbuy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        #endregion Model

    }
}
