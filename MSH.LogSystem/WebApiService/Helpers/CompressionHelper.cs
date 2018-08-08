using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using Ionic.Zlib;

namespace WebApiService.Helpers
{
    public class CompressionHelper
    {
        public static byte[] DeflateByte(byte[] str)
        {
            if (str == null)
                return null;

            using (var output = new MemoryStream())
            {
                using (var compressor = new Ionic.Zlib.GZipStream(output, Ionic.Zlib.CompressionMode.Compress, Ionic.Zlib.CompressionLevel.BestSpeed))
                {
                    compressor.Write(str, 0, str.Length);
                }
                return output.ToArray();
            }
        }
    }
}