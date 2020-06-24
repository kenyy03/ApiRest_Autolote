using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Injection
{
    public interface IClassType
    {
        Type GetInterface();
        Type GetClass();
    }
}
