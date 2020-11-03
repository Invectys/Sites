using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Data;
using YourSpace.Modules.Music;
using YourSpace.Services;

namespace YourSpace.Modules.Music
{
    public class SMusic : ISMusic
    {

        public event Action<MMusic> OnLunch;
        public MMusic CurrentMusic { get; set; }


        private readonly ApplicationDbContext _dbContext;

        public SMusic(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<MMusic> GetMusic(string id)
        {
            return await _dbContext.Music.FindAsync(id);
        }

        public bool TryGetMusic(string id,out MMusic music)
        {
            music = _dbContext.Music.FirstOrDefault(m => m.Id == id);
            return music != null;
        }

        public async Task AddMusic(MMusic music)
        {
            _dbContext.Add(music);
            await _dbContext.SaveChangesAsync();
        }
    }
}
