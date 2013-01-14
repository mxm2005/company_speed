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
    /// 数据访问类feed_back。
    /// </summary>
    public class feed_back
    {
        public feed_back()
        { }

        #region  成员方法
                
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int feed_id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from feed_back where feed_id=@feed_id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "feed_id", DbType.Int32, feed_id);
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
            if (cmdresult == 0)
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
        public void Add(Mxm.Model.feed_back model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into feed_back(");
            strSql.Append("title,linkman,corperation,link_address,postcode,link_tel,fax,mobile,email,msg_content)");

            strSql.Append(" values (");
            strSql.Append("@title,@linkman,@corperation,@link_address,@postcode,@link_tel,@fax,@mobile,@email,@msg_content)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "title", DbType.String, model.title);
            db.AddInParameter(dbCommand, "linkman", DbType.String, model.linkman);
            db.AddInParameter(dbCommand, "corperation", DbType.String, model.corperation);
            db.AddInParameter(dbCommand, "link_address", DbType.String, model.link_address);
            db.AddInParameter(dbCommand, "postcode", DbType.Decimal, model.postcode);
            db.AddInParameter(dbCommand, "link_tel", DbType.String, model.link_tel);
            db.AddInParameter(dbCommand, "fax", DbType.String, model.fax);
            db.AddInParameter(dbCommand, "mobile", DbType.Decimal, model.mobile);
            db.AddInParameter(dbCommand, "email", DbType.String, model.email);
            db.AddInParameter(dbCommand, "msg_content", DbType.String, model.msg_content);
            db.ExecuteNonQuery(dbCommand);
        }
                
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int feed_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete feed_back ");
            strSql.Append(" where feed_id=@feed_id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "feed_id", DbType.Int32, feed_id);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mxm.Model.feed_back GetModel(int feed_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select feed_id,title,linkman,corperation,link_address,postcode,link_tel,fax,mobile,email,msg_content from feed_back ");
            strSql.Append(" where feed_id=@feed_id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "feed_id", DbType.Int32, feed_id);
            Mxm.Model.feed_back model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select feed_id,title,linkman,corperation,link_address,postcode,link_tel,fax,mobile,email,msg_content ");
            strSql.Append(" FROM feed_back ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "feed_back");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "feed_id");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Mxm.Model.feed_back> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select feed_id,title,linkman,corperation,link_address,postcode,link_tel,fax,mobile,email,msg_content ");
            strSql.Append(" FROM feed_back ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Mxm.Model.feed_back> list = new List<Mxm.Model.feed_back>();
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
        /// 获取总记录数
        /// </summary>
        public int GetCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from feed_back");

            object obj = Mxm.Common.DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 对象实体绑定数据
        /// </summary>
        public Mxm.Model.feed_back ReaderBind(IDataReader dataReader)
        {
            Mxm.Model.feed_back model = new Mxm.Model.feed_back();
            object ojb;
            ojb = dataReader["feed_id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.feed_id = (int)ojb;
            }
            model.title = dataReader["title"].ToString();
            model.linkman = dataReader["linkman"].ToString();
            model.corperation = dataReader["corperation"].ToString();
            model.link_address = dataReader["link_address"].ToString();
            ojb = dataReader["postcode"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.postcode = (decimal)ojb;
            }
            model.link_tel = dataReader["link_tel"].ToString();
            model.fax = dataReader["fax"].ToString();
            ojb = dataReader["mobile"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.mobile = (decimal)ojb;
            }
            model.email = dataReader["email"].ToString();
            model.msg_content = dataReader["msg_content"].ToString();
            return model;
        }

        #endregion  成员方法
    }
}