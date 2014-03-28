// ***********************************************************************************
// Created by zbw911 
// �����ڣ�2012��12��18�� 10:44
// 
// �޸��ڣ�2013��02��18�� 18:24
// �ļ�����QueryParameterCollection.cs
// 
// ����и��õĽ����������ʼ���zbw911#gmail.com
// ***********************************************************************************
using System;
using System.Collections;
using System.Data;

namespace Dev.DBUtility
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class QueryParameterCollection : MarshalByRefObject, IEnumerable
    {
        private readonly int intitialCapacity;
        private ArrayList items;

        /// <summary>
        /// �����������,Ĭ��10��
        /// </summary>
        public QueryParameterCollection()
        {
            intitialCapacity = 10;
        }

        /// <summary>
        /// �����������,�����ø���
        /// </summary>
        /// <param name="initCapacity"></param>
        public QueryParameterCollection(int initCapacity)
        {
            intitialCapacity = 10;
            intitialCapacity = initCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                if (items == null)
                {
                    return 0;
                }
                return items.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        public QueryParameter this[string ParameterName]
        {
            get
            {
                int num = RangeCheck(ParameterName);
                return (QueryParameter) items[num];
            }
            set
            {
                int index = RangeCheck(ParameterName);
                Replace(index, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public QueryParameter this[int index]
        {
            get
            {
                RangeCheck(index);
                return (QueryParameter) items[index];
            }
            set
            {
                RangeCheck(index);
                Replace(index, value);
            }
        }

        #region IEnumerable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ArrayList().GetEnumerator(); // items.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public QueryParameter Add(QueryParameter param)
        {
            ArrayList().Add(param);
            return param;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public QueryParameter Add(string ParameterName, object Value)
        {
            return Add(new QueryParameter(ParameterName, Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="Value"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public QueryParameter Add(string ParameterName, object Value, DbType dbType)
        {
            return Add(new QueryParameter(ParameterName, Value, dbType));
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public QueryParameter Add(string parameterName, DbType dbType, int size, object Value)
        {
            return Add(new QueryParameter(parameterName, dbType, size, Value));
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public QueryParameter Add(string ParameterName, DbType dbType, ParameterDirection direction, object Value)
        {
            return Add(new QueryParameter(ParameterName, dbType, direction, Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ArrayList ArrayList()
        {
            if (items == null)
            {
                items = new ArrayList(intitialCapacity);
            }
            return items;
        }

        /// <summary>
        /// �������
        /// </summary>
        public void Clear()
        {
            ArrayList().Clear();
        }

        /// <summary>
        /// ����˵��.
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        public int IndexOf(string ParameterName)
        {
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (((QueryParameter) items[i]).ParameterName.Equals(ParameterName))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="index"></param>
        private void RangeCheck(int index)
        {
            if ((index < 0) || (Count <= index))
            {
                throw new IndexOutOfRangeException("Number " + index.ToString() + " is out of Range");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        private int RangeCheck(string ParameterName)
        {
            int index = IndexOf(ParameterName);
            if (index < 0)
            {
                throw new IndexOutOfRangeException("ParameterName " + ParameterName + " dose not exist");
            }
            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        private void Replace(int index, QueryParameter newValue)
        {
            Validate(index, newValue);
            items[index] = newValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="Value"></param>
        private void Validate(int index, QueryParameter Value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        private void ValidateType(object Value)
        {
        }
    }
}