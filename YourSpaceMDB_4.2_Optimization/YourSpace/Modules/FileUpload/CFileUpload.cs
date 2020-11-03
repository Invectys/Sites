using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using YourSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using YourSpace.Modules.ModalWindow;
using YourSpace.Modules.FilesPathBuilder;
using YourSpace.Modules.DataWorker;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Winista.Mime;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using YourSpace.Modules.Configuration.ConfigurationModels;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Localization;

namespace YourSpace.Modules.FileUpload
{
    public class CFileUpload : CDataWorker
    {

        public string InputAccept {
            get
            {
                string str = "";
                foreach(var s in AcceptMimes)
                {
                    str += s;
                    str += ",";
                }
                return str;
            }
        }

        public bool isLoading { get
            {
                return loading;
            }
        }
        public string Message { get; set; }

        protected long MaxSize { get; set; } = 40000;
        protected string[] AcceptMimes { get; set; }
        protected string LoadedFilePath { get; set; }
        protected IFileListEntry FileSelected { get; set; }

        [Inject] protected IStringLocalizer<CFileUpload> LUpload { get; set; }
        [Inject] protected ISFileUpload _sFileUpload { get; set; }
        [Inject] public IOptions<MLoadingSettings> Options { get; set; }

        private bool loading = false;

        async public Task<LoadFileResult> LoadFileSelected(IFileListEntry file)
        {
            var Claims = (await AuthenticationStateTask).User;
            LoadFileResult result = new LoadFileResult();

            if (file != null)
            {
                if (Claims.Identity.IsAuthenticated)
                {
                    string path = SPathBuilder.getFullRootDataPath(GalleryType, FileType, Claims.Identity.Name);
                    string fileName = _sFileUpload.MakeName(file);
                    await _sFileUpload.Upload(file, path, fileName);
                    result.LocalPath = SPathBuilder.getLocalRootFilePath(GalleryType, FileType, Claims.Identity.Name, fileName);
                    result.FullPath = Path.Combine(path,fileName);
                    result.Successful = true;
                    return result;
                }

            }
            return result;
        }

        public virtual void onStartLoadFile()
        {
            
        }
        public virtual void onFileLoaded(string loadedFilePath,bool successful)
        {
            
        }
        public virtual bool CustomCheckFile(string path)
        {
            return true; 
        }

        public async void LoadFile(IFileListEntry file)
        {
            FileSelected = file;
            bool sizeValid = SizeValid(file.Size);
            if(sizeValid)
            {
                InvokeStartLoad();
                var result = await LoadFileSelected(FileSelected);
                bool valid = true;
                if(result.Successful)
                {
                    LoadedFilePath = result.LocalPath;
                    string fullPath = result.FullPath;
                    bool mimeValid = MimeValid(result.FullPath, AcceptMimes);
                    if(!mimeValid)
                    {
                        File.Delete(fullPath);
                        Message = LUpload["UploadFileTypeError"];
                    }

                    valid = mimeValid && CustomCheckFile(fullPath);
                }
                InvokeEndLoad(valid && result.Successful);

                StateHasChanged();

            }
            else
            {
                Message = String.Format(LUpload["UploadSizeError"], MaxSize / 1024 / 1024);
            }

        }


        public override void Update()
        {
        }

       

        private void InvokeStartLoad()
        {
            loading = true;
            onStartLoadFile();
        }

        private void InvokeEndLoad(bool successful)
        {
            loading = false;
            onFileLoaded(LoadedFilePath, successful);
        }
        private bool SizeValid(long size)
        {
            return size <= MaxSize;
        }
        private bool MimeValid(string path,string[] acceptMimes)
        {
            var mimeTypes = new MimeTypes();
            var type = mimeTypes.GetMimeTypeFromFile(path);
            bool result = acceptMimes.Contains(type.Name);
            return result;
        }
    }

    public class LoadFileResult
    {
        public bool Successful { get; set; } = false;
        public string FullPath { get; set; }
        public string LocalPath { get; set; }
    }
}
