using Microsoft.AspNetCore.Hosting;
using YourSpace.Services;
using YourSpace.Modules.Gallery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using YourSpace.Modules.DataWorker;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace YourSpace.Modules.FilesPathBuilder
{
    public class SFilesPathBuilder : ISFilesPathBuilder
    {
        public string ImagesFolderName { get; } = "images";
        public string MusicFolderName { get; } = "music";
        public string CommonFolderName { get; } = "commondata";
        public string DeletedPages { get; } = "DeletedUserPages";

        private readonly string _usersWebRootPath = "users";
        private readonly string _rootPath = "N/A";
        private readonly string _applicationData = "Data\\ApplicationData";
        private readonly string _userPagesFolder = "usersPages";
        private readonly string _userDeletedFolder = "usersDeletedData";

        private readonly IWebHostEnvironment _environment;

        public SFilesPathBuilder(IWebHostEnvironment environment)
        {
            _environment = environment;
            _rootPath = _environment.WebRootPath;
        }
        



        //Application Data
        //Pages xml store path
        public string getPagesPath()
        {
            string path = Path.Combine(_environment.ContentRootPath, _applicationData, _userPagesFolder);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getPagePath(string page)
        {
            string path = Path.Combine(getPagesPath(), page + ".xml");
            return path;
        }

        public string getDeletedDataPath(string user,params string[] next)
        {
            string path1 = Path.Combine(_environment.ContentRootPath, _applicationData, _userDeletedFolder,user);
            string path2 = Path.Combine(next);
            string path = Path.Combine(path1, path2);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getDeletedPagesPath()
        {
            string path = Path.Combine(_environment.ContentRootPath, _applicationData, DeletedPages);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getDeletedPagePath(string page)
        {
            string path = Path.Combine(getDeletedPagesPath(), page + ".xml");
            return path;
        }

        //Full path "C:/../.."
        public string getFullRootDataPath()
        {
            string path = Path.Combine(_rootPath, _usersWebRootPath);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getFullRootDataPath(params string[] next)
        {
            string path = Path.Combine(next);
            return Path.Combine(getFullRootDataPath(), path);
        }
        public string getFullRootDataFile(string fileName,params string[] next)
        {
            string path = getFullRootDataPath(next);
            string path1 = Path.Combine(getFullRootDataPath(), path);
            CreateIfDoesntExist(path1);
            return path1;
        }
        public string getFullRootUserDataPath(string userId)
        {
            if(userId == null)
            {
                throw new Exception("User name folder cannot be null");
            }
            string path = Path.Combine(getFullRootDataPath(), userId);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getFullRootUserDataPath(string userId, params string[] next)
        {
            string path1 = getFullRootUserDataPath(userId);
            string path2 = Path.Combine(next);

            string path = Path.Combine(path1, path2);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getFullRootUserDataFile(string userId, string fileName, params string[] next)
        {
            string path1 = getFullRootUserDataPath(userId);
            string path2 = Path.Combine(next);
            string path3 = Path.Combine(path1, path2, fileName);
            return path3;
        }

        //Local path. Relative wwwroot folder 
        public string getLocalRootDataPath()
        {
            return _usersWebRootPath;
        }
        public string getLocalRootDataPath(params string[] next)
        {
            string path = Path.Combine(next);
            string path1 = Path.Combine(getLocalRootDataPath(), path);
            return path1;
        }
        public string getLocalRootDataFile(string fileName, params string[] next)
        {
            string path = getLocalRootDataPath(next);
            return Path.Combine(path, fileName);
        }
        public string getLocalRootUserDataPath(string userId)
        {
            string path = Path.Combine(_usersWebRootPath, userId);
            return path;
        }
        public string getLocalRootUserDataPath(string userId, params string[] next)
        {
            string path1 = getLocalRootUserDataPath(userId);
            string path2 = Path.Combine(next);

            string path = Path.Combine(path1, path2);
            return path;
        }
        public string getLocalRootUserDataFile(string userId,string fileName, params string[] next)
        {
            string path1 = getLocalRootUserDataPath(userId);
            string path2 = Path.Combine(next);
            string path3 = Path.Combine(path1, path2, fileName);
            return path3;
        }

        //using examples or short methodes
        public string getFullRootDataPath(GalleryType galaryType,FileType fileType,string userName = "")
        {
            string path =  makeDataPath(galaryType, fileType, getFullRootDataPath, userName);
            CreateIfDoesntExist(path);
            return path;
        }
        public string getLocalRootDataPath(GalleryType galaryType, FileType fileType, string userName = "")
        {
            return makeDataPath(galaryType, fileType, getLocalRootDataPath, userName);
        }
        public string getLocalRootFilePath(GalleryType galaryType, FileType fileType, string userName, params string[] next)
        {
            string path1 = getLocalRootDataPath(galaryType, fileType, userName);
            string path2 = Path.Combine(next);
            return Path.Combine(path1, path2);
        }


        private string makeDataPath(GalleryType galaryType, FileType fileType, Func<string[],string> action, string userName = "")
        {
            string root1 = "";
            switch (galaryType)
            {
                case GalleryType.Common:
                    root1 = action.Invoke(new string[] { CommonFolderName });
                    break;
                case GalleryType.User:
                    root1 = action.Invoke(new string[] { userName });
                    break;
            }

            string root2 = "";
            switch (fileType)
            {
                case FileType.Images:
                    root2 = ImagesFolderName;
                    break;
                case FileType.Music:
                    root2 = MusicFolderName;
                    break;

            }
            string fullPath = Path.Combine(root1, root2);
            return fullPath;
        }

        private void CreateIfDoesntExist(string path)
        {
            bool exist = Directory.Exists(path);
            if(!exist)
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    
}
