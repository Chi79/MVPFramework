using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Structs
{

    public struct LoginResponse
    {

        public int ClientType;

        public string ClientEmail;

        public bool CredentialsApproved;

    }

    public struct SaveResult
    {

        public string ErrorMessage;

        public int Result;

    }
}
