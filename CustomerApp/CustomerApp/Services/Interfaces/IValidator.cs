using System.Collections.Generic;

namespace CustomerApp.Services.Interfaces
{
    interface IValidator<T>
    {
        IEnumerable<string> Validate(T item);
    }
}
