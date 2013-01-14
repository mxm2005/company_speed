using System;
namespace Mxm.Model
{
    /// <summary>
    /// 实体类production 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class production
    {
        public production()
        { }
        #region Model
        private int _pid;
        private string _product_name;
        private string _product_desc;
        private DateTime _create_time;
        private DateTime _update_time;
        private string _picture;
        private string _picture_small;
        private decimal _status;
        private int _product_type;
        private int _balance;
        private string _product_synopsis;
        private decimal _market_price;
        private decimal _buy_price;
        private int _sort;
        private string _vidio;
        private string _model;
        /// <summary>
        /// 
        /// </summary>
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string product_name
        {
            set { _product_name = value; }
            get { return _product_name; }
        }
        /// <summary>
        /// 详情
        /// </summary>
        public string product_desc
        {
            set { _product_desc = value; }
            get { return _product_desc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime update_time
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// 形象图
        /// </summary>
        public string picture
        {
            set { _picture = value; }
            get { return _picture; }
        }
        /// <summary>
        /// 形象图-小图
        /// </summary>
        public string picture_small
        {
            set { _picture_small = value; }
            get { return _picture_small; }
        }
        /// <summary>
        /// 1:可用 0:不可用
        /// </summary>
        public decimal status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int product_type
        {
            set { _product_type = value; }
            get { return _product_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string product_synopsis
        {
            set { _product_synopsis = value; }
            get { return _product_synopsis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal market_price
        {
            set { _market_price = value; }
            get { return _market_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal buy_price
        {
            set { _buy_price = value; }
            get { return _buy_price; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 视频
        /// </summary>
        public string vidio
        {
            set { _vidio = value; }
            get { return _vidio; }
        }
        /// <summary>
        /// 型号
        /// </summary>
        public string model
        {
            set { _model = value; }
            get { return _model; }
        }
        #endregion Model

    }
}

