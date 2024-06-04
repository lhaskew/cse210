using System;

class UserComment
{
    public string UserName { get; }
    public string Text { get; }

    public UserComment(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{UserName}: {Text}";
    }
}
