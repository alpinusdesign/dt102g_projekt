using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dt102g_projekt.Models;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using dt102g_projekt.Data;
using dt102g_projekt.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace dt102g_projekt.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get 5 posts, ordered by 
            var posts = _context.Posts.OrderByDescending(i => i.DatePosted).Take(6).ToList();

            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Posts = posts;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([FromForm]IndexViewModel indexViewModel)
        {
            if(ModelState.IsValid)
            {
                // Create new message.
                var message = new MimeMessage();

                // Add the senders information.
                message.From.Add(new MailboxAddress(indexViewModel.ContactForm.Name, indexViewModel.ContactForm.Email));

                // Add the recievers information.
                message.To.Add(new MailboxAddress("Linus", "list1507@student.miun.se"));

                // Add a mail-subject.
                message.Subject = $"RenGöran, kontaktformulär: {indexViewModel.ContactForm.Email}";

                // Add the message content.
                message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = indexViewModel.ContactForm.Message
                };

                // Connect to Smtp-client and send message.
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("rengoranab@gmail.com", "RenGoran123!");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                // Clear the form-inputs and display confirmation message.
                ModelState.Clear();
                ViewData["EmailConfirm"] = "Meddelandet skickades!";
            }

            // Get 5 posts, ordered by 
            var posts = _context.Posts.OrderByDescending(i => i.DatePosted).Take(6).ToList();
            indexViewModel.Posts = posts;

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
