using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerDB;
using BeerFinder.Models;
using BeerFinder.Models.BarModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BeerFinder.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public BarController(IBarRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel indexViewModel=new IndexViewModel();
            indexViewModel.BarViewModels=new List<BarViewModel>();
            foreach (Bar bar in _repository.GetAll())
            {
                indexViewModel.BarViewModels.Add(new BarViewModel(bar.Name,bar.BarTags,bar.OpeningTime,bar.ClosingTime,bar.Picture));
            }
            return View(indexViewModel);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(IndexViewModel indexViewModel)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            List<BarViewModel> newList=new List<BarViewModel>();
            indexViewModel.BarViewModels=new List<BarViewModel>();
            foreach (Bar bar in _repository.GetAll())
            {
                indexViewModel.BarViewModels.Add(new BarViewModel(bar.Name,bar.BarTags,bar.OpeningTime,bar.ClosingTime,bar.Picture));
            }
            foreach (BarViewModel bar in indexViewModel.BarViewModels)
            {
                if (bar.Name.Contains(indexViewModel.Text)
                    || bar.BarTags.Any(b => b.Text.ToLower().Equals(indexViewModel.Text.ToLower())))
                {
                    newList.Add(bar);
                }
            }
            return View(new SearchViewModel(newList));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel addViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                String[] array = addViewModel.BarTagString.Split(';');
                List<BarTag> BarTags = new List<BarTag>();
                Bar bar = new Bar(addViewModel.Name
                    , BarTags
                    , addViewModel.OpeningTime
                    , addViewModel.ClosingTime
                    , addViewModel.Picture
                    , Guid.Parse(user.Id))
                {
                    BarTags = BarTags
                };
                //for (int i = 0; i < array.Length; i++)
                //{
                //    _repository.AddTag(array[i].Trim(),bar);
                //}
                _repository.Add(bar);
                return RedirectToAction("Index");
            }
            return View(addViewModel);
        }
    }
}