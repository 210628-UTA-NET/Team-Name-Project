using System;

namespace WebUI.Models
{
    public class JokeViewModel
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public string Status { get; set; }

        public JokeViewModel()
        {
            Joke = "Hi User, I'm Dad!";
        }

        public JokeViewModel(string p_id, string p_joke, string p_status)
        {
            Id = p_id;
            Joke = p_joke;
            Status = p_status;
        }
    }
}