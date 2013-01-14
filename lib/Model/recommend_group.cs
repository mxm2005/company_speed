using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类recommend_group 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class recommend_group
	{
		public recommend_group()
		{}
		#region Model
		private int _group_id;
		private string _group_name;
        private string _remark;

		/// <summary>
		/// 
		/// </summary>
		public int group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 分组名称
		/// </summary>
		public string group_name
		{
			set{ _group_name=value;}
			get{return _group_name;}
		}
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}

