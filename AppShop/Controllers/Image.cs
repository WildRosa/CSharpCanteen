﻿using AppShop.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppShop.Controllers
{
    public class Image : Controller
    {

        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public Image(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user.AvatarImage != null)
            {
                return File(user.AvatarImage, "image/...");
            }
            else
            {
                var avatarPath = "/Images/avatar.png";
                return File(_env.WebRootFileProvider.GetFileInfo(avatarPath).CreateReadStream(), "image/...");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
