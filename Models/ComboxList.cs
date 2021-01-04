using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ConfigurationManagement.Models
{
    public class ComboxList
    {
        public IEnumerable<SelectListItem> places { get; } = new List<SelectListItem>
        {
            new SelectListItem{ Text = "自宅", Value = "0"},
            new SelectListItem{ Text = "そのほか", Value = "1"},
        };

        public IEnumerable<SelectListItem> hostTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem{ Text = "クライアント", Value = "0"},
            new SelectListItem{ Text = "サーバ", Value = "1"},
            new SelectListItem{ Text = "モバイル", Value = "2"},
            new SelectListItem{ Text = "プリンタ", Value = "3"},
            new SelectListItem{ Text = "スイッチングSW", Value = "4"},
            new SelectListItem{ Text = "ルータ", Value = "5"},
        };
    }
}
