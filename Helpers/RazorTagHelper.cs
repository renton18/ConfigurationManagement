﻿using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManagement.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tag-name")]
    public class RazorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

        }
    }
}
