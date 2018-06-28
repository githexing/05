using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashsell:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cashsell
    {
        public Cashsell()
        { }
        #region Model
        private long _cashsellid;
        private long _userid = 0;
        private decimal _amount = 0M;
        private decimal _price = 0M;
        private int _number = 0;
        private int _unitnum = 0;
        private int _salenum = 0;
        private decimal _charge = 0M;
        private DateTime _selldate;
        private string _remark;
        private int _issell = 0;
        private int _isundo = 0;
        private long _purchaseid = 0;
        private string _phone;
        private string _ordercode;
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
        public int UnitNum
        {
            set { _unitnum = value; }
            get { return _unitnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SaleNum
        {
            set { _salenum = value; }
            get { return _salenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Charge
        {
            set { _charge = value; }
            get { return _charge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SellDate
        {
            set { _selldate = value; }
            get { return _selldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsSell
        {
            set { _issell = value; }
            get { return _issell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsUndo
        {
            set { _isundo = value; }
            get { return _isundo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long PurchaseID
        {
            set { _purchaseid = value; }
            get { return _purchaseid; }
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
