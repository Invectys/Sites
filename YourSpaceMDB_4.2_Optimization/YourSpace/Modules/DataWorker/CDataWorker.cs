using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Modules.Gallery;
using YourSpace.Modules.ModalWindow;
using YourSpace.Services;

namespace YourSpace.Modules.DataWorker
{
    public abstract class CDataWorker : CModalTemplete
    {
        
        public abstract void Update();

        [Inject] protected ISFilesPathBuilder SPathBuilder { get; set; }

        
        public FileType _fileType;
        public GalleryType _galaryType;
        public FileType FileType { get { return _fileType; } set { _fileType = value; Update(); } }
        public GalleryType GalleryType { get { return _galaryType; } set { _galaryType = value; Update(); } }

        public List<string> FilesPaths { get; set; } = new List<string>();

        [CascadingParameter] protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public virtual void HandleDataType()
        {
            var gt = ModalParameters.TryGet<GalleryType>("GalleryType",out bool have);
            if (have)
                _galaryType = gt;
        }
        protected  override void OnInitialized()
        {
            HandleDataType();
            Update();
        }
    }

    public enum GalleryType
    {
        User,
        Common
    }

    public enum FileType
    {
        Images,
        Music
    }
}
