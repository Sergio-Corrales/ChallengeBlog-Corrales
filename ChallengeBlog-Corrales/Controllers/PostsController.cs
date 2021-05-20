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

        public IActionResult Index(int Id)
        {
            IEnumerable<Post> ListPosts = _Context.Post;
            List<Post> LPost = new List<Post>();

            if (ListPosts.Count() > 0)
            {
                Post post = new Post();
                post = ListPosts.FirstOrDefault(x => x.Id == Id);

                if (post.Picture != null)
                {
                    ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(post.Picture, 0, post.Picture.Length);
                }

                LPost.Add(post);
            }


            return View(LPost);

            //IEnumerable<Post> ListPosts = _Context.Post;
            //return View(ListPosts);
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

                //busco la imagen y la convierto en byte[]
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

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            //Busco el post
            var post = _Context.Post.Find(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                //busco la imagen y la convierto en byte[]
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    post.Picture = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }
                _Context.Post.Update(post);
                _Context.SaveChanges();

                return RedirectToAction("Index", new { Id=post.Id });
            }

            return View();
        }

        //[HttpPost]
        public IActionResult Delete(int? Id)
        {
            var post = _Context.Post.Find(Id);

            if (post == null)
            {
                return NotFound();
            }
                _Context.Post.Remove(post);
                _Context.SaveChanges();

                return RedirectToAction("Index", "Home", new { Id = post.Id });
            
        }
    }
}
