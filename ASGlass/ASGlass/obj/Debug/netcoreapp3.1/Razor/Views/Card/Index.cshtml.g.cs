#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ffaf97a2ec9745c52a668be23c28b663294ac40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Card_Index), @"mvc.1.0.view", @"/Views/Card/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ffaf97a2ec9745c52a668be23c28b663294ac40", @"/Views/Card/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f96611a6467f4114bc417bbc3e10c3569ee1d6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Card_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CartViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shop-cont"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "deleteproduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("remove-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
   
    double? totalProductPrice = 0;
    double? totalPrice = 0;

    
    

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
     foreach (var item in Model)
    {
        if (item.DiscountPrice > 0)
        {
            totalProductPrice = item.DiscountPrice;

        }
        else
        {
            totalProductPrice = item.Price;

        }

        totalPrice += totalProductPrice;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<main id=\"cart\">\r\n    <section id=\"cart-body\">\r\n\r\n        <div class=\"container\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ffaf97a2ec9745c52a668be23c28b663294ac406887", async() => {
                WriteLiteral("<i class=\"bi bi-cart4\"></i> Alış-Verişə Davam Et");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br><br>\r\n            <div class=\"row\">\r\n                <div class=\"cart-left col-8\">\r\n                    <h4>SƏBƏTDƏKİ MƏHSULLAR</h4>\r\n                    <div class=\"cart-left-body\">\r\n");
#nullable restore
#line 40 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"cart-item col-12\">\r\n                                <div class=\"cart-item-img col-3\">\r\n");
#nullable restore
#line 44 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                     if (item.IsAccessory == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3ffaf97a2ec9745c52a668be23c28b663294ac409358", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1196, "~/uploads/products/", 1196, 19, true);
#nullable restore
#line 46 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
AddHtmlAttributeValue("", 1215, item.Image, 1215, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                    }
                                    else if (item.ProductId == null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3ffaf97a2ec9745c52a668be23c28b663294ac4011332", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1435, "~/assets/images/decors/", 1435, 23, true);
#nullable restore
#line 50 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
AddHtmlAttributeValue("", 1458, item.Image, 1458, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"

                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3ffaf97a2ec9745c52a668be23c28b663294ac4013285", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1652, "~/uploads/products/", 1652, 19, true);
#nullable restore
#line 55 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
AddHtmlAttributeValue("", 1671, item.Image, 1671, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <div class=\"cart-item-txt col-4\">\r\n                                    <p>");
#nullable restore
#line 59 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <br>\r\n                                    <b style=\"text-decoration:underline;\">Spesifikasiyalar:</b>\r\n                                    <br /><br />\r\n");
#nullable restore
#line 63 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                     if (item.IsAccessory == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p><b>Kəsim:</b> ");
#nullable restore
#line 65 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                    Write(item.Shape);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <p><b>Ölçü: </b> ");
#nullable restore
#line 66 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                    Write(item.Uzunluq);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sm x ");
#nullable restore
#line 66 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                                       Write(item.En);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sm</p>\r\n                                        <p><b>Rəng:</b> ");
#nullable restore
#line 67 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                   Write(item.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                        <p><b>Mərkəzdə Dəlik: </b></p>\r\n");
#nullable restore
#line 69 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p><b>Yapiwqanlig:</b> Tam yapiwgandir</p>\r\n");
#nullable restore
#line 73 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"cart-item-count col-2\">\r\n                                    <small>");
#nullable restore
#line 77 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                      Write(totalProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₼ / hər biri</small>
                                    <div class=""btn-group"">
                                        <button class=""btn btn-warning btn-sm dropdown-toggle"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                            Məhsul sayı
                                        </button>
                                        <div class=""dropdown-menu"">
");
#nullable restore
#line 83 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                             for (int i = 1; i <=item.Count; i++)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <a class=\"dropdown-item \" href=\"#\"");
            BeginWriteAttribute("data", " data=\"", 3569, "\"", 3578, 1);
#nullable restore
#line 85 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
WriteAttributeValue("", 3576, i, 3576, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 85 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 86 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <br><br>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ffaf97a2ec9745c52a668be23c28b663294ac4020478", async() => {
                WriteLiteral("Məhsulu Sil");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                                                          WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"cart-item-price col-1\">\r\n                                    <b class=\"qiymet\">");
#nullable restore
#line 94 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                  Write(item.DiscountPrice>0?item.DiscountPrice:item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</b>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 97 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""cart-right col-4"">
                    <h4>MƏHSULLARIN QİYMƏTİ</h4>
                    <br>
                    <div class=""cart-right-body"">
                        <ul>
");
#nullable restore
#line 106 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>");
#nullable restore
#line 108 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>");
#nullable restore
#line 108 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                 Write(item.DiscountPrice>0?item.DiscountPrice:item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</span></li>\r\n");
#nullable restore
#line 109 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>Shopping & Handling <span>FREE</span></li>\r\n                            <li><b>TOTAL</b><b class=\"pr-right\">");
#nullable restore
#line 112 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Card\Index.cshtml"
                                                           Write(totalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</b></li>\r\n                           \r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 4990, "\"", 4997, 0);
            EndWriteAttribute();
            WriteLiteral(">Proceed to Checkout</a></li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </section>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CartViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
