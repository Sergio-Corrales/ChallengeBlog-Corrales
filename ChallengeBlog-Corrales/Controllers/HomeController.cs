using ChallengeBlog_Corrales.Data;
using ChallengeBlog_Corrales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChallengeBlog_Corrales.Models.TableViewModels;

namespace ChallengeBlog_Corrales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext Context)
        {
            _logger = logger;
            _Context = Context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly ApplicationDbContext _Context;

        //public HomeController(ApplicationDbContext Context)
        //{
        //    _Context = Context;
        //}

        public IActionResult Index()
        {
            //Creo una lista para la tabla que quiero mostrar
            List<HomePostsTableViewModel> ListP = new List<HomePostsTableViewModel>();
            //Creo un objeto de la clase que uso para mostrar
            HomePostsTableViewModel HPTVM;
            IEnumerable<Post> ListPosts = _Context.Post;

            //Si la lista tiene contenido la recorro 
            if (ListPosts.Count() > 0)
            {
                foreach (Post P in ListPosts)
                {
                    //string imageBase64Data = Convert.ToBase64String(P.Picture);
                    //creo un objeto del tableViewModel
                    HPTVM = new HomePostsTableViewModel();
                        
                    HPTVM.Id = P.Id;
                    HPTVM.Picture = P.Picture; 
                    HPTVM.Title = P.Title;

                    if (HPTVM.Picture!=null) 
                    {
                        ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(HPTVM.Picture, 0, HPTVM.Picture.Length);
                    }
                    

                    //Agrego el objeto a la lista
                    ListP.Add(HPTVM);
                }
            }

            return View(ListP);
        }

        
        public ActionResult GetImage(int Id)
        {
            IEnumerable<Post> ListPosts = _Context.Post;
            List<Post> Lpost = new List<Post>();

            if (ListPosts.Count() > 0)
            {
                Post post = new Post();
                post=ListPosts.FirstOrDefault(x => x.Id == Id);

                if (post.Picture != null)
                {
                    return File(post.Picture, "Image/jpeg");
                    //ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(post.Picture, 0, post.Picture.Length);
                }
                else { return null; }
              
                //Lpost.Add(post);
            }
            else { return View(); }  
        
        }
    }
}
