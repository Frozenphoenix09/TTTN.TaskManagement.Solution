﻿namespace TTTN.TaskManagement.Models.Models.LoginModels
{
    public class LoginResponse
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}