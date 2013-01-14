using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类recommend_content 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class recommend_content
	{
		public recommend_content()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private string _url;
		private string _picture;
		private int _group_id;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		#endregion Model

	}
}

