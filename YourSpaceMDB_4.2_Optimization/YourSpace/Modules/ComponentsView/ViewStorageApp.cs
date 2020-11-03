using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.ModalWindow;

namespace YourSpace.Modules.ComponentsView
{
    public static class ViewStorageApp
    {
        public static ModalOptions SelectImageModalOpt { get
            {
                return new ModalOptions() { Size = "col-sm-12 col-md-9 " };
            } 
        }
        public static ModalOptions UploadNewImageModalOptions
        {
            get
            {
                return SelectImageModalOpt;
            }
        }
        public static ModalOptions CreateNewPageModalOptions
        {
            get
            {
                return new ModalOptions() 
                { 
                    Size = "col-sm-12 col-md-9 ",
                    DisableBackgroundCancel = true
                };
            }
        }

        public static ModalOptions CreateNewBlockModalOptions
        {
            get
            {
                return CreateNewPageModalOptions;
            }
        }

        public static ModalOptions EditRoleModalOptions
        {
            get
            {
                return CreateNewPageModalOptions;
            }
        }
        public static ModalOptions EditUserModalOptions
        {
            get
            {
                return SelectImageModalOpt;
            }
        }
        public static ModalOptions EditProfileModalOptions
        {
            get
            {
                return SelectImageModalOpt;
            }
        }
        public static ModalOptions EditPageModalOptions
        {
            get
            {
                return SelectImageModalOpt;
            }
        }
        public static ModalOptions CreateUserModalOptions
        {
            get
            {
                return SelectImageModalOpt;
            }
        }
    }
}
