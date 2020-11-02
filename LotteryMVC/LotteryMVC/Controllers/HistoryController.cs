using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryMVC.Data;
using LotteryMVC.Models;
using LotteryMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LotteryMVC.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
       
        private readonly UserManager<User> _userManager;
        private readonly HistoryService _historyService;
        public HistoryController(UserManager<User> userManager,HistoryService historyService)
        {
            _userManager = userManager;
            _historyService = historyService;
        }

        public IActionResult Index(int page = 0)
        {
            int NoteCount = 10;

            
            User user = _userManager.GetUserAsync(User).Result;
            string id = user.Id;

            IQueryable<Note> notes = _historyService.GetHistoryNotes(id);
            var count = notes.Count();
            if (page < 1) page = (count / NoteCount)+1;
            var items = notes.Skip((page - 1) * NoteCount).Take(NoteCount).ToList();
            

            PageViewModel pageViewModel = new PageViewModel(count, page, NoteCount);
            HistoryViewModel viewModel = new HistoryViewModel
            {
                PageViewModel = pageViewModel,
                Notes = items
            };
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult UserHistory(string userid,int page = 1)
        {
            
            int NoteCount = 10;

            string id = userid;

            IQueryable<Note> notes = _historyService.GetHistoryNotes(id);
            var count = notes.Count();
            if (page < 1) page = (count / NoteCount) + 1;
            var items = notes.Skip((page - 1) * NoteCount).Take(NoteCount).ToList();


            PageViewModel pageViewModel = new PageViewModel(count, page, NoteCount);
            HistoryViewModel viewModel = new HistoryViewModel
            {
                PageViewModel = pageViewModel,
                Notes = items
            };

            ViewData["userid"] = userid;

            return View(viewModel);
        }

        [Authorize(Roles ="admin")]
        public IActionResult AddNote(string userid)
        {
            AddNoteModel m = new AddNoteModel();
            m.UserID = userid;
            return View(m);
        }

        [Authorize(Roles ="admin")]
        [HttpPost]
        public IActionResult AddNote(AddNoteModel notify)
        {
            _historyService.AddDefaultNote(notify.Text, notify.UserID);
            return RedirectToAction("Index", "Users");
        }
    }
}