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


        public async Task<List<Signature>> GetSignatures()
        {
            return await App.DBase.getListSignature();
        }


    }
}
