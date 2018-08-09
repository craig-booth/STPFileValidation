using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace STPFileValidation
{
    class STPFile
    {
        private FileStream _STPFile;
        private STPFileBuffer _Buffer;


        public string DocumentId { get; private set; }
        public string DocumentType { get; private set; }
        public Stream DocumentStream { get; private set; }

        public STPFile(string fileName)
        {
            DocumentId = "";
            DocumentStream = null;

            _STPFile = File.Open(fileName, FileMode.Open);
            _Buffer = new STPFileBuffer(_STPFile, 32768);
        }

        public void Close()
        {
            _STPFile.Close();
        }

        public Stream GetChildDocument()
        {
            DocumentId = "";
            DocumentStream = null;

            // Locate the record delimiter
            if (!_Buffer.PositionToString("<Record_Delimiter"))
                return null;

            var text = _Buffer.GetBufferText(200);

            // Locate the end of the record delimiter
            if (!_Buffer.PositionToString("/>"))
                return null;

            DocumentId = GetAttribute("DocumentID", text);
            DocumentType = GetAttribute("DocumentName", text);

            return new STPStream(_Buffer);
        }

        private string GetAttribute(string name, string text)
        {
            var start = text.IndexOf(" " + name + "=");
            if (start == -1)
                return "";

            start = text.IndexOf('"', start);
            if (start == -1)
                return "";
            start++;

            var end = text.IndexOf('"', start);
            if (end == -1)
                return "";

            return text.Substring(start, end - start);
        }
    }

    class STPFileBuffer
    {
        public int Size { get; private set; }

        private byte[] _Bytes;

        private Stream _Stream;

        private int _Offset;
        private int _BytesInBuffer;


        public STPFileBuffer(Stream stream, int size)
        {
            Size = size;
            _Bytes = new byte[Size];
            _Stream = stream;
            _Offset = 0;
            _BytesInBuffer = 0;
        }

        public string GetBufferText()
        {
            var bytesAvailable = _BytesInBuffer - _Offset;
            return GetBufferText(bytesAvailable);
        }

        public string GetBufferText(int length)
        {
            var bytesAvailable = _BytesInBuffer - _Offset;
            if (bytesAvailable < length)
                FillBuffer();

            bytesAvailable = _BytesInBuffer - _Offset;

            return System.Text.Encoding.UTF8.GetString(_Bytes, _Offset, Math.Min(length, bytesAvailable));
        }

        public bool PositionToString(string value)
        {
            var bytesAvailable = _BytesInBuffer - _Offset;

            if (bytesAvailable < value.Length)
                FillBuffer();

            bytesAvailable = _BytesInBuffer - _Offset;
            if (bytesAvailable < value.Length)
                return false;

            var position = -1;
            while (position < 0)
            {
                var text = GetBufferText();
                position = text.IndexOf(value);
                if (position < 0)
                {
                    _Offset = _BytesInBuffer - value.Length;
                    if (FillBuffer() == 0)
                        return false;
                }
            }

            _Offset += position + value.Length;

            return true; 
        }

        public int ReadToString(byte[] buffer, int offset, int count, string value)
        {
            var bytesRead = 0;
            var bytesToCopy = 0;

            var bytesAvailable = _BytesInBuffer - _Offset;
            if (bytesAvailable < value.Length * 2)
                FillBuffer();

            bytesAvailable = _BytesInBuffer - _Offset;
            if (bytesAvailable < value.Length)
            {
                bytesToCopy = Math.Min(count, bytesAvailable);
                System.Buffer.BlockCopy(_Bytes, _Offset, buffer, offset, bytesToCopy);
                _Offset += bytesToCopy;
                return bytesToCopy;
            }
            else
            {
                var text = GetBufferText();
                var position = text.IndexOf(value);
                if (position >= 0)
                {
                    bytesToCopy = Math.Min(count, position);
                    System.Buffer.BlockCopy(_Bytes, _Offset, buffer, offset, bytesToCopy);
                    _Offset += bytesToCopy;
                    return bytesToCopy;
                }

                if (bytesAvailable > value.Length)
                    bytesToCopy = Math.Min(count, bytesAvailable - value.Length);
                else
                    bytesToCopy = Math.Min(count, bytesAvailable);
                System.Buffer.BlockCopy(_Bytes, _Offset, buffer, offset, bytesToCopy);
                _Offset += bytesToCopy;
                bytesRead += bytesToCopy;


                var xx = System.Text.Encoding.UTF8.GetString(_Bytes, 0, bytesRead);

                var bytesRemaining = count - bytesRead;
                if (bytesRemaining > 0)
                    bytesRead += ReadToString(buffer, offset + bytesRead, bytesRemaining, value);
            }

            return bytesRead;
        }

        private int FillBuffer()
        {
            var bytesRead = 0;

            if (_Offset >= _BytesInBuffer)
            {
                bytesRead = _Stream.Read(_Bytes, 0, Size);
                _BytesInBuffer = bytesRead;
                _Offset = 0;
            }
            else
            {
                var bytesRemaining = _BytesInBuffer - _Offset;
                System.Buffer.BlockCopy(_Bytes, _Offset, _Bytes, 0, bytesRemaining);
                _BytesInBuffer = bytesRemaining;
                _Offset = bytesRemaining;

                bytesRead = _Stream.Read(_Bytes, _Offset, Size - _BytesInBuffer);
                _BytesInBuffer += bytesRead;
                _Offset = 0;
            }
            

            return bytesRead;
        }
    }
}
