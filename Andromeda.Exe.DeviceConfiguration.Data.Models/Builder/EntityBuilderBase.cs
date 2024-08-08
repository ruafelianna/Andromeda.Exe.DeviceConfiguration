using Andromeda.Exe.DeviceConfiguration.Data.Models.Exceptions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.Builder
{
    public abstract class EntityBuilderBase<T>
    {
        protected EntityBuilderBase()
        {
            RequiredMethods = [];
            _obj = CreateObj();
        }

        internal T Build()
        {
            if (RequiredMethods.Count > 0)
            {
                throw new EntityBuilderException("Not all required methods were called");
            }

            ValidateObj();

            return _obj;
        }

        protected readonly T _obj;

        protected HashSet<string> RequiredMethods { get; }

        protected abstract T CreateObj();

        protected virtual void ValidateObj() { }

        protected void MethodCalled([CallerMemberName]string? name = null)
            => RequiredMethods.Remove(name!);
    }
}
