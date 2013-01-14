using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Mxm.Common;

namespace Mxm.DAL
{
    /// <summary>
    /// 数据访问类download。
    /// </summary>
    public class download
    {
        public download()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int down_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from download");
            strSql.Append(" where down_id=@down_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@down_id", SqlDbType.Int,4)};
            parameters[0].Value = down_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mxm.Model.download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into download(");
            strSql.Append("name,remark,picture,path,sort,create_time)");
            strSql.Append(" values (");
            strSql.Append("@name,@remark,@picture,@path,@sort,@create_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@picture", SqlDbType.NVarChar,250),
					new SqlParameter("@path", SqlDbType.NVarChar,250),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.picture;
            parameters[3].Value = model.path;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.create_time;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(Mxm.Model.download model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update download set ");
            strSql.Append("name=@name,");
            strSql.Append("remark=@remark,");
            strSql.Append("picture=@picture,");
            strSql.Append("path=@path,");
            strSql.Append("sort=@sort,");
            strSql.Append("create_time=@create_time");
            strSql.Append(" where down_id=@down_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@down_id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@picture", SqlDbType.NVarChar,250),
					new SqlParameter("@path", SqlDbType.NVarChar,250),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@create_time", SqlDbType.DateTime)};
            parameters[0].Value = model.down_id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.picture;
            parameters[4].Value = model.path;
            parameters[5].Value = model.sort;
            parameters[6].Value = model.create_time;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int down_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete download ");
            strSql.Append(" where down_id=@down_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@down_id", SqlDbType.Int,4)};
            parameters[0].Value = down_id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public int GetCount(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from download ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }            
            int cmdresult;
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Mxm.Model.download GetModel(int down_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select down_id,name,remark,picture,path,sort,create_time from download ");
            strSql.Append(" where down_id=@down_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@down_id", SqlDbType.Int,4)};
            parameters[0].Value = down_id;

            Mxm.Model.download model = new Mxm.Model.download();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["down_id"].ToString() != "")
                {
                    model.down_id = int.Parse(ds.Tables[0].Rows[0]["down_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.picture = ds.Tables[0].Rows[0]["picture"].ToString();
                model.path = ds.Tables[0].Rows[0]["path"].ToString();
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
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
        public DataSet GetList(string strWhere,string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select down_id,name,remark,picture,path,sort,create_time ");
            strSql.Append(" FROM download ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (order.Trim() != "")
            {
                strSql.Append(" order by " + order);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// <param name="orderType">0 升序；1 降序</param>
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere,string order,int orderType)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 4000),
                    new SqlParameter("@OrderfldName", SqlDbType.VarChar, 4000),
                    new SqlParameter("@StatfldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "download";
            parameters[1].Value = "down_id, name, remark, picture, path, sort, create_time";
            parameters[2].Value = order;
            parameters[3].Value = "down_id";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = orderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPageOrder", parameters, "ds");
        }

        #endregion  成员方法
    }
}
