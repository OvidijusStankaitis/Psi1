﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace PSI_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroController : ControllerBase
    {
        private static Dictionary<string, Thread> userTimers = new Dictionary<string, Thread>();

        private void RunTimer(string userId, int duration)
        {
            try
            {
                Thread.Sleep(duration);
                
                Console.WriteLine($"Timer for user {userId} completed!");
                
                if (userTimers.ContainsKey(userId))
                {
                    userTimers.Remove(userId);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine($"Timer for user {userId} was interrupted.");
            }
            catch
            {
                // Logging here
            }
        }

        [HttpPost("start-timer")]
        public IActionResult StartTimer([FromBody] TimerRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest("UserId is required.");
            }

            if (request.Duration <= 0)
            {
                return BadRequest("Invalid duration.");
            }

            if (userTimers.ContainsKey(request.UserId))
            {
                userTimers[request.UserId].Interrupt();
                userTimers.Remove(request.UserId);
            }

            Thread timerThread = new Thread(() => RunTimer(request.UserId, request.Duration));
            timerThread.Start();

            userTimers[request.UserId] = timerThread;

            return Ok("Timer started");
        }

        [HttpPost("stop-timer")]
        public IActionResult StopTimer([FromBody] TimerStopRequest request)
        {
            if (userTimers.ContainsKey(request.UserId))
            {
                userTimers[request.UserId].Interrupt();
                userTimers.Remove(request.UserId);
                return Ok("Timer stopped");
            }
            return NotFound("No timer found for the user.");
        }
    }

    public class TimerRequest
    {
        public string UserId { get; set; }
        public int Duration { get; set; }
    }
    
    public class TimerStopRequest
    {
        public string UserId { get; set; }
    }
}
