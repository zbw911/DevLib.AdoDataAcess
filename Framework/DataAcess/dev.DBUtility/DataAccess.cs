// ***********************************************************************************
// Created by zbw911 
// �����ڣ�2012��12��18�� 10:44
// 
// �޸��ڣ�2013��02��18�� 18:24
// �ļ�����DataAccess.cs
// 
// ����и��õĽ����������ʼ���zbw911#gmail.com
// ***********************************************************************************
using System;
using System.Data;
using System.Xml;

namespace Dev.DBUtility
{
    /// <summary>
    /// ���ݷ��ʽӿ�
    /// </summary>
    public interface IDataAccess : IDisposable
    {
        /// <summary>
        /// ��������
        /// </summary>
        DatabaseType DatabaseType { get; }

        /// <summary>
        ///���ݿ�����
        /// </summary>
        IDbConnection DbConnection { get; }

        /// <summary>
        /// �����Ƿ�ر�
        /// </summary>
        bool IsClosed { get; }

        /// <summary>
        /// ָʾ�Ƿ����SQLע����,��ʹ�ñ�������ʱ��1����ʹ�õĲ���ƴװ��SQL
        /// </summary>
        /// <param name="checkSql"></param>
        /// <returns></returns>
        /// 
        IDataAccess UseCheckSQL(bool checkSql);

        /// <summary>
        /// �Ƿ������
        /// </summary>
        /// <param name="checkParms"></param>
        /// <returns></returns>
        IDataAccess UseCheckParms(bool checkParms);

        /// <summary>
        /// �Զ��ر�,������Ҫ��ʾ�رջ��� using {} ����ʹ��
        /// </summary>
        /// <returns></returns>
        IDataAccess KeepOpen(bool keep = true);

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        IDataAccess BeginTransaction();

        /// <summary>
        /// �ύ����
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// �ع�����
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// �ر�����
        /// </summary>
        void Close();

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        void Open();

        #region ExecuteDataset

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, DataSet ds);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, DataSet ds);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, QueryParameterCollection commandParameters, DataSet ds);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, QueryParameterCollection commandParameters, string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, DataSet ds, string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, QueryParameterCollection commandParameters,
                               DataSet ds);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, QueryParameterCollection commandParameters,
                               string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, DataSet ds, string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(string commandText, QueryParameterCollection commandParameters, DataSet ds,
                               string tableName);

        /// <summary>
        /// ִ�в������� , DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataSet ExecuteDataset(CommandType commandType, string commandText, QueryParameterCollection commandParameters,
                               DataSet ds, string tableName);

        #endregion

        #region NonQuery

        /// <summary>
        /// ִ��NonQuery ����Ӱ������
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText);

        /// <summary>
        /// ִ��NonQuery ����Ӱ������
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        int ExecuteNonQuery(CommandType commandType, string commandText);

        /// <summary>
        /// ִ��NonQuery ����Ӱ������
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        /// /ִ��NonQuery ����Ӱ������
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery(CommandType commandType, string commandText, QueryParameterCollection commandParameters);

        #endregion

        #region Ҫ�ֶ��ر����ӵ�Reader

        /// <summary>
        /// ִ��Reader ���� IDataReader , Ҫ�ֶ��ر�����
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string commandText);

        /// <summary>
        /// ִ��Reader ���� IDataReader , Ҫ�ֶ��ر�����
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(CommandType commandType, string commandText);

        /// <summary>
        ///  ִ��Reader ���� IDataReader , Ҫ�ֶ��ر�����
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        ///  ִ��Reader ���� IDataReader , Ҫ�ֶ��ر�����
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(CommandType commandType, string commandText,
                                  QueryParameterCollection commandParameters);

        #endregion

        #region �Զ��ر����ӵ�Reader

        /// <summary>
        /// ִ��Reader  ������Reader�Զ��رգ�Ҫʹ��  action �¼����д���
        /// </summary>
        /// <param name="commandText"></param>
        ///  <param name="action"></param>
        void ExecuteReader(Action<IDataReader> action, string commandText);

        /// <summary>
        /// ִ��Reader  ������Reader�Զ��رգ�Ҫʹ��  useReader �¼����д���
        /// </summary>
        /// <param name="commandType"></param>
        ///  <param name="action"></param>
        /// <param name="commandText"></param>
        void ExecuteReader(Action<IDataReader> action, CommandType commandType, string commandText);

        /// <summary>
        /// ִ��Reader  ������Reader�Զ��رգ�Ҫʹ��  useReader �¼����д���
        /// </summary>
        /// <param name="commandText"></param>
        ///   <param name="action"></param>
        /// <param name="commandParameters"></param>
        void ExecuteReader(Action<IDataReader> action, string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        ///  ִ��Reader  ������Reader�Զ��رգ�Ҫʹ��  useReader �¼����д���
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="action"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        void ExecuteReader(Action<IDataReader> action, CommandType commandType, string commandText,
                           QueryParameterCollection commandParameters);

        #endregion

        #region ExecuteScalar

        /// <summary>
        ///  ִ�� Scalar
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        object ExecuteScalar(string commandText);

        /// <summary>
        /// ִ�� Scalar
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        object ExecuteScalar(CommandType commandType, string commandText);

        /// <summary>
        /// ִ�� Scalar
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        object ExecuteScalar(string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        /// ִ�� Scalar
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        object ExecuteScalar(CommandType commandType, string commandText, QueryParameterCollection commandParameters);

        #endregion

        #region XmlReader

        /// <summary>
        /// ִ�� XmlReader Ҫ�ֶ��ر� READER
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        XmlReader ExecuteXmlReader(string commandText);

        /// <summary>
        /// ִ�� XmlReader , Ҫ�ֶ��ر� READER
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        XmlReader ExecuteXmlReader(CommandType commandType, string commandText);

        /// <summary>
        /// ִ�� XmlReader Ҫ�ֶ��ر� READER
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        XmlReader ExecuteXmlReader(string commandText, QueryParameterCollection commandParameters);

        /// <summary>
        /// ִ�� XmlReaderҪ�ֶ��ر� READER
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        XmlReader ExecuteXmlReader(CommandType commandType, string commandText,
                                   QueryParameterCollection commandParameters);

        #endregion
    }
}