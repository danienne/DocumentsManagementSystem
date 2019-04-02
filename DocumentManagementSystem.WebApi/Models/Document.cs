using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.WebApi.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }
        public string Username { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? LastDownloadDate { get; set; }
    }
}