#pragma checksum "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25003e9ec9d7a5829e86372ea3ab6cd73b8f4a36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/_ViewImports.cshtml"
using temelOzellikler.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25003e9ec9d7a5829e86372ea3ab6cd73b8f4a36", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e20b9bcfa3d05e6c3f17c2ca60401a61e625fcf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25003e9ec9d7a5829e86372ea3ab6cd73b8f4a363039", async() => {
                WriteLiteral(@"
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" integrity=""sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z"" crossorigin=""anonymous"">
        <title>Document</title>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25003e9ec9d7a5829e86372ea3ab6cd73b8f4a364371", async() => {
                WriteLiteral("\n\n");
#nullable restore
#line 13 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
         if (IsSectionDefined("MessageBox"))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
       Write(RenderSection("MessageBox"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
                                                
        }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-primary text-center m-0\">\n                Welcome\n            </div>\n");
#nullable restore
#line 20 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n");
                WriteLiteral("        ");
#nullable restore
#line 25 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
   Write(await Html.PartialAsync("_navbar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n        ");
#nullable restore
#line 26 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
   Write(await Html.PartialAsync("_header"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n    <main>\n        <div class=\"container\">\n\n");
#nullable restore
#line 31 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
     if(IsSectionDefined("Categories")){


#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"row\">\n            <div class=\"col-md-3\">\n                ");
#nullable restore
#line 35 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
           Write(RenderSection("Categories",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </div>\n            <div class=\"col-md-9\">\n\n\n");
                WriteLiteral("\n                ");
#nullable restore
#line 44 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                \n            </div>\n        </div>        \n");
#nullable restore
#line 48 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"

    }else{


#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"row\">\n            <div class=\"col-md-12\">\n                ");
#nullable restore
#line 53 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </div>\n        </div>\n");
#nullable restore
#line 56 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"

    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n\n\n        </div>\n    </main>\n\n");
                WriteLiteral("    ");
#nullable restore
#line 67 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/Views/Shared/_Layout.cshtml"
Write(RenderSection("Scripts",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
