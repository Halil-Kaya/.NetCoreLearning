#pragma checksum "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9047806f80f5db97fe491de84e6e2230fbc749"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Details), @"mvc.1.0.view", @"/Views/Shop/Details.cshtml")]
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
#line 1 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using shopapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using shopapp.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using temelOzellikler.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9047806f80f5db97fe491de84e6e2230fbc749", @"/Views/Shop/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd226c1f2d6a59590df7a514449febd42858bcb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link p-0 mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n    <div class=\"row\">\n        <div class=\"col-md-4\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5d9047806f80f5db97fe491de84e6e2230fbc7494305", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 102, "~/img/", 102, 6, true);
#nullable restore
#line 5 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
AddHtmlAttributeValue("", 108, Model.Product.ImageUrl, 108, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n        <div class=\"col-md-8\">\n                <h1 class=\"mb-3\">");
#nullable restore
#line 8 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                            Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1> <hr>\n\n");
#nullable restore
#line 10 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                 foreach (var category in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d9047806f80f5db97fe491de84e6e2230fbc7496530", async() => {
#nullable restore
#line 12 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                                                                                 Write(category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 369, "~/shop/list/", 369, 12, true);
#nullable restore
#line 12 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
AddHtmlAttributeValue("", 381, category.Url, 381, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("                \n");
#nullable restore
#line 13 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \n                \n                <div class=\"mb-3\">\n                    \n                    <h4 class=\"text-primary mb-3\">\n                        <i class=\"fas fa-lira-sign\"></i>");
#nullable restore
#line 19 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                                                   Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </h4>
                    <button type=""submit"" class=""btn btn-primary btn-lg"">Add To Cart</button>

                </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <p class=""p-3"">");
#nullable restore
#line 28 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Shop/Details.cshtml"
                      Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        </div>\n    </div>\n\n<script>\n\n    title.forEach(element => {\n\n        if(element.classList.value.includes(\"active\") == true){\n           \n            element.className = element.className.replace(\"active\",\"\")\n \n        }\n    })\n\n\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
