using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tachocline.Data
{
    public abstract class TupleToDataRecordProjector : IDataRecord
    {
        public object this[int i] => Tuple[i];

        public object this[string name] => throw new NotSupportedException();

        public virtual int FieldCount => Tuple.Length;

        public bool GetBoolean(int i) => (bool)Tuple[i];

        public byte GetByte(int i) => (byte)Tuple[i];

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public char GetChar(int i) => (char)Tuple[i];

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => throw new NotSupportedException();

        public IDataReader GetData(int i) => throw new NotSupportedException();

        public string GetDataTypeName(int i) => Tuple[i].GetType().Name;

        public DateTime GetDateTime(int i) => (DateTime)Tuple[i];

        public decimal GetDecimal(int i) => (decimal)Tuple[i];

        public double GetDouble(int i) => (double)Tuple[i];

        public Type GetFieldType(int i) => Tuple[i].GetType();

        public float GetFloat(int i) => (float)Tuple[i];

        public Guid GetGuid(int i) => (Guid)Tuple[i];

        public short GetInt16(int i) => (short)Tuple[i];

        public int GetInt32(int i) => (int)Tuple[i];

        public long GetInt64(int i) => (long)Tuple[i];

        public string GetName(int i) => throw new NotSupportedException();

        public int GetOrdinal(string name) => throw new NotSupportedException();

        public string GetString(int i) => (string)Tuple[i];

        public object GetValue(int i) => Tuple[i];

        public int GetValues(object[] values)
        {
            var current = Tuple;

            Debug.Assert(current.Length == values.Length);

            for (int i = 0; i < current.Length; i++)
            {
                values[i] = current[i];
            };

            return current.Length;
        }

        public bool IsDBNull(int i) => Tuple[i] == DBNull.Value;

        public ITuple Tuple { get; set; }
    }
}
