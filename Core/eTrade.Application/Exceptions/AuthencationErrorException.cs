using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Application.Exceptions
{
    public class AuthencationErrorException : Exception
    {
        public AuthencationErrorException(): base("Kullanıcı ya da Kimlik Doğrulama Hatası")
        {
        }

        public AuthencationErrorException(string? message) : base(message)
        {
        }

        protected AuthencationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
