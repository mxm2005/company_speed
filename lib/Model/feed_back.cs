using System;
using System.Collections.Generic;
using System.Text;

namespace Mxm.Model
{
    /// <summary>
    /// 实体类feed_back 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class feed_back
    {
        public feed_back()
        { }
        #region Model
        private int _feed_id;
        private string _title;
        private string _linkman;
        private string _corperation;
        private string _link_address;
        private decimal? _postcode;
        private string _link_tel;
        private string _fax;
        private decimal? _mobile;
        private string _email;
        private string _msg_content;
        /// <summary>
        /// 
        /// </summary>
        public int feed_id
        {
            set { _feed_id = value; }
            get { return _feed_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string corperation
        {
            set { _corperation = value; }
            get { return _corperation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_address
        {
            set { _link_address = value; }
            get { return _link_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? postcode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_tel
        {
            set { _link_tel = value; }
            get { return _link_tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msg_content
        {
            set { _msg_content = value; }
            get { return _msg_content; }
        }
        #endregion Model

    }
}
