using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace Mxm.DAL
{
	/// <summary>
	/// 数据访问类art_type。
	/// </summary>
	public class art_type
	{
		public art_type()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(type_id)+1 from art_type";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string type_name)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from art_type where type_name=@type_name ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "type_name", DbType.String, type_name);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult <= 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Mxm.Model.art_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into art_type(");
			strSql.Append("type_name)");

			strSql.Append(" values (");
			strSql.Append("@type_name)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "type_name", DbType.String, model.type_name);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Mxm.Model.art_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update art_type set ");
			strSql.Append("type_name=@type_name");
			strSql.Append(" where type_id=@type_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "type_id", DbType.Int32, model.type_id);
			db.AddInParameter(dbCommand, "type_name", DbType.String, model.type_name);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int type_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete art_type ");
			strSql.Append(" where type_id=@type_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "type_id", DbType.Int32,type_id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Mxm.Model.art_type GetModel(int type_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select type_id,type_name from art_type ");
			strSql.Append(" where type_id=@type_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "type_id", DbType.Int32,type_id);
			Mxm.Model.art_type model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select type_id,type_name ");
			strSql.Append(" FROM art_type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "art_type");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Mxm.Model.art_type> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select type_id,type_name ");
			strSql.Append(" FROM art_type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<Mxm.Model.art_type> list = new List<Mxm.Model.art_type>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Mxm.Model.art_type ReaderBind(IDataReader dataReader)
		{
			Mxm.Model.art_type model=new Mxm.Model.art_type();
			object ojb; 
			ojb = dataReader["type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.type_id=(int)ojb;
			}
			model.type_name=dataReader["type_name"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

