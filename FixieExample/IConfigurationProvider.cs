using System;

namespace FixieExample
{
    public interface IConfigurationProvider
    {
        string Uri { get; }
        string Browser { get; }
        TimeSpan Timeout { get; }
    }
}