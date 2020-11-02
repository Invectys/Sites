using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.PartialViewModels
{
    public class PartialModel
    {

        public string ModalId { get; set; }
        public ModalAction Action { get; set; }
       

        public PartialModel(string ModalId,ModalAction action)
        {
            Action = action;
            this.ModalId = ModalId;
        }
    }

    public enum ModalAction
    {
        LoadImage,
        LoadFile,
        Video,
    }
}
