using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Mxm.Common;

namespace Mxm.DAL
{
	/// <summary>
	/// 数据访问类message。
	/// </summary>
	public class message
	{
		public message()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("mid", "message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int mid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from message");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获取总记录数
        /// </summary>
        public int GetCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from message");

            object obj= DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mxm.Model.message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into message(");
			strSql.Append("title,content,parent_id,create_time,type_id)");
			strSql.Append(" values (");
            strSql.Append("@title,@content,@parent_id,@create_time,@type_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@content", SqlDbType.NVarChar,0),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
                    new SqlParameter("@type_id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.parent_id;
			parameters[3].Value = model.create_time;
            parameters[4].Value = model.type_id;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return -1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int mid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete message ");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mxm.Model.message GetModel(int mid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select mid,title,content,parent_id,create_time,type_id from message ");
			strSql.Append(" where mid=@mid ");
			SqlParameter[] parameters = {
					new SqlParameter("@mid", SqlDbType.Int,4)};
			parameters[0].Value = mid;

			Mxm.Model.message model=new Mxm.Model.message();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["mid"].ToString()!="")
				{
					model.mid=int.Parse(ds.Tables[0].Rows[0]["mid"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.content=ds.Tables[0].Rows[0]["content"].ToString();
				if(ds.Tables[0].Rows[0]["parent_id"].ToString()!="")
				{
					model.parent_id=int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
				}
                if (ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    model.type_id = int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
                }
				return model;
			}
			else
			{
			return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select mid,title,content,parent_id,create_time,type_id ");
			strSql.Append(" FROM message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "message";
			parameters[1].Value = "mid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="orderFldName"></param>
        /// <param name="ascOrDesc">0升序，非0降序</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere,string orderFldName,int ascOrDesc)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@StatfldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "message";
            parameters[1].Value = "mid,title,content,create_time,type_id";
            parameters[2].Value = orderFldName;
            parameters[3].Value = "mid";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = ascOrDesc;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPageOrder", parameters, "ds");
        }

		#endregion  成员方法
	}
}

