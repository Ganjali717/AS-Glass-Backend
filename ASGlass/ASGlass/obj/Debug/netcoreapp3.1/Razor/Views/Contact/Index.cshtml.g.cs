#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "399bcedc7216d5ae27bebed3087eb5ba498a1a44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"399bcedc7216d5ae27bebed3087eb5ba498a1a44", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f96611a6467f4114bc417bbc3e10c3569ee1d6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<main id=""contact"">
    <section id=""con-head"">
        <div class=""container"">
            <h2>
               AS G??zg?? v?? ???????? il?? ??laq?? saxlay??n
            </h2>
            <br>
            <p>
                Dulles Glass & Mirror offers a Virginia Glass Showroom and a Maryland Glass Showroom for your
                convenience. You are always welcome to stop by either showroom to see the latest designs,
                innovations and styles available in today's glass, glass shower doors and mirrors.
            </p>
            <br>
            <p>Dig??r suallar ??????n z??ng edin</p>
            <br>
            <ul>
                <li>
                    <p><b>??laq?? n??mr??si: </b> ");
#nullable restore
#line 20 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Contact\Index.cshtml"
                                         Write(Model.Setting.SupportPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </li>\r\n                <li>\r\n                    <p><b>Fax: </b> 012 567 11 02</p>\r\n                </li>\r\n                <li>\r\n                    <p><b>Email ??nvan??: </b>");
#nullable restore
#line 26 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Contact\Index.cshtml"
                                       Write(Model.Setting.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </li>
            </ul>
        </div>
    </section>

    <section id=""con-body"">
        <div class=""container"">
            <div class=""row"">
                <div class=""con-form col-6"">
                    <h5>AS Glass G??zg?? v?? ???????? Servisin?? Email g??nd??rin</h5>
                    <hr>
                    <small>Sual??n??z var? G??zg?? v?? ???????? ekspertind??n soru??un!</small>
                    <br><br>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "399bcedc7216d5ae27bebed3087eb5ba498a1a446368", async() => {
                WriteLiteral("\r\n                            <label");
                BeginWriteAttribute("for", " for=\"", 1500, "\"", 1506, 0);
                EndWriteAttribute();
                WriteLiteral(">Email ??nvan??<i class=\"bi bi-asterisk\"></i></label>\r\n                            <br>\r\n                            <input type=\"text\" placeholder=\"Email adresini daxil edin\">\r\n                            <br><br>\r\n                            <label");
                BeginWriteAttribute("for", " for=\"", 1755, "\"", 1761, 0);
                EndWriteAttribute();
                WriteLiteral(">Ad<i class=\"bi bi-asterisk\"></i></label>\r\n                            <br>\r\n                            <input type=\"text\" placeholder=\"Adinizi daxil edin\">\r\n                            <br><br>\r\n                            <label");
                BeginWriteAttribute("for", " for=\"", 1993, "\"", 1999, 0);
                EndWriteAttribute();
                WriteLiteral(">Mobil n??mr??<i class=\"bi bi-asterisk\"></i></label>\r\n                            <br>\r\n                            <input type=\"number\" placeholder=\"Telefon nomrenizi daxil edin\">\r\n                            <br><br>\r\n                            <label");
                BeginWriteAttribute("for", " for=\"", 2252, "\"", 2258, 0);
                EndWriteAttribute();
                WriteLiteral(">M??ktub yaz <i class=\"bi bi-asterisk\"></i></label>\r\n                            <br>\r\n                            <textarea");
                BeginWriteAttribute("name", " name=\"", 2382, "\"", 2389, 0);
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 2390, "\"", 2395, 0);
                EndWriteAttribute();
                WriteLiteral(" cols=\"30\" rows=\"10\" placeholder=\"Mesajinizi daxil edin\"></textarea>\r\n                            <br><br>\r\n                            <div class=\"form-check row\">\r\n                                <input class=\"form-check-input\" type=\"checkbox\"");
                BeginWriteAttribute("value", " value=\"", 2641, "\"", 2649, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""flexCheckChecked"">
                                <label class=""form-check-label"" for=""flexCheckChecked"">
                                    X??susi endiriml??r v?? yeni m??hsul haqq??nda m??lumat ??ld?? etm??k ??????n m??ni qeydiyyatdan ke??irin.
                                </label>
                            </div>
                            <br><br>
                            <p>
                                E-po??t ??nvan??n??z?? v?? ya dig??r m??lumatlar??n??z?? ??????nc?? t??r??fl??rl?? <b>payla??mayaca????q.</b>
                                <a");
                BeginWriteAttribute("href", " href=\"", 3198, "\"", 3205, 0);
                EndWriteAttribute();
                WriteLiteral(">Qanun v?? Qaydan??</a> oxuyun.\r\n                            </p>\r\n                            <br>\r\n                            <input type=\"submit\" value=\"G??ND??R\" class=\"text-white\">\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""con-address col-6"">
                    <h5>Ofisimiz</h5>
                    <hr>
                    <p><b>Phone: </b>050 593 40 40</p>
                    <p>M??hasibat u??otu il?? ba??l?? b??t??n sor??ular??n??z?? a??a????dak?? ??nvana g??nd??rin.</p>
                    <br>
                    <b>Ma??azan??n ??nvan??:</b>
                    <br>
                    <p>
                        ");
#nullable restore
#line 81 "C:\Users\LENOVO\OneDrive\Desktop\AS-Glass-Backend\ASGlass\ASGlass\Views\Contact\Index.cshtml"
                   Write(Model.Setting.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  
                    </p>
                    <br>
                    <h5>Emalatxana:</h5>
                    <p><b>Phone: </b>050 593 40 40</p>
                    <b>Emalatxanan??n ??nvan??:</b>
                    <br>
                    <p>
                       Bak?? ????h??ri, Bil??c??ri q??s??b??si
                    </p>
                </div>
            </div>
        </div>
    </section>
</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
