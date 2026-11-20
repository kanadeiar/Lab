using ConsoleApp1.QuestionnaireModule;
using Kanadeiar.Common.Tests;

namespace ConsoleApp1Tests.QuestionnaireModule;

public class QuestionnaireTests
{
    [Theory(DisplayName = "Проверка создания вопросника с заполнением его вопросами")]
    [AutoMoqData]
    public void TestShouldBeCreate(string expectedName, string expectedSurName, int exprecedAge)
    {
        var questionnaire = new Questionnaire(expectedName, expectedSurName, exprecedAge);

        questionnaire.Name.Should().Be(expectedName);
        questionnaire.SurName.Should().Be(expectedSurName);
        questionnaire.Age.Should().Be(exprecedAge);
    }

    [Theory]
    [InlineAutoData("name", "surName", 5)]
    public void TestGetText_GluedLine(string expectedName, string expectedSurName, int exprecedAge)
    {
        var sut = new Questionnaire(expectedName, expectedSurName, exprecedAge);

        var actual = sut.GetText(TextFormatCode.GluedLine);

        actual.Should().Be("surName name 5 лет");
    }

    [Theory]
    [InlineAutoData("name", "surName", 5)]
    public void TestGetText_Formatted(string expectedName, string expectedSurName, int exprecedAge)
    {
        var sut = new Questionnaire(expectedName, expectedSurName, exprecedAge);

        var actual = sut.GetText(TextFormatCode.Formatted);

        actual.Should().Be("surName name 5 лет");
    }

    [Theory]
    [InlineAutoData("name", "surName", 5)]
    public void TestGetText_Interpolated(string expectedName, string expectedSurName, int exprecedAge)
    {
        var sut = new Questionnaire(expectedName, expectedSurName, exprecedAge);

        var actual = sut.GetText(TextFormatCode.Interpolated);

        actual.Should().Be("surName name 5 лет");
    }
}
