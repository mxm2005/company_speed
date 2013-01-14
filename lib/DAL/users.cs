using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Mxm.Common;

namespace Mxm.DAL
{
    /// <summary>
    /// 数据访问类users。
    /// </summary>
    public class users
    {
        Database db = DatabaseFactory.CreateDatabase("localdb");
        public users()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            bool resVal = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from users where username=@username ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "username", DbType.String, username);
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
            if (cmdresult > 0)
            {
                resVal = true;
            }
            return resVal;
        }

        /// <summary>
        /// Email是否已经存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistsEmail(string email)
        {
            bool resVal = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from users where EMail=@EMail ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EMail", DbType.String, email);
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
            if (cmdresult > 0)
            {
                resVal = true;
            }
            return resVal;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from users where username=@username and password=@password ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "username", DbType.String, username);
            db.AddInParameter(dbCommand, "password", DbType.String, password);
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
        public int Add(Mxm.Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into users(");
            strSql.Append("username,password,sex,email,mobile,tel,reg_time,qq,msn,status)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@sex,@email,@mobile,@tel,@reg_time,@qq,@msn,@status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@email", SqlDbType.NVarChar,500),
					new SqlParameter("@mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@tel", SqlDbType.NVarChar,100),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@qq", SqlDbType.NVarChar,50),
					new SqlParameter("@msn", SqlDbType.NVarChar,200),
					new SqlParameter("@status", SqlDbType.Int,4)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.sex;
            parameters[3].Value = model.email;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.tel;
            parameters[6].Value = model.reg_time;
            parameters[7].Value = model.qq;
            parameters[8].Value = model.msn;
            parameters[9].Value = model.status;

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
        public void Update(Mxm.Model.users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("sex=@sex,");
            strSql.Append("email=@email,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("tel=@tel,");
            strSql.Append("last_login_time=@last_login_time,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("qq=@qq,");
            strSql.Append("msn=@msn,");
            strSql.Append("status=@status");
            strSql.Append(" where uid=@uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@email", SqlDbType.NVarChar,500),
					new SqlParameter("@mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@tel", SqlDbType.NVarChar,100),
					new SqlParameter("@last_login_time", SqlDbType.DateTime),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@qq", SqlDbType.NVarChar,50),
					new SqlParameter("@msn", SqlDbType.NVarChar,200),
					new SqlParameter("@status", SqlDbType.Int,4)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.sex;
            parameters[4].Value = model.email;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.last_login_time;
            parameters[8].Value = model.reg_time;
            parameters[9].Value = model.qq;
            parameters[10].Value = model.msn;
            parameters[11].Value = model.status;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete users ");
            strSql.Append(" where uid=@uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Mxm.Model.users GetModel(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,username,password,sex,email,mobile,tel,last_login_time,reg_time,qq,msn,status from users ");
            strSql.Append(" where uid=@uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            Mxm.Model.users model = new Mxm.Model.users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["uid"].ToString() != "")
                {
                    model.uid = int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["sex"].ToString().ToLower() == "true"))
                    {
                        model.sex = true;
                    }
                    else
                    {
                        model.sex = false;
                    }
                }
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                if (ds.Tables[0].Rows[0]["last_login_time"].ToString() != "")
                {
                    model.last_login_time = DateTime.Parse(ds.Tables[0].Rows[0]["last_login_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reg_time"].ToString() != "")
                {
                    model.reg_time = DateTime.Parse(ds.Tables[0].Rows[0]["reg_time"].ToString());
                }
                model.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                model.msn = ds.Tables[0].Rows[0]["msn"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uid,username,password,sex,email,mobile,tel,last_login_time,reg_time,qq,msn,status ");
            strSql.Append(" FROM users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "users";
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

