using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Contracts.ContractModel
{
    public class UserContractModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
