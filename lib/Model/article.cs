using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类article 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class article
	{
		public article()
		{}
		#region Model
		private int _aid;
		private string _title;
		private string _content;
		private DateTime _create_time;
		private DateTime _update_time;
		private string _author;
        private string _sub_title;        
        private string _editor;        
        private int status;
        private int _type_id;
        private string _picture_small;
        private string _sumary;

		/// <summary>
		/// 
		/// </summary>
		public int aid
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime update_time
		{
			set{ _update_time=value;}
			get{return _update_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Sub_title
        {
            get { return _sub_title; }
            set { _sub_title = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Type_id
        {
            get { return _type_id; }
            set { _type_id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Picture_small
        {
            get { return _picture_small; }
            set { _picture_small = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sumary
        {
            get { return _sumary; }
            set { _sumary = value; }
        }
		#endregion Model

	}
}

