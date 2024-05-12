using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference.Reference}: {GetVisibleText()}");
    }

    public bool HideRandomWord()
    {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0)
            return false;

        Random random = new Random();
        int index = random.Next(0, visibleWords.Count);
        visibleWords[index].Hide();
        return true;
    }

    private string GetVisibleText()
    {
        return string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text));
    }
}
