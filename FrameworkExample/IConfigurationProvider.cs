using System;

namespace FrameworkExample
{
    public interface IConfigurationProvider
    {
        string Uri { get; }
        string Browser { get; }
        TimeSpan Timeout { get; }
    }
}