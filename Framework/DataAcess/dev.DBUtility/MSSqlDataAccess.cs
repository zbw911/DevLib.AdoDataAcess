// ***********************************************************************************
// Created by zbw911 
// �����ڣ�2012��12��18�� 10:44
// 
// �޸��ڣ�2013��02��18�� 18:24
// �ļ�����MSSqlDataAccess.cs
// 
// ����и��õĽ����������ʼ���zbw911#gmail.com
// ***********************************************************************************
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Dev.Log;

namespace Dev.DBUtility
{
    /// <summary>
    /// SQL SERVER ���ݿ������
    /// </summary>
    public sealed class MSSqlDataAccess : AbstractDataAccess
    {
        //private SqlConnection m_DbConnection;
        //private SqlTransaction trans;

        /// <summary>
        /// ͨ�����ӽ��й���
        /// </summary>
        /// <param name="conn"></param>
        public MSSqlDataAccess(SqlConnection conn)
        {
            trans = null;
            m_DbConnection = conn;
        }

        /// <summary>
        /// ͨ�����ݿ����Ӵ����й���ķ���
        /// </summary>
        /// <param name="connectionString"></param>
        public MSSqlDataAccess(string connectionString)
        {
            trans = null;
            m_DbConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// ���ݿ������
        /// </summary>
        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.MSSQLServer; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public override IDbConnection DbConnection
        {
            get { return m_DbConnection; }
        }


        /// <summary>
        /// �������ݼ�,Ҫ���ⲿ�������ݼ� ( ds = new dataset()) �Ĵ���
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override DataSet ExecuteDataset(CommandType commandType, string commandText,
                                               QueryParameterCollection commandParameters, DataSet ds, string tableName)
        {
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, commandText, commandParameters);
                var adapter = new SqlDataAdapter(cmd);
                if (Equals(tableName, null) || (tableName.Length < 1))
                {
                    adapter.Fill(ds);
                }
                else
                {
                    adapter.Fill(ds, tableName);
                }
                base.SyncParameter(commandParameters);
                cmd.Parameters.Clear();
                return ds;
            }
            catch
            {
                exceptioned = true;
                throw;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public override int ExecuteNonQuery(CommandType commandType, string commandText,
                                            QueryParameterCollection commandParameters)
        {
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, commandText, commandParameters);
                int num = cmd.ExecuteNonQuery();
                base.SyncParameter(commandParameters);
                cmd.Parameters.Clear();
                return num;
            }
            catch
            {
                exceptioned = true;
                throw;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// READER
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public override IDataReader ExecuteReader(CommandType commandType, string commandText,
                                                  QueryParameterCollection commandParameters)
        {
            var cmd = new SqlCommand();
            PrepareCommand(cmd, commandType, commandText, commandParameters);
            SqlDataReader reader = cmd.ExecuteReader();
            base.SyncParameter(commandParameters);
            cmd.Parameters.Clear();
            return reader;
        }


        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public override object ExecuteScalar(CommandType commandType, string commandText,
                                             QueryParameterCollection commandParameters)
        {
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, commandText, commandParameters);
                object obj2 = cmd.ExecuteScalar();
                base.SyncParameter(commandParameters);
                cmd.Parameters.Clear();
                return obj2;
            }
            catch
            {
                //if (trans != null)
                //{
                //    RollbackTransaction();
                //}

                exceptioned = true;
                throw;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ExecuteXmlReader
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public override XmlReader ExecuteXmlReader(CommandType commandType, string commandText,
                                                   QueryParameterCollection commandParameters)
        {
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, commandType, commandText, commandParameters);
                XmlReader reader = cmd.ExecuteXmlReader();
                base.SyncParameter(commandParameters);
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //if (trans != null)
                //{
                //    RollbackTransaction();
                //}

                exceptioned = true;
                throw;
            }
            finally
            {
                Close();
            }
        }


        /// <summary>
        /// ����׼��
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        private void PrepareCommand(SqlCommand cmd, CommandType commandType, string commandText,
                                    QueryParameterCollection commandParameters)
        {
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.Connection = (SqlConnection)m_DbConnection;
            cmd.Transaction = (SqlTransaction)trans;


            if (commandText.IndexOf("''") >= 0)
            {
                var blankname = "@____blankchar_______";
                commandText = commandText.Replace("''", blankname);

                if (commandParameters == null) commandParameters = new QueryParameterCollection();

                commandParameters.Add(blankname, "");
            }


            if ((commandParameters != null) && (commandParameters.Count > 0))
            {
                for (int i = 0; i < commandParameters.Count; i++)
                {
                    commandParameters[i].InitRealParameter(DatabaseType.MSSQLServer);
                    cmd.Parameters.Add(commandParameters[i].RealParameter as SqlParameter);
                }
            }

            Open();

            //if (this.checkSQL)
            //{
            string notallow = string.Empty;
            //���е�ִ�з�ʽ���������������洢���̺�SQL���
            //if (CheckSQL.CheckSQLText(commandParameters, out notallow) <= 0) //������в���������ݣ�����ǿ�����Աд�ģ����дsql����д�洢����ʵ��
            //{
            //    Dev.Log.Loger.Error("sql����в�������֣�" + notallow);

            //    throw new Exception("���ݸ�ʽ����ȷ������");
            //}
            //}

            //if (this.checkParms)
            //{
            //string notallow;
            if (!commandType.Equals(CommandType.StoredProcedure) && CheckSQL.CheckSQLText(commandText, out notallow) <= 0)
            //������в���������ݣ�����ǿ�����Աд�ģ����дsql����д�洢����ʵ��
            {
                Loger.Error("sql����в�������֣�" + notallow);

                throw new Exception("���ݸ�ʽ����ȷ������ע���ַ�" + notallow);
            }
            //}


            //DBLog.AddLog("", commandType, commandText, commandParameters);
        }
    }
}