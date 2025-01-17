﻿using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class CountDownController : Controller
    {
        private readonly CountDownServices _services;

        public CountDownController(CountDownServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            var Countdown = _services.GetAll();
            return View (Countdown);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( CountDown countDown,List<string> Title, List<string> LangCode, List<string> SEO, int Count)
        {
            _services.Ccreate(countDown);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCountDown(countDown.Id,Title[i], LangCode[i], SEO[i], Count);
            }


            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                countDownLanguages = _services.GetById(id),
                CountDown = _services.GetCountById(id),
            };

            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountDown countDown,int CountDownID, List<int> LangID, List<string> Title, List<string> LangCode)
        {
                for (int i = 0; i < Title.Count; i++)
                {
                    _services.EditCount(countDown, CountDownID, LangID[i], Title[i],  LangCode[i]);
                }


            return RedirectToAction(nameof(Index));
        }
    }
}
