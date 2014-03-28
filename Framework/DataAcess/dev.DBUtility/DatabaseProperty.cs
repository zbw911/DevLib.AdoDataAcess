// ***********************************************************************************
// Created by zbw911 
// �����ڣ�2012��12��18�� 10:44
// 
// �޸��ڣ�2013��02��18�� 18:24
// �ļ�����DatabaseProperty.cs
// 
// ����и��õĽ����������ʼ���zbw911#gmail.com
// ***********************************************************************************
using System.Runtime.InteropServices;

namespace Dev.DBUtility
{
    /// <summary>
    /// ���ݿ�����
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DatabaseProperty
    {
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Password { get; set; }
    }
}