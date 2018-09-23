using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Tachocline.Data
{
    public abstract class ListToDataRecordProjector : IDataRecord
    {
        public object this[int i] => List[i];

        public object this[string name] => throw new NotSupportedException();

        public virtual int FieldCount => List.Count;

        public bool GetBoolean(int i) => (bool)List[i];

        public byte GetByte(int i) => (byte)List[i];

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public char GetChar(int i) => (char)List[i];

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public IDataReader GetData(int i) => throw new NotSupportedException();

        public string GetDataTypeName(int i) => List[i].GetType().Name;

        public DateTime GetDateTime(int i) => (DateTime)List[i];

        public decimal GetDecimal(int i) => (decimal)List[i];

        public double GetDouble(int i) => (double)List[i];

        public Type GetFieldType(int i) => List[i].GetType();

        public float GetFloat(int i) => (float)List[i];

        public Guid GetGuid(int i) => (Guid)List[i];

        public short GetInt16(int i) => (short)List[i];

        public int GetInt32(int i) => (int)List[i];

        public long GetInt64(int i) => (long)List[i];

        public string GetName(int i) => throw new NotSupportedException();

        public int GetOrdinal(string name) => throw new NotSupportedException();

        public string GetString(int i) => (string)List[i];

        public object GetValue(int i) => List[i];

        public int GetValues(object[] values)
        {
            var current = List;

            Debug.Assert(current.Count == values.Length);

            current.CopyTo(values, 0);

            return current.Count;
        }

        public bool IsDBNull(int i) => List[i] == DBNull.Value;

        public IList List { get; set; }
    }
}
