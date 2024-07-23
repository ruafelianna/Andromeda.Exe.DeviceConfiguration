using Andromeda.Exe.DeviceConfiguration.Data.Models.Exceptions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.Builder
{
    public abstract class EntityBuilderBase<TSelf, T>
        where TSelf : EntityBuilderBase<TSelf, T>
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

        protected readonly HashSet<string> RequiredMethods;

        protected abstract T CreateObj();

        protected abstract void ValidateObj();

        protected abstract void AddRequiredMethods();

        protected void MethodCalled([CallerMemberName]string? name = null)
            => RequiredMethods.Remove(name!);
    }
}
