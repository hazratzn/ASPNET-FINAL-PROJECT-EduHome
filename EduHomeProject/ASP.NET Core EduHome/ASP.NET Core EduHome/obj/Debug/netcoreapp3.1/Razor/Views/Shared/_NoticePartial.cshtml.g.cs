#pragma checksum "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88a4bb47275a43f6cdd90a0f1cbc22dcecac59fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NoticePartial), @"mvc.1.0.view", @"/Views/Shared/_NoticePartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88a4bb47275a43f6cdd90a0f1cbc22dcecac59fa", @"/Views/Shared/_NoticePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10dc1e6b32a0c95b92c3509c3ab80c7ea1b2b9f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NoticePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Notice>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n    <div class=\"notice-left-wrapper\">\r\n        <h3>notice board</h3>\r\n        <div class=\"notice-left\">\r\n");
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml"
             foreach (var notice in Model.Where(m=>m.IsDelete == false).OrderByDescending(m=>m.Id))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 305, "\"", 325, 1);
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml"
WriteAttributeValue("", 313, notice.Size, 313, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <h4>");
#nullable restore
#line 9 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml"
                   Write(notice.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <p>");
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml"
                  Write(notice.NoticeBoard);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n");
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Views\Shared\_NoticePartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Notice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
