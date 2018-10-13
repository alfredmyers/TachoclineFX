using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tachocline.Data
{
    public sealed class TupleSequenceDataReader : TupleToDataRecordProjector, IDataReader
    {
        private IEnumerator<ITuple> _iterator;

        public TupleSequenceDataReader(IEnumerable<ITuple> sequence, int fieldCount)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            _iterator = sequence.GetEnumerator();
            FieldCount = fieldCount;
        }

        public int Depth => 0;

        public bool IsClosed => _iterator is null;

        public int RecordsAffected => -1;

        public void Close() => Dispose();

        public void Dispose()
        {
            _iterator.Dispose();
            _iterator = null;
            GC.SuppressFinalize(this);
        }

        public override int FieldCount { get; }

        public bool NextResult()
        {
            throw new NotSupportedException();
        }

        public bool Read()
        {
            if (_iterator is null)
            {
                throw new ObjectDisposedException(nameof(_iterator));
            }

            var moved = _iterator.MoveNext();

            Tuple = moved ? _iterator.Current : null;

            return moved;
        }

        public DataTable GetSchemaTable() => throw new NotSupportedException();
    }
}
