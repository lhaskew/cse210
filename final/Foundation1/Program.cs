using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos with even more random topics
        var firstVideo = new YouTubeVideo("DIY Backyard Roller Coaster", "Creative Engineers", 600);
        var secondVideo = new YouTubeVideo("The Science of Baking Perfect Bread", "Culinary Science", 1200);
        var thirdVideo = new YouTubeVideo("Top 10 Rare Exotic Pets", "Animal Wonders", 900);
        var fourthVideo = new YouTubeVideo("Exploring Abandoned Mansions", "Urban Explorers", 1800);

        // Add comments to videos
        firstVideo.AddUserComment(new UserComment("Aiden", "This is so cool!"));
        firstVideo.AddUserComment(new UserComment("Bella", "I want to build one too."));
        firstVideo.AddUserComment(new UserComment("Carter", "Amazing creativity!"));

        secondVideo.AddUserComment(new UserComment("Daisy", "Can't wait to try this recipe."));
        secondVideo.AddUserComment(new UserComment("Ethan", "Learned so much about the science of baking."));
        secondVideo.AddUserComment(new UserComment("Fiona", "My bread turned out perfect!"));

        thirdVideo.AddUserComment(new UserComment("George", "I never knew these pets existed."));
        thirdVideo.AddUserComment(new UserComment("Hannah", "I want a fennec fox now."));
        thirdVideo.AddUserComment(new UserComment("Isaac", "Such fascinating animals."));

        fourthVideo.AddUserComment(new UserComment("Jack", "This was eerie but intriguing."));
        fourthVideo.AddUserComment(new UserComment("Kylie", "I love urban exploration videos."));
        fourthVideo.AddUserComment(new UserComment("Liam", "Amazing footage and history."));

        // Add videos to a list
        var videoCollection = new List<YouTubeVideo> { firstVideo, secondVideo, thirdVideo, fourthVideo };

        // Display information for each video
        foreach (var video in videoCollection)
        {
            Console.WriteLine(video);
            Console.WriteLine();
        }
    }
}
