#pragma checksum "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f42fdc8a203ae4833d110b3349b80aef243816b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Teacher_Detail), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Teacher/Detail.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome.ViewModel.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EduHome.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f42fdc8a203ae4833d110b3349b80aef243816b1", @"/Areas/AdminArea/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6b0de08c5eed0853d10cf0fb74e06115317ac95", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    public class Areas_AdminArea_Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:350px;height:350px;border-radius:50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
   ViewData["Title"] = "Detail"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n    <h1 class=\"text-warning\">Teacher detail</h1>\n    <hr />\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f42fdc8a203ae4833d110b3349b80aef243816b15531", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 149, "~/assets/img/teacher/", 149, 21, true);
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 170, Model.Image, 170, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    <hr />\n    <h3>\n        Teacher\n    </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Name: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                              Write(Model.FullNAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight: bolder; font-family: sans-serif\">Profession: <span style=\"color: grey; font-size: 20px; font-weight: lighter\">");
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                            Write(Model.Profession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight: bolder; font-family: sans-serif\">About: <span style=\"color: grey; font-size: 20px; font-weight: lighter\">");
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                       Write(Model.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n\n    <hr />\n    <h3>\n        Teacher Contacts\n    </h3>\n    <hr />\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Mail: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 21 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                              Write(Model.TeacherContacts.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight: bolder; font-family: sans-serif\">Phone: <span style=\"color: grey; font-size: 20px; font-weight: lighter\">");
#nullable restore
#line 22 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                       Write(Model.TeacherContacts.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Skype: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 23 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                               Write(Model.TeacherContacts.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <hr />\n    <h3>\n        Teacher Details\n    </h3>\n    <hr />\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Degree: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 29 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                Write(Model.TeacherDetails.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight: bolder; font-family: sans-serif\">Exprience: <span style=\"color: grey; font-size: 20px; font-weight: lighter\">");
#nullable restore
#line 30 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                           Write(Model.TeacherDetails.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Hobbies: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 31 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                 Write(Model.TeacherDetails.Hobbies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Faculty: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 32 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                 Write(Model.TeacherDetails.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n    <hr />\n    <h3>\n        Teacher Skills\n    </h3>\n    <hr />\n");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
     foreach (var skills in Model.TeacherSkills)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                Write(skills.Skills.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(": <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
                                                                                                                                                                 Write(skills.Percentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\n");
#nullable restore
#line 41 "C:\Users\ASUS\Desktop\Final Project ASP\EduHomeProject\ASP.NET Core EduHome\ASP.NET Core EduHome\Areas\AdminArea\Views\Teacher\Detail.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f42fdc8a203ae4833d110b3349b80aef243816b115120", async() => {
                WriteLiteral("Go back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
