using System;

namespace CommandPattern
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);

    }
}
