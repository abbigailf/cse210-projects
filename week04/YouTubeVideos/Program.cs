using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // --- VIDEO 1 ---
        Video v1 = new Video("How to Bake Bread", "Amy Bakes", 420);
        v1.AddComment(new Comment("Sarah", "This helped me so much!"));
        v1.AddComment(new Comment("Tom", "Mine didn’t rise but still yummy."));
        v1.AddComment(new Comment("Katie", "Great tutorial!"));
        videos.Add(v1);

        // --- VIDEO 2 ---
        Video v2 = new Video("Top 10 Hiking Trails", "OutdoorGuy", 690);
        v2.AddComment(new Comment("Mark", "Trail #3 is my favorite!"));
        v2.AddComment(new Comment("Jenny", "Adding these to my bucket list."));
        v2.AddComment(new Comment("Leo", "Amazing views."));
        videos.Add(v2);

        // --- VIDEO 3 ---
        Video v3 = new Video("Needle Felting for Beginners", "CraftyCreature", 515);
        v3.AddComment(new Comment("Luna", "This made needle felting way less scary!"));
        v3.AddComment(new Comment("Alex", "I stabbed my finger but the fox came out cute anyway."));
        v3.AddComment(new Comment("Maya", "More animal tutorials please!"));
        videos.Add(v3);
        
        // --- DISPLAY ALL VIDEOS ---
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}