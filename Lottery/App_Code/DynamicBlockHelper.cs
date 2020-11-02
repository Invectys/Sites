
using Lottery.Models.PersonalPageModels;
using Lottery.Models.SaveModels;
using Lottery.Other;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lottery.App_Code
{
    public static class DynamicBlockHelper
    {
      
       
      
        public static HtmlString _AddBlocks(this IHtmlHelper html, XElement page)
        {
            IEnumerable<XElement> Blocks = page.Elements();
            string PageName = page.Attribute("name").Value;

            string result = "";
            result += "<script>$(document).ready(function () {";

            result += "var info = {};";

            //Page Info
            PageInfoModel PageInfo = FileControl.getPageInfo(page);
            if(!PageInfo.PageHeight.Equals(""))
            result += "SetSizePage('" + PageInfo.PageHeight + "');";

            foreach (var block in Blocks)
            {
                //берем тип блока
                string[] args = block.Name.ToString().Split('-');

                //исключения из добавления 
                if (args[0].Equals("ToolsPanel")) continue;
                if (args[0].Equals("PageInfo")) continue;
                //инфо о блоке
                SaveBlockViewModel blockInfo = FileControl.getBlockModel(block);

                //определяем генерирующий скрипт 
                string script = "AddForm";
                script += "('" + args[0] + "',info,false);";


                result += "info.id = '" + args[1] + "';";

                result +=
                     "info.left = '" + blockInfo.info.left + "';" +
                     "info.top = '" + blockInfo.info.top + "';";

                string height = blockInfo.info.height;
                string width = blockInfo.info.width;
                string rotate = blockInfo.info.rotate;
                Vector2D skew = blockInfo.info.skew;
                Vector2D translate = blockInfo.info.translate;


                result +=
                    "info.height = '" + height + "';" +
                    "info.width = '" + width + "';" +
                    "info.rotate = '" + rotate + "';" +
                    "info.skew = { x:'" + skew.x + "', y:'" + skew.y + "'};" +
                    "info.translate = { x:'" + translate.x + "', y:'" + translate.y + "'};" +
                    "info.bgcolor = '" + blockInfo.info.bgcolor + "';" +
                    "info.effect = '" + blockInfo.info.effect + "';" +
                    "info.scale = '" + blockInfo.info.scale + "';" +
                    "info.layer = '" + blockInfo.info.layer + "';";


                if (block.Element("Post") != null)
                {
                    string post = "<text style=\"display:none \" id=\"" + blockInfo.FullName + "-post-text\">" + block.Element("Post").Value + "</text>";

                    result = String.Concat(post, result);
                    result += "info.post ='" + blockInfo.FullName + "-post-text" + "';";
                }
                if (block.Element("Title") != null)
                {
                    string title = block.Element("Title").Value;

                    result += "info.title = '" + title + "';";

                }
                    
                XElement el;
                switch (args[0])
                {
                    case "photo":
                        el = block.Element("img");
                        if(el != null)
                        {
                            result += "info.img = '" + el.Value + "';";
                        }
                        else
                        {
                            result += "info.img = '" + "http://thefalcon.kinkaid.org/wp-content/uploads/2015/10/avatar3.jpg" + "';";
                        }
                        break;

                    case "note":
                        el = FileControl.ValidateElementProperty(block, "text");
                        string str = "<text style=\"display:none \" id=\"" + blockInfo.FullName + "-text\">" + el.Value + "</text>";
                        result = String.Concat(str, result);
                        result += "info.text ='" + blockInfo.FullName + "-text" + "';" ;

                        break;


                    case "html":
                        if (block.Element("file") != null)
                        {
                            result += "info.file = '" + block.Element("file").Value + "';";
                        }

                        break;
                    case "frame":
                        if (block.Element("frame") != null)
                        {
                            result += "info.video = '" + block.Element("frame").Value + "';";
                        }
                        break;

                }

               result += script;
                
                
                
            }
            result += "});</script > ";





            return new HtmlString(result);
        }

       
    }
}



