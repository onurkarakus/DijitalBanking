using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Utilities
{
    public interface ICryptographyUtility
    {
        public string CreateSalt();
        public string Encrypt(string textValue);
        public string EncryptWithSalt(string textValue, string salt);
        public bool Compare(string textValue, string salt, string encryptedValue);
    }
}
