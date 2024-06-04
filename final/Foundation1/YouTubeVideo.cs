using System;
using System.Collections.Generic;

class YouTubeVideo
{
    public string VideoTitle { get; }
    public string VideoAuthor { get; }
    public int Duration { get; }
    private List<UserComment> CommentList { get; }

    public YouTubeVideo(string videoTitle, string videoAuthor, int duration)
    {
        VideoTitle = videoTitle;
        VideoAuthor = videoAuthor;
        Duration = duration;
        CommentList = new List<UserComment>();
    }

    public void AddUserComment(UserComment comment)
    {
        CommentList.Add(comment);
    }

    public int GetCommentCount()
    {
        return CommentList.Count;
    }

    public override string ToString()
    {
        string videoInfo = $"Title: {VideoTitle}\nAuthor: {VideoAuthor}\nDuration: {Duration} seconds\nComments ({GetCommentCount()}):";
        foreach (var comment in CommentList)
        {
            videoInfo += $"\n  {comment}";
        }
        return videoInfo;
    }
}
