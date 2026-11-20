using AutoFixture.Xunit3;
using Kanadeiar.Common.Tests;

namespace Kanadeiar.Common.Tests;

public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] objects)
        : base(new AutoMoqDataAttribute(), objects) { }
}

