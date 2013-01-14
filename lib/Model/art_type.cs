using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类art_type 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class art_type
	{
		public art_type()
		{}
		#region Model
		private int _type_id;
		private string _type_name;
		/// <summary>
		/// 
		/// </summary>
		public int type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
		}
		#endregion Model

	}
}

