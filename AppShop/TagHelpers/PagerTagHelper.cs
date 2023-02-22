using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.Design;

namespace AppShop.TagHelpers
{
    public class PagerTagHelper: TagHelper
    {
        LinkGenerator _linkGenerator;
        
        //номер текущей страницы
        public int PageCurrent { get; set; }
        //общее количество страниц
        public int PageTotal { get; set; }
        //дополнительный css класс пейджера
        public string PagerClass { get; set; }
        //имя Action
        public string Action { get; set; }
        //имя контроллера
        public string Controller { get; set; }
        public int? GroupId { get; set; }

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //контейнер разметки пейджера
            output.TagName = "nav";

            //пейджер
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);

            for(int i = 1; i <= PageTotal; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action, Controller, new { pageNo = i, group = GroupId == 0 ? null : GroupId });

                //Получение разметки одной кнопки пейджера
                var item = GetPagerItem(url: url, text: i.ToString(), active: i == PageCurrent, disabled: i == PageCurrent);

                //Добавить кнопку в разметку пейджера
                ulTag.InnerHtml.AppendHtml(item);

            }

            //добавить пейджер в контейнер
            output.Content.AppendHtml(ulTag);


        }

        private TagBuilder GetPagerItem(string url, string text, bool active = false, bool disabled = false)
        {
            //Создать тэг <li>
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");

            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);

            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }

    }
}
