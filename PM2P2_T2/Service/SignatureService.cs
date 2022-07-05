using Plugin.Media.Abstractions;
using PM2P2_T2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PM2P2_T2.Service
{
    public class SignatureService
    {


        public async Task<bool> saveSignatures(Signature signature)
        {
            var result = await App.DBase.insertUpdateSignature(signature);

            return (result > 0);

        }
        private static Byte[] ConvertImageToByteArray(MediaFile FileFoto)
        {
            if (FileFoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = FileFoto.GetStream();

                    stream.CopyTo(memory);

                    return memory.ToArray();
                }
            }

            return null;
        }

    }
}
