using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Contracts.ContractModel
{
    public class DocumentContractModel
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Data { get; set; }
        public byte[] DataByteArray { get; set; }
        public string Username { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? LastDownloadDate { get; set; }
    }
}
