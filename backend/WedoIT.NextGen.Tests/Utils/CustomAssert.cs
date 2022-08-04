using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

namespace WedoIT.NextGen.Tests.Utils;

[ExcludeFromCodeCoverage]
public static class CustomAssert
{
    public static void Pass()
    {
    }

    public static void Fail(string message)
    {
        throw new XunitException(message);
    }
}