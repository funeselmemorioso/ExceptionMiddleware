﻿using System.Text.Json;

namespace MiddlewareDeExceptions.Middlewares.Entities
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
