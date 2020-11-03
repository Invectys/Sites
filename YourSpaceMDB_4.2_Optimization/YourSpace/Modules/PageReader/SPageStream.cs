using YourSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using YourSpace.Modules.Pages.Page;
using YourSpace.Data;
using YourSpace.Modules.Pages.Page.Models;
using Microsoft.Extensions.DependencyInjection;

namespace YourSpace.Modules.PageReader
{
    public class SPageStream : ISPageStream
    {

        private readonly ISFilesPathBuilder _pathBuilder;
        private ApplicationDbContext _dbContext;

        public SPageStream(ISFilesPathBuilder pathBuilder,IServiceScopeFactory factory)
        {
            _pathBuilder = pathBuilder;
            var scope = factory.CreateScope();
            _dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
        }
        
        public async Task<MPage> ReadPage(string pageId)
        {
            //string path = _pathBuilder.getPagePath(pageName);
            XmlSerializer serializer = new XmlSerializer(typeof(MPage));

            var note = await _dbContext.PagesData.FindAsync(pageId);
            var data = note.Data;

            MPage page;
            //using (TextReader reader = new StreamReader(path))
            //{
            //    page = (MPage)serializer.Deserialize(reader);
            //}

            using(MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                page = (MPage)serializer.Deserialize(stream);
            }


            return page;
        }
        public async Task WritePage(MPage page)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MPage));
           
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, page);
                var note = _dbContext.PagesData.Find(page.Id);
                var array = stream.ToArray(); 
                if (note == null)
                {
                    MPageBinary bin = new MPageBinary();
                    bin.Id = page.Id;
                    bin.Data = array;
                    await _dbContext.AddAsync(bin);
                }
                else
                {
                    note.Data = array;
                    _dbContext.Update(note);
                }
                
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
