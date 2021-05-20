using ChallengeBlog_Corrales.Data;
using ChallengeBlog_Corrales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBlog_Corrales.Controllers
{
    public class PostsController : Controller
    {

        private readonly ApplicationDbContext _Context;

        public PostsController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public IActionResult Index()
        {
            IEnumerable<Post> ListPosts = _Context.Post;
            return View(ListPosts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                //Seteo el dia de hoy en la creacion del post
                post.Creation_Date = DateTime.Today;

                foreach (var file in Request.Form.Files) 
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    post.Picture = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }

 
                _Context.Post.Add(post);
                _Context.SaveChanges();
            }
            
            return View();
        }
    }
}
