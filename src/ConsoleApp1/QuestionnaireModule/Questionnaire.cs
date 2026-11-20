namespace ConsoleApp1.QuestionnaireModule;

public class Questionnaire
{
    public Questionnaire(string name, string surName, int age)
    {
        Name = name;
        SurName = surName;
        Age = age;
    }

    public string Name { get; }
    public string SurName { get; }
    public int Age { get; }

    public object GetText(TextFormatCode format) => 
        format switch 
        { 
            TextFormatCode.GluedLine => SurName + " " + Name + " " + Age + " лет",
            TextFormatCode.Formatted => string.Format("{0} {1} {2} лет", SurName, Name, Age),
            TextFormatCode.Interpolated => $"{SurName} {Name} {Age} лет",
            _ => throw new NotImplementedException(),
        };
}

public enum TextFormatCode
{
    GluedLine,
    Formatted,
    Interpolated,
}
