#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "742f3ad8017f01d3af59f11b72f97fda109f27d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using ASGlass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using ASGlass.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using ASGlass.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using ASGlass.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using ASGlass.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"742f3ad8017f01d3af59f11b72f97fda109f27d5", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f96611a6467f4114bc417bbc3e10c3569ee1d6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Sifariwim";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""p-5"">
    <div class=""container"">
        <div class=""d-flex justify-content-between align-items-center"">
            <h1>Sifariş</h1>
        </div>
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">Mehsulun adi</th>
                    <th scope=""col"">Mehsulun qiymeti</th>
                    <th scope=""col"">Mehsulun hazir olma tarixi</th>
                    <th scope=""col"">Status</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>");
#nullable restore
#line 22 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
                   Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
                   Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
                   Write(Model.CreatedAt.AddDays(5).ToString("HH:mm dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <h5>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 908, "\"", 1043, 4);
            WriteAttributeValue(" ", 916, "text-black-50", 917, 14, true);
            WriteAttributeValue(" ", 930, "badge", 931, 6, true);
            WriteAttributeValue(" ", 936, "badge-", 937, 7, true);
#nullable restore
#line 27 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
WriteAttributeValue("", 943, Model.Status== OrderStatus.Accepted?"success":Model.Status== OrderStatus.Rejected?"danger":"info", 943, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                ");
#nullable restore
#line 28 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Order\Index.cshtml"
                            Write(Model.Status== OrderStatus.Accepted?"Qəbul olunub":Model.Status== OrderStatus.Rejected?"Rədd edilib":"Gözləmədədir");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </span>\r\n                        </h5>\r\n                    </td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n\r\n\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
