﻿namespace Medicine.Views.ViewModel
{
    public class UserViewModel
    {
        public string id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

}
