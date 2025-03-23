using System;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Judul video harus tidak null dan maksimal 100 karakter.");
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 10000000) 
        {
            throw new ArgumentException("Jumlah play count maksimal adalah 10.000.000 per panggilan.");
        }

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count melebihi batas maksimum integer.");
        }
    }


    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Yudha Harwanto");
        video.PrintVideoDetails();

        for (int i = 0; i < 3; i++)
        {
            video.IncreasePlayCount(10000000);
            video.PrintVideoDetails(); 
        }

        video.PrintVideoDetails();
    }
}

