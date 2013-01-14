using System;
namespace Mxm.Model
{
	/// <summary>
	/// 实体类product_type 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class product_type
	{
		public product_type()
		{}
		#region Model
		private int _type_id;
		private string _type_name;
		private int _parent_id;
        private string _banner;
        private string _remark;
        private int _sort;
		/// <summary>
		/// 分类ID
		/// </summary>
		public int type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
		}
		/// <summary>
		/// 父类ID
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
        /// <summary>
        /// Banner图片
        /// </summary>
        public string banner
        {
            set { _banner = value; }
            get { return _banner; }
        }
        /// <summary>
        /// 描述备注
        /// </summary>
        public string remark
        {
            set { _remark= value; }
            get { return _remark; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		#endregion Model

	}
}

