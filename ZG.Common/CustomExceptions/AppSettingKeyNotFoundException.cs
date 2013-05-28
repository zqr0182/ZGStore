using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.CustomExceptions
{
    [Serializable]
    public class AppSettingKeyNotFoundException : Exception
    {
        private readonly DateTime _exceptionDateTime; //just for testing the Serialization part of the class.

        public AppSettingKeyNotFoundException()
            : base() { }

        public AppSettingKeyNotFoundException(string message)
            : base(message) { }

        public AppSettingKeyNotFoundException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AppSettingKeyNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public AppSettingKeyNotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected AppSettingKeyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                _exceptionDateTime = info.GetDateTime("ExceptionDateTime");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("ExceptionDateTime", _exceptionDateTime);
            }
        }
    }
}
