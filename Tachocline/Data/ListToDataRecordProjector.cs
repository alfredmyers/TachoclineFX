using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Tachocline.Data
{
    internal sealed class ListToDataRecordProjector : IDataRecord
    {
        private IList _list;

        public ListToDataRecordProjector() { }
        
        public ListToDataRecordProjector(IList list) => _list = list ?? throw new ArgumentNullException(nameof(list));

        public object this[int i] => _list[i];

        public object this[string name] => throw new NotSupportedException();

        public int FieldCount => _list.Count;

        public bool GetBoolean(int i) => (bool)_list[i];

        public byte GetByte(int i) => (byte)_list[i];

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public char GetChar(int i) => (char)_list[i];

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public IDataReader GetData(int i) => throw new NotSupportedException();

        public string GetDataTypeName(int i) => throw new NotSupportedException();

        public DateTime GetDateTime(int i) => (DateTime)_list[i];

        public decimal GetDecimal(int i) => (decimal)_list[i];

        public double GetDouble(int i) => (double)_list[i];

        public Type GetFieldType(int i) => _list[i].GetType();

        public float GetFloat(int i) => (float)_list[i];

        public Guid GetGuid(int i) => (Guid)_list[i];

        public short GetInt16(int i) => (short)_list[i];

        public int GetInt32(int i) => (int)_list[i];

        public long GetInt64(int i) => (long)_list[i];

        public string GetName(int i) => throw new NotSupportedException();

        public int GetOrdinal(string name) => throw new NotSupportedException();

        public string GetString(int i) => (string)_list[i];

        public object GetValue(int i) => _list[i];

        public int GetValues(object[] values)
        {
            var current = _list;

            Debug.Assert(current.Count == values.Length);

            current.CopyTo(values, 0);

            return current.Count;
        }

        public bool IsDBNull(int i) => _list[i] == DBNull.Value;

        public IList List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
