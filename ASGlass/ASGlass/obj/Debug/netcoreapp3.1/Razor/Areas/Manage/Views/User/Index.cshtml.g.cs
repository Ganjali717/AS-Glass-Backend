#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3594da40ddbb9d1cfc036b3b85c7ce0d6001632a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_User_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using ASGlass.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using ASGlass.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using ASGlass.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using ASGlass.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using ASGlass.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3594da40ddbb9d1cfc036b3b85c7ce0d6001632a", @"/Areas/Manage/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a476f629b6a567d5be3b3d59d2e0215261c66b", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int order = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""panel-header panel-header-sm"">
</div>
<div class=""content mt-5"">
    <div class=""col-12"">
        <div class=""d-flex justify-content-between align-items-center"">
            <h1>Users</h1>
        </div>
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Fullname</th>
                    <th scope=""col"">Username</th>
                    <th scope=""col"">Email</th>
                    <th scope=""col"">Status</th>
                </tr>

            </thead>
            <tbody>
");
#nullable restore
#line 26 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                 foreach (var users in Model)
                {
                    order++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 30 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                                   Write(order);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                       Write(users.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                       Write(users.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                       Write(users.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                        Write(users.ConnectionId == null?"offline":"online");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 36 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Areas\Manage\Views\User\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
