using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Tachocline.IO
{
    public class StreamEnumerable : IEnumerable<String>
    {
        private readonly Stream _stream;

        public StreamEnumerable(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream isn't readable", nameof(stream));
            }
            if (!stream.CanSeek)
            {
                throw new ArgumentException("Stream isn't seekable", nameof(stream));
            }
            _stream = stream;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StreamEnumerator(new StreamReader(_stream));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public sealed class StreamEnumerator : IEnumerator<string>
        {
            private readonly StreamReader _streamReader;
            private string _current;

            internal StreamEnumerator(StreamReader streamReader)
            {
                _streamReader = streamReader;
            }

            public string Current => _current;

            object IEnumerator.Current => _current;

            public void Dispose()
            {
                _streamReader.Dispose();
            }

            public bool MoveNext()
            {
                _current = _streamReader.ReadLine();
                return _current != null;
            }

            public void Reset()
            {
                var stream = _streamReader.BaseStream;
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}
