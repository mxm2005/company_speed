using System;
using System.Data;
using System.Configuration;
using System.IO;

namespace Mxm.Common
{
    /// <summary>
    /// Error 的摘要说明
    /// mxm 2011-1-14
    /// </summary>
    public static class WriteError
    {
        /// <summary>
        /// 如果路径为空，默认日志写到C:\\Error.txt，每写一条都换一行
        /// </summary>
        /// <param name="path">文件物理全路径</param>
        /// <param name="str">写入的内容</param>
        /// <returns></returns>
        public static bool WriteTxt( string path, string str )
        {
            if( string.IsNullOrEmpty( path ) )
            {
                path = "C:\\Error.txt";
            }

            str += "\r\n";

            try
            {
                string fileName = path;
                if( !File.Exists( fileName ) )
                {
                    //新建文件并写入
                    StreamWriter sw = File.CreateText( fileName );
                    sw.Write( str );
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    //C#追加文件 
                    StreamWriter sw = File.AppendText( fileName );
                    sw.Write( str );
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 写到本地根目录的log.txt文件，每写一条都换一行
        /// </summary>
        /// <param name="str">写入的内容</param>
        /// <returns></returns>
        public static bool WriteTxt(string str)
        {
            string path = GetServerPath() + "log.txt";

            str += "\r\n";

            try
            {
                string fileName = path;
                if( !File.Exists( fileName ) )
                {
                    //新建文件并写入
                    StreamWriter sw = File.CreateText( fileName );
                    sw.Write( str );
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    //C#追加文件 
                    StreamWriter sw = File.AppendText( fileName );
                    sw.Write( str );
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取当前网站的根目录物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetServerPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 替换文件内容
        /// </summary>
        /// <param name="path"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ReplaceTxt(string path, string str)
        {
            if (string.IsNullOrEmpty(path))  
            {
                return false;
            }
            else if (!System.IO.File.Exists(path))
            {
                System.IO.FileStream f = System.IO.File.Create(path);
                f.Close();
            }

            try
            {
                //替换文件内容 
                //FileStream stream2 = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
                //stream2.Seek(0, SeekOrigin.Begin);
                //stream2.SetLength(0); //清空txt文件
                //stream2.Close();
                File.WriteAllLines(path, new string[] { str });
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 读取文件全部内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadTxt(string path)
        {
            string resVal = "";
            if (!string.IsNullOrEmpty(path)&&File.Exists(path))
            {
                StreamReader f2 = new StreamReader(path, System.Text.Encoding.GetEncoding("gb2312"));
                resVal = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }
            return resVal;
        }
    }   
}