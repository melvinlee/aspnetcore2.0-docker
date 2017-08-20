using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;

namespace HitCounter
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string Message { get; private set; }
        public void OnGet()
        {
            var url = _configuration["REDIS_URL"];

            try
            {                
                var redis = ConnectionMultiplexer.Connect(url);
                var db = redis.GetDatabase();

                var hits = db.StringIncrement("hits");

                if (hits > 1)
                {
                    Message = $"We have had {hits} visitors so far!";
                }
                else
                {                    
                    Message = "You are our first visitor!";
                }
            }
            catch (Exception exp)
            {
                Message = $"An error has occured while connecting to: {url}";
                _logger.LogError(exp.Message);
            }
        }
    }
}
