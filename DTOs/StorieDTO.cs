﻿namespace SearchNews.Model
{
    public class StorieDTO
    {
        public string? Title { get; set; }

        public string? Uri { get; set; }

        public string? PostedBy { get; set; }

        public DateTime? Time { get; set; }

        public int Score { get; set; }

        public int CommentCount { get; set; }
    }
}
