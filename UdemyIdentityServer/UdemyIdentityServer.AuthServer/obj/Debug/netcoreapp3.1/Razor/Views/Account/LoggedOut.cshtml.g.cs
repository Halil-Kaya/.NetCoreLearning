#pragma checksum "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e9c7dae5b60c2df8d78f3abad7bac8cd62882e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_LoggedOut), @"mvc.1.0.view", @"/Views/Account/LoggedOut.cshtml")]
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
#line 1 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\_ViewImports.cshtml"
using IdentityServerHost.Quickstart.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9c7dae5b60c2df8d78f3abad7bac8cd62882e6", @"/Views/Account/LoggedOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a00496e1714fb62801584a343cc1019e13a800a", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_LoggedOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoggedOutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signout-redirect.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
   
    // set this so the layout rendering sees an anonymous user
    ViewData["signed-out"] = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"logged-out-page\">\r\n    <h1>\r\n        Logout\r\n        <small>You are now logged out</small>\r\n    </h1>\r\n\r\n");
#nullable restore
#line 14 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
     if (Model.PostLogoutRedirectUri != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            Click <a class=\"PostLogoutRedirectUri\"");
            BeginWriteAttribute("href", " href=\"", 375, "\"", 410, 1);
#nullable restore
#line 17 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
WriteAttributeValue("", 382, Model.PostLogoutRedirectUri, 382, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">here</a> to return to the\r\n            <span>");
#nullable restore
#line 18 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
             Write(Model.ClientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> application.\r\n        </div>\r\n");
#nullable restore
#line 20 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
     if (Model.SignOutIframeUrl != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <iframe width=\"0\" height=\"0\" class=\"signout\"");
            BeginWriteAttribute("src", " src=\"", 622, "\"", 651, 1);
#nullable restore
#line 24 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
WriteAttributeValue("", 628, Model.SignOutIframeUrl, 628, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></iframe>\r\n");
#nullable restore
#line 25 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 30 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
     if (Model.AutomaticRedirectAfterSignOut)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e9c7dae5b60c2df8d78f3abad7bac8cd62882e66993", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.AuthServer\Views\Account\LoggedOut.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoggedOutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
