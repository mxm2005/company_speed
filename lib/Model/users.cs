using System;
namespace Mxm.Model
{
    /// <summary>
    /// 实体类users 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class users
    {
        public users()
        { }
        #region Model
        private int _uid;
        private string _username;
        private string _password;
        private bool _sex;
        private string _email;
        private string _mobile;
        private string _tel;
        private DateTime _last_login_time;
        private DateTime _reg_time;
        private string _qq;
        private string _msn;
        private int _status;
        /// <summary>
        /// 
        /// </summary>
        public int uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool sex
        {
            set { _sex = value; }
            get { return _sex; }
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
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime last_login_time
        {
            set { _last_login_time = value; }
            get { return _last_login_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime reg_time
        {
            set { _reg_time = value; }
            get { return _reg_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qq
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msn
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

