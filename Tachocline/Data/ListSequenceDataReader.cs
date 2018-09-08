using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Tachocline.Data
{
    public sealed class ListSequenceDataReader : IDataReader
    {
        private IEnumerator<IList> _iterator;
        private readonly IEnumerable<IList> _sequence;

        public ListSequenceDataReader(IEnumerable<IList> sequence, int fieldCount)
        {
            _sequence = sequence ?? throw new ArgumentNullException(nameof(sequence));
            _iterator = sequence.GetEnumerator();
            FieldCount = fieldCount;
        }

        public int Depth => throw new NotSupportedException();

        public bool IsClosed => throw new NotSupportedException();

        public int RecordsAffected => throw new NotSupportedException();

        public void Close()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            _iterator.Dispose();
            GC.SuppressFinalize(this);
        }

        public object this[int i] => _iterator.Current[i];

        public object this[string name] => throw new NotSupportedException();

        public int FieldCount { get; }

        public bool GetBoolean(int i)
        {
            return (bool)_iterator.Current[i];
        }

        public byte GetByte(int i)
        {
            return (byte)_iterator.Current[i];
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }

        public char GetChar(int i)
        {
            return (char)_iterator.Current[i];
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotSupportedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotSupportedException();
        }

        public DateTime GetDateTime(int i)
        {
            return (DateTime)_iterator.Current[i];
        }

        public decimal GetDecimal(int i)
        {
            return (decimal)_iterator.Current[i];
        }

        public double GetDouble(int i)
        {
            return (double)_iterator.Current[i];
        }

        public Type GetFieldType(int i)
        {
            return _iterator.Current[i].GetType();
        }

        public float GetFloat(int i)
        {
            return (float)_iterator.Current[i];
        }

        public Guid GetGuid(int i)
        {
            return (Guid)_iterator.Current[i];
        }

        public short GetInt16(int i)
        {
            return (short)_iterator.Current[i];
        }

        public int GetInt32(int i)
        {
            return (int)_iterator.Current[i];
        }

        public long GetInt64(int i)
        {
            return (long)_iterator.Current[i];
        }

        public string GetName(int i)
        {
            throw new NotSupportedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotSupportedException();
        }

        public string GetString(int i)
        {
            return (string)_iterator.Current[i];
        }

        public object GetValue(int i)
        {
            return _iterator.Current[i];
        }

        public int GetValues(object[] values)
        {
            //TODO: Verificar o funcionamento do CopyTo
            var current = _iterator.Current;

            Debug.Assert(current.Count == values.Length);

            current.CopyTo(values, 0);
            
            return current.Count;
        }

        public bool IsDBNull(int i)
        {
            return _iterator.Current[i] == DBNull.Value;
        }

        public bool NextResult()
        {
            throw new NotSupportedException();
        }

        public bool Read()
        {
            return _iterator.MoveNext();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotSupportedException();
        }
    }
}
