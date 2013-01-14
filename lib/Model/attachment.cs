using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类attachment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class attachment
	{
		public attachment()
		{}
		#region Model
		private int _attach_id;
		private string _path;
		private int _depositor_id;
		private int _depositor_type;
		private DateTime _create_time;
		private int _file_type;
		/// <summary>
		/// 
		/// </summary>
		public int attach_id
		{
			set{ _attach_id=value;}
			get{return _attach_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string path
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int depositor_id
		{
			set{ _depositor_id=value;}
			get{return _depositor_id;}
		}
		/// <summary>
		/// 0:company 1:production 2:article
		/// </summary>
		public int depositor_type
		{
			set{ _depositor_type=value;}
			get{return _depositor_type;}
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
		/// 0:图片 
		/// </summary>
		public int file_type
		{
			set{ _file_type=value;}
			get{return _file_type;}
		}
		#endregion Model

        /// <summary>
        /// 附件类型 0：图片 1：视频
        /// </summary>
        public enum FileType
        {
            Pic=0,
            Vidio=1
        }

        /// <summary>
        /// 寄托者类型 0：company 1:production 2:article
        /// </summary>
        public enum DepositorType
        {
            Company = 0,
            Production = 1,
            Article=2
        }
	}
}

