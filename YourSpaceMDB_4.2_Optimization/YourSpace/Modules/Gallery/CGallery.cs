using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Modules.ComponentsView;
using YourSpace.Modules.DataWorker;
using YourSpace.Modules.FileUpload;
using YourSpace.Modules.ModalWindow;
using YourSpace.Resources;
using YourSpace.Services;

namespace YourSpace.Modules.Gallery
{
    public class CGallery : CDataWorker
    {
        [Inject] private IStringLocalizer<CGallery> L { get; set; }

        public IEnumerable<IGrouping<DateTime, string>> Groups;
        public Type LoadNewFileTypeComponent { get; set; } //CFileUpload

        public void OpenUploadNewFileComponent()
        {
            ModalParameters modalParams = new ModalParameters();
            modalParams.Add("GalleryType", _galaryType);
            SModal.Show(LoadNewFileTypeComponent, L["Upload new"], modalParams,
                ViewStorageApp.UploadNewImageModalOptions, CloseUploadNewFileComponent);
        }
        public void CloseUploadNewFileComponent(ModalResult result)
        {
            Update();
        }

        public async void Load()
        {
            var Claims = (await AuthenticationStateTask).User;

            FilesPaths.Clear();
            string fullPath = SPathBuilder.getFullRootDataPath(GalleryType, FileType, Claims.Identity.Name);

            string[] FullPaths = Directory.GetFiles(fullPath);
            foreach (string path in FullPaths)
            {
                string fileName = Path.GetFileName(path);
                string rootPath = Path.Combine(SPathBuilder.getLocalRootDataPath(GalleryType, FileType, Claims.Identity.Name), fileName);
                FilesPaths.Add(rootPath);
            }
        }

        public virtual void CustomFilesActions()
        {

        }
        
        public override void Update()
        {
            Load();
            Groups = FileGroupCreater.CreateGroupByDate(FilesPaths);
            CustomFilesActions();
            StateHasChanged();
        }
    }

   
}
