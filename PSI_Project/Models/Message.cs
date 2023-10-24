﻿namespace PSI_Project.Models;

public class Message : BaseEntity
{
    public string Text { get; set; }
    public string Email { get; set; }
    public bool IsUserMessage { get; set; }
    public User Sender { get; set; }

    public Message()
    {
    }

    public Message(string text, string email, bool isUserMessage)
    {
        Text = text;
        Email = email;
        IsUserMessage = isUserMessage;
    }
}