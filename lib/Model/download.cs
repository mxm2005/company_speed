using System;

namespace Mxm.Model
{
    /// <summary>
    /// 实体类download 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class download
    {
        public download()
        { }
        #region Model
        private int _down_id;
        private string _name;
        private string _remark;
        private string _picture;
        private string _path;
        private int? _sort;
        private DateTime? _create_time;
        /// <summary>
        /// 
        /// </summary>
        public int down_id
        {
            set { _down_id = value; }
            get { return _down_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string picture
        {
            set { _picture = value; }
            get { return _picture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

    }
}

