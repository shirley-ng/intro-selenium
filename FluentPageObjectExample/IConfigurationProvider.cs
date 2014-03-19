using System;

namespace FluentPageObjectExample
{
    public interface IConfigurationProvider
    {
        string Uri { get; }
        string Browser { get; }
        TimeSpan Timeout { get; }
    }
}