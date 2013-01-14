using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Mxm.Common;

namespace Mxm.DAL
{
	/// <summary>
	/// 数据访问类attachment。
	/// </summary>
	public class attachment
	{
		public attachment()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("attach_id", "attachment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int attach_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from attachment");
			strSql.Append(" where attach_id=@attach_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int,4)};
			parameters[0].Value = attach_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mxm.Model.attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into attachment(");
			strSql.Append("path,depositor_id,depositor_type,create_time,file_type)");
			strSql.Append(" values (");
			strSql.Append("@path,@depositor_id,@depositor_type,@create_time,@file_type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@path", SqlDbType.NVarChar,500),
					new SqlParameter("@depositor_id", SqlDbType.Int,4),
					new SqlParameter("@depositor_type", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@file_type", SqlDbType.Int,4)};
			parameters[0].Value = model.path;
			parameters[1].Value = model.depositor_id;
			parameters[2].Value = model.depositor_type;
			parameters[3].Value = model.create_time;
			parameters[4].Value = model.file_type;

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
		/// 更新一条数据
		/// </summary>
		public void Update(Mxm.Model.attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update attachment set ");
			strSql.Append("path=@path,");
			strSql.Append("depositor_id=@depositor_id,");
			strSql.Append("depositor_type=@depositor_type,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("file_type=@file_type");
			strSql.Append(" where attach_id=@attach_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int,4),
					new SqlParameter("@path", SqlDbType.NVarChar,500),
					new SqlParameter("@depositor_id", SqlDbType.Int,4),
					new SqlParameter("@depositor_type", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@file_type", SqlDbType.Int,4)};
			parameters[0].Value = model.attach_id;
			parameters[1].Value = model.path;
			parameters[2].Value = model.depositor_id;
			parameters[3].Value = model.depositor_type;
			parameters[4].Value = model.create_time;
			parameters[5].Value = model.file_type;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int attach_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete attachment ");
			strSql.Append(" where attach_id=@attach_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int,4)};
			parameters[0].Value = attach_id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mxm.Model.attachment GetModel(int attach_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select attach_id,path,depositor_id,depositor_type,create_time,file_type from attachment ");
			strSql.Append(" where attach_id=@attach_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int,4)};
			parameters[0].Value = attach_id;

			Mxm.Model.attachment model=new Mxm.Model.attachment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["attach_id"].ToString()!="")
				{
					model.attach_id=int.Parse(ds.Tables[0].Rows[0]["attach_id"].ToString());
				}
				model.path=ds.Tables[0].Rows[0]["path"].ToString();
				if(ds.Tables[0].Rows[0]["depositor_id"].ToString()!="")
				{
					model.depositor_id=int.Parse(ds.Tables[0].Rows[0]["depositor_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["depositor_type"].ToString()!="")
				{
					model.depositor_type=int.Parse(ds.Tables[0].Rows[0]["depositor_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["file_type"].ToString()!="")
				{
					model.file_type=int.Parse(ds.Tables[0].Rows[0]["file_type"].ToString());
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
			strSql.Append("select attach_id,path,depositor_id,depositor_type,create_time,file_type ");
			strSql.Append(" FROM attachment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
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
			parameters[0].Value = "attachment";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

