﻿namespace PSI_Project.Models;

public class Conspectus : BaseEntity
{
    public string TopicId { get; }
    public string Path { get; }
    public int Rating { get; set; }
    public string Name { get; }

    public Conspectus(string topicId, string path, string name, int rating = 0)
    {
        TopicId = topicId;
        Path = path;
        Name = name;
        Rating = rating;
    }
}
