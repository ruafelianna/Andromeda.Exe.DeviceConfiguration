using System;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.Exceptions
{
    public class EntityBuilderException : ApplicationException
    {
        public EntityBuilderException(
            string? message = DefaultMessage,
            Exception? innerException = null
        ) :
            base(message, innerException)
        {
        }

        private const string DefaultMessage
            = "Entity builder exception has occured";
    }
}
