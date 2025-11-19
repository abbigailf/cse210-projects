public class Comment
{
    // Attributes
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }
}