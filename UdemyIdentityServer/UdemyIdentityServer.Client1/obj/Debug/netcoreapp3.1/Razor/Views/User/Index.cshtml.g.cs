#pragma checksum "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff241611dae853fbd247f9bbfb6493305f3e1c79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\_ViewImports.cshtml"
using UdemyIdentityServer.Client1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\_ViewImports.cshtml"
using UdemyIdentityServer.Client1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff241611dae853fbd247f9bbfb6493305f3e1c79", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47be26540ee4e53df07cb6edb8e9a16efe40df8", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "LogOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetRefreshToken", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff241611dae853fbd247f9bbfb6493305f3e1c795129", async() => {
                WriteLiteral("Çıkış yap");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff241611dae853fbd247f9bbfb6493305f3e1c796370", async() => {
                WriteLiteral("Refresh token yenile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h3>Bu sayfayı sadece üye olan kullanıcılar görebilir.???</h3>\r\n\r\n<h2>Hoş Geldin ");
#nullable restore
#line 10 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h4>Claim verileri</h4>\r\n\r\n<table class=\"table table-bordered\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <th>Claim Type</th>\r\n            <th>Claim Value</th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
         foreach (var item in User.Claims)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
               Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
               Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </tbody>

</table>

<h4>Authentication Verileri</h4>

<table class=""table table-bordered"">

    <thead>
        <tr>
            <th>Auth property Key</th>
            <th>Auth property Value</th>
        </tr>
    </thead>

    <tbody>

");
#nullable restore
#line 51 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
         foreach (var item in (await Context.AuthenticateAsync()).Properties.Items)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 55 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
               Write(item.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"
               Write(item.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\hibra\OneDrive\Desktop\UdemyIdentityServer4\NetCoreLearning\UdemyIdentityServer\UdemyIdentityServer.Client1\Views\User\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
