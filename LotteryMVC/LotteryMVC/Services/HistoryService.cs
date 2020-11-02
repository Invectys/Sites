using LotteryMVC.Data;
using LotteryMVC.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LotteryMVC.Services
{
    public class HistoryService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public HistoryService(IServiceScopeFactory serviceScopeFactory)
        {
            IServiceScope scope = serviceScopeFactory.CreateScope();

            _applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
       
        

        public List<string> GetHistoryJsonNotes(string id)
        {
            List<Note> notes = _applicationDbContext.Notes.Where(h => h.UserId == id).ToList();
          
            List<string> list = new List<string>();
            if(notes != null)
            {
                foreach (var o in notes)
                {
                    list.Add(o.Json);
                }
            }
            
            

            return list;
        }
        public IQueryable<Note> GetHistoryNotes(string id)
        {
            return _applicationDbContext.Notes.Where(h => h.UserId == id);
        }

       

        public void AddNote(Note note)
        {
            _applicationDbContext.Notes.Add(note);
            _applicationDbContext.SaveChangesAsync();
        }

        public void AddDefaultNote(string text, string userId)
        {
            
            NotifyModel notify = new NotifyModel();
            notify.Text = text;
            AddNote(notify, userId);
            
        }
        public void AddNote<TNotify>(TNotify model, string userId) where TNotify : NotifyModel
        {
            Note note = new Note();
            note.UserId = userId;
            note.Type = model.Type;
            note.Json = JsonSerializer.Serialize(model);
            _applicationDbContext.Notes.Add(note);
            _applicationDbContext.SaveChangesAsync();

        }

    }
}
