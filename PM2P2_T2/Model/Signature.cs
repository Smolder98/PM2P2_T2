using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2P2_T2.Model
{
    public class Signature
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] ArrayByteImage { get; set; }
    }
}
