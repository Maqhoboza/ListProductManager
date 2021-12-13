using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListProdManager.Models
{
    public class MyFile
    {
        public int MyFileId { get; set; }
        public byte[] FileContent { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}
