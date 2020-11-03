//Все о музыке. Обработка и добавление. Получение пути к файлу

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Music;

namespace YourSpace.Services
{
    public interface ISMusic
    {
        public MMusic CurrentMusic { get; set; }
        event Action<MMusic> OnLunch;
        public bool TryGetMusic(string id, out MMusic music);
        public Task<MMusic> GetMusic(string id);
        public Task AddMusic(MMusic music);
    }
}
