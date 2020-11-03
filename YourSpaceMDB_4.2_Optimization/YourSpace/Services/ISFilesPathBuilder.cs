//Сервис предназначен для сборки путей к разным частя приложения 
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.DataWorker;
using YourSpace.Modules.Gallery;

namespace YourSpace.Services
{
    public interface ISFilesPathBuilder
    {
        public string ImagesFolderName { get; }
        public string CommonFolderName { get; }
        //Application Data
        //Pages xml store path
        public string getPagesPath();
        public string getPagePath(string page);

        public string getDeletedDataPath(string user, params string[] next);
        public string getDeletedPagesPath();
        public string getDeletedPagePath(string page);


        //Full path "C:/../.."
        public string getFullRootDataPath();
        public string getFullRootDataPath(params string[] next);
        public string getFullRootDataFile(string fileName, params string[] next);
        public string getFullRootUserDataPath(string userId);
        public string getFullRootUserDataPath(string userId, params string[] next);
        public string getFullRootUserDataFile(string userId, string fileName, params string[] next);

        //Local path. Relative wwwroot folder 
        public string getLocalRootDataPath();
        public string getLocalRootDataPath(params string[] next);
        public string getLocalRootUserDataPath(string userId);
        public string getLocalRootUserDataPath(string userId, params string[] next);
        public string getLocalRootUserDataFile(string userId, string fileName, params string[] next);


        //using examples or short methodes
        public string getFullRootDataPath(GalleryType galaryType, FileType fileType, string userName = "");
        public string getLocalRootDataPath(GalleryType galaryType, FileType fileType, string userName = "");
        public string getLocalRootFilePath(GalleryType galaryType, FileType fileType, string userName, params string[] next);

    }
}
