#pragma checksum "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e281327d8ad6f964c1e820989a3a012380193099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts_LogIn), @"mvc.1.0.view", @"/Views/Accounts/LogIn.cshtml")]
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
#line 1 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\_ViewImports.cshtml"
using e_commerce_sample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\_ViewImports.cshtml"
using e_commerce_sample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e281327d8ad6f964c1e820989a3a012380193099", @"/Views/Accounts/LogIn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54395249b066b708fba72e222f33c009598f7b58", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts_LogIn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<e_commerce_sample.Core.Entity.RegisterModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
  
    ViewBag.Title = "Login";
    Layout = "";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e281327d8ad6f964c1e820989a3a0123801930994209", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"row justify-content-md-center\">\r\n    <div class=\"col-md-4\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                Login\r\n            </div>\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 15 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                 using (Html.BeginForm("Login", "Accounts", FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 19 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                   Write(Html.LabelFor(m => m.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 20 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                   Write(Html.TextBoxFor(m => m.UserName, "", new { @class = "form-control", @placeholder = "UserName" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 24 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                   Write(Html.LabelFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 25 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                   Write(Html.PasswordFor(m => m.Password, new { @class = "form-control", @placeholder = "Password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""form-group"">
                        <input type=""submit"" name=""submit"" class=""btn btn-primary"" value=""Login"" />
                        <input type=""button"" name=""register"" class=""btn btn-danger"" value=""Register""");
            BeginWriteAttribute("onclick", " onclick=\"", 1304, "\"", 1373, 5);
            WriteAttributeValue("", 1314, "window.location.href", 1314, 20, true);
            WriteAttributeValue(" ", 1334, "=", 1335, 2, true);
            WriteAttributeValue(" ", 1336, "\'", 1337, 2, true);
#nullable restore
#line 29 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
WriteAttributeValue("", 1338, Url.Action("Register","Accounts"), 1338, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1372, "\'", 1372, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n");
#nullable restore
#line 31 "C:\Users\DavidLin\Documents\Projects_VisualStudio2019\e-commerce-sample\e-commerce-sample\Views\Accounts\LogIn.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<e_commerce_sample.Core.Entity.RegisterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
