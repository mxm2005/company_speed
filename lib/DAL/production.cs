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
    /// 数据访问类production。
    /// </summary>
    public class production
    {
        public production()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int pid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from production where pid=@pid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, pid);
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

        public int GetCount(string where)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from production ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
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
            return cmdresult;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mxm.Model.production model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into production(");
            strSql.Append("product_name,product_desc,create_time,update_time,picture,status,product_type,balance,product_synopsis,market_price,buy_price,sort,vidio,picture_small,model)");

            strSql.Append(" values (");
            strSql.Append("@product_name,@product_desc,@create_time,@update_time,@picture,@status,@product_type,@balance,@product_synopsis,@market_price,@buy_price,@sort,@vidio,@picture_small,@model)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "product_name", DbType.String, model.product_name);
            db.AddInParameter(dbCommand, "product_desc", DbType.String, model.product_desc);
            db.AddInParameter(dbCommand, "create_time", DbType.DateTime, model.create_time);
            db.AddInParameter(dbCommand, "update_time", DbType.DateTime, model.update_time);
            db.AddInParameter(dbCommand, "picture", DbType.String, model.picture);
            db.AddInParameter(dbCommand, "status", DbType.Decimal, model.status);
            db.AddInParameter(dbCommand, "product_type", DbType.Int32, model.product_type);
            db.AddInParameter(dbCommand, "balance", DbType.Int32, model.balance);
            db.AddInParameter(dbCommand, "product_synopsis", DbType.String, model.product_synopsis);
            db.AddInParameter(dbCommand, "market_price", DbType.Decimal, model.market_price);
            db.AddInParameter(dbCommand, "buy_price", DbType.Decimal, model.buy_price);
            db.AddInParameter(dbCommand, "sort", DbType.Int32, model.sort);
            db.AddInParameter(dbCommand, "vidio", DbType.String, model.vidio);
            db.AddInParameter(dbCommand, "picture_small", DbType.String, model.picture_small);
            db.AddInParameter(dbCommand, "model", DbType.String, model.model);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Mxm.Model.production model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update production set ");
            strSql.Append("product_name=@product_name,");
            strSql.Append("product_desc=@product_desc,");
            strSql.Append("create_time=@create_time,");
            strSql.Append("update_time=@update_time,");
            strSql.Append("picture=@picture,");
            strSql.Append("status=@status,");
            strSql.Append("product_type=@product_type,");
            strSql.Append("balance=@balance,");
            strSql.Append("product_synopsis=@product_synopsis,");
            strSql.Append("market_price=@market_price,");
            strSql.Append("buy_price=@buy_price,");
            strSql.Append("sort=@sort, ");
            strSql.Append("vidio=@vidio, ");
            strSql.Append("picture_small=@picture_small, ");
            strSql.Append("model=@model ");
            strSql.Append(" where pid=@pid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, model.pid);
            db.AddInParameter(dbCommand, "product_name", DbType.String, model.product_name);
            db.AddInParameter(dbCommand, "product_desc", DbType.String, model.product_desc);
            db.AddInParameter(dbCommand, "create_time", DbType.DateTime, model.create_time);
            db.AddInParameter(dbCommand, "update_time", DbType.DateTime, model.update_time);
            db.AddInParameter(dbCommand, "picture", DbType.String, model.picture);
            db.AddInParameter(dbCommand, "status", DbType.Decimal, model.status);
            db.AddInParameter(dbCommand, "product_type", DbType.Int32, model.product_type);
            db.AddInParameter(dbCommand, "balance", DbType.Int32, model.balance);
            db.AddInParameter(dbCommand, "product_synopsis", DbType.String, model.product_synopsis);
            db.AddInParameter(dbCommand, "market_price", DbType.Decimal, model.market_price);
            db.AddInParameter(dbCommand, "buy_price", DbType.Decimal, model.buy_price);
            db.AddInParameter(dbCommand, "sort", DbType.Int32, model.sort);
            db.AddInParameter(dbCommand, "vidio", DbType.String, model.vidio);
            db.AddInParameter(dbCommand, "picture_small", DbType.String, model.picture_small);
            db.AddInParameter(dbCommand, "model", DbType.String, model.model);
            db.ExecuteNonQuery(dbCommand);

        }
        /// <summary>
        /// 更新产品状态
        /// </summary>
        public bool UpdateStatus(int pid, int status)
        {
            bool resVal = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update production set ");
            strSql.Append("status=@status");
            strSql.Append(" where pid=@pid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, pid);
            db.AddInParameter(dbCommand, "status", DbType.Decimal, status);
            int cmdRes= db.ExecuteNonQuery(dbCommand);
            if (cmdRes > 0)
            {
                resVal = true;
            }
            return resVal;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete production ");
            strSql.Append(" where pid=@pid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, pid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mxm.Model.production GetModel(int pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pid,product_name,product_desc,create_time,update_time,picture,status,product_type,balance,product_synopsis,market_price,buy_price,sort,vidio,picture_small,model from production ");
            strSql.Append(" where pid=@pid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, pid);
            Mxm.Model.production model = null;
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
        /// 得到下一篇、上一篇
        /// <param name="pid">当前ID</param>
        /// <param name="flag">上一篇:0,下一篇:1</param>
        /// <param name="where">查询条件</param>
        /// </summary>
        public Mxm.Model.production GetNextModel(int pid, int flag, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pid,product_name,product_desc,create_time,update_time,picture,status,product_type,balance,product_synopsis,market_price,buy_price,sort,vidio,picture_small,model from production where ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(where + " and ");
            }
            if (flag > 0)//上一篇
            {
                strSql.Append(" pid<@pid order by pid desc");
            }
            else//下一篇
            {
                strSql.Append(" pid>@pid order by pid asc");
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pid", DbType.Int32, pid);
            Mxm.Model.production model = null;
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
            strSql.Append("select pid,product_name,product_desc,create_time,update_time,picture,status,product_type,balance,product_synopsis,market_price,buy_price,sort,vidio,picture_small,model ");
            strSql.Append(" FROM production ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by update_time desc");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "production");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "pid");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 分页获取数据列表，有排序
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex,string fldLst, string strWhere,string order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPageOrder");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "production");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, fldLst);
            db.AddInParameter(dbCommand, "OrderfldName", DbType.AnsiString, order);
            db.AddInParameter(dbCommand, "StatfldName", DbType.AnsiString, "pid");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 1);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Mxm.Model.production> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pid,product_name,product_desc,create_time,update_time,picture,status,product_type,balance,product_synopsis,market_price,buy_price,sort,vidio,picture_small,model ");
            strSql.Append(" FROM production ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by update_time desc");
            List<Mxm.Model.production> list = new List<Mxm.Model.production>();
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
        public Mxm.Model.production ReaderBind(IDataReader dataReader)
        {
            Mxm.Model.production model = new Mxm.Model.production();
            object ojb;
            ojb = dataReader["pid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.pid = (int)ojb;
            }
            model.product_name = dataReader["product_name"].ToString();
            model.product_desc = dataReader["product_desc"].ToString();
            ojb = dataReader["create_time"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.create_time = (DateTime)ojb;
            }
            ojb = dataReader["update_time"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.update_time = (DateTime)ojb;
            }
            model.picture = dataReader["picture"].ToString();
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.status = (decimal)ojb;
            }
            ojb = dataReader["product_type"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.product_type = (int)ojb;
            }
            ojb = dataReader["balance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.balance = (int)ojb;
            }
            model.product_synopsis = dataReader["product_synopsis"].ToString();
            ojb = dataReader["market_price"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.market_price = (decimal)ojb;
            }
            ojb = dataReader["buy_price"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.buy_price = (decimal)ojb;
            }
            ojb = dataReader["sort"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.sort = (int)ojb;
            }
            model.vidio = dataReader["vidio"].ToString();
            model.picture_small = dataReader["picture_small"].ToString();
            model.model = dataReader["model"].ToString();
            return model;
        }

        #endregion  成员方法
    }
}

