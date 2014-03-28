// ***********************************************************************************
// Created by zbw911 
// �����ڣ�2012��12��18�� 10:44
// 
// �޸��ڣ�2013��02��18�� 18:24
// �ļ�����DataAccessFactory.cs
// 
// ����и��õĽ����������ʼ���zbw911#gmail.com
// ***********************************************************************************
using System.Configuration;

namespace Dev.DBUtility
{
    /// <summary>
    /// ���ݿ���ʹ���
    /// </summary>
    public sealed class DataAccessFactory
    {
        private static DatabaseProperty _defaultDatabaseProperty;

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static readonly string ConnDatabaseType = ConfigurationManager.AppSettings["DatabaseType"];

        /// <summary>
        /// ���ݿ������ַ���ǰ̨
        /// </summary>
        public static readonly string DBConnString = ConfigurationManager.ConnectionStrings["connectionString"] != null
                                                         ? ConfigurationManager.ConnectionStrings["connectionString"].
                                                               ConnectionString
                                                         : "";

        /// <summary>
        /// ���ݿ������ַ���2
        /// </summary>
        public static readonly string DBConnString2 = ConfigurationManager.ConnectionStrings["connectionString2"] !=
                                                      null
                                                          ? ConfigurationManager.ConnectionStrings["connectionString2"].
                                                                ConnectionString
                                                          : "";

        /// <summary>
        /// ���ݿ������ַ���3
        /// </summary>
        public static readonly string DBConnString3 = ConfigurationManager.ConnectionStrings["connectionString3"] !=
                                                      null
                                                          ? ConfigurationManager.ConnectionStrings["connectionString3"].
                                                                ConnectionString
                                                          : "";

        /// <summary>
        /// ���ݿ������ַ���4
        /// </summary>
        public static readonly string DBConnString4 = ConfigurationManager.ConnectionStrings["connectionString4"] !=
                                                      null
                                                          ? ConfigurationManager.ConnectionStrings["connectionString4"].
                                                                ConnectionString
                                                          : "";

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        private static DatabaseProperty DefaultDatabaseProperty
        {
            get { return _defaultDatabaseProperty; }
            set { _defaultDatabaseProperty = value; }
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public static IDataAccess CreateDataAccess()
        {
            _defaultDatabaseProperty.ConnectionString = DBConnString;
            string connDatabaseType = ConnDatabaseType;


            DatabaseType dbt;
            switch (connDatabaseType)
            {
                case null:
                    {
                        dbt = DatabaseType.MSSQLServer;
                        break;
                    }
                case "":
                    {
                        dbt = DatabaseType.MSSQLServer;
                        break;
                    }
                case "Sql":
                    {
                        dbt = DatabaseType.MSSQLServer;
                        break;
                    }
                case "Ora":
                    {
                        dbt = DatabaseType.Oracle;
                        break;
                    }
                case "Ole":
                    {
                        dbt = DatabaseType.OleDBSupported;
                        break;
                    }
                default:
                    {
                        dbt = DatabaseType.MSSQLServer;
                        break;
                    }
            }
            _defaultDatabaseProperty.DatabaseType = dbt;
            return CreateDataAccess(_defaultDatabaseProperty);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="pp">���ݿ�����</param>
        /// <returns></returns>
        private static IDataAccess CreateDataAccess(DatabaseProperty pp)
        {
            switch (pp.DatabaseType)
            {
                case DatabaseType.MSSQLServer:
                    return new MSSqlDataAccess(pp.ConnectionString);

                case DatabaseType.Oracle:
                    return new OracleDataAccess(pp.ConnectionString);

                case DatabaseType.OleDBSupported:
                    return new OleDbDataAccess(pp.ConnectionString);
            }
            return new MSSqlDataAccess(pp.ConnectionString);
        }

        /// <summary>
        /// �������ݿ�ӿ�,Ĭ�ϵ��� MS-SQL
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public static IDataAccess CreateDataAccess(string ConnectionString)
        {
            var dp = new DatabaseProperty();
            dp.DatabaseType = DatabaseType.MSSQLServer;
            dp.ConnectionString = ConnectionString;

            return CreateDataAccess(dp);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="DBType"></param>
        /// <param name="DBConnStr"></param>
        /// <returns></returns>
        public static IDataAccess CreateDataAccess(string DBType, int DBConnStr)
        {
            switch (DBConnStr)
            {
                case 1:
                    _defaultDatabaseProperty.ConnectionString = DBConnString;
                    break;

                case 2:
                    _defaultDatabaseProperty.ConnectionString = DBConnString2;
                    break;

                case 3:
                    _defaultDatabaseProperty.ConnectionString = DBConnString3;
                    break;

                case 4:
                    _defaultDatabaseProperty.ConnectionString = DBConnString4;
                    break;

                default:
                    _defaultDatabaseProperty.ConnectionString = DBConnString;
                    break;
            }

            switch (DBType)
            {
                case "Sql":
                    {
                        _defaultDatabaseProperty.DatabaseType = DatabaseType.MSSQLServer;
                        break;
                    }
                case "Ora":
                    {
                        _defaultDatabaseProperty.DatabaseType = DatabaseType.Oracle;
                        break;
                    }
                case "Ole":
                    {
                        _defaultDatabaseProperty.DatabaseType = DatabaseType.OleDBSupported;
                        break;
                    }
                default:
                    {
                        _defaultDatabaseProperty.DatabaseType = DatabaseType.MSSQLServer;
                        break;
                    }
            }
            return CreateDataAccess(_defaultDatabaseProperty);
        }
    }
}