#pragma checksum "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Account/ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edfe7aeee7a75134b41b8d57e74d3e6f977ad71b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ResetPassword), @"mvc.1.0.view", @"/Views/Account/ResetPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edfe7aeee7a75134b41b8d57e74d3e6f977ad71b", @"/Views/Account/ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd226c1f2d6a59590df7a514449febd42858bcb1", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResetPasswordModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1 class=""h3"">Login</h1>
<hr>

<div class=""row"">
    <div class=""col-md-8"">
        <form asp-controller=""Account"" asp-action=""ResetPassword"" method=""POST"">
        <div asp-validation-summary=""All"" class=""text-danger""></div>      
        <input type=""hidden"" name=""Token""");
            BeginWriteAttribute("value", " value=\"", 301, "\"", 321, 1);
#nullable restore
#line 10 "/home/deeper/Desktop/netCoreLearning/temelOzellikler/shopapp/shopapp.webui/Views/Account/ResetPassword.cshtml"
WriteAttributeValue("", 309, Model.Token, 309, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
            WriteLiteral(@"
         <div class=""form-group row"">
            <label asp-for=""Email"" class=""col-sm-2 col-form-label""></label>
            <div class=""col-sm-10"">
                <input class=""form-control"" name=""Email"" >
            </div>
        </div>   
         <div class=""form-group row"">
            <label asp-for=""Password"" class=""col-sm-2 col-form-label""></label>
            <div class=""col-sm-10"">
                <input class=""form-control"" name=""Password"">
            </div>
        </div>       
        

        <div class=""form-group row"">
            <div class=""col-sm-10 offset-sm-2"">
                <button type=""submit"" class=""btn btn-primary"">Login</button>
            </div>
        </div>
    </form>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script src=\"/modules/jquery-validation/dist/jquery.validate.min.js\"></script>\n    <script src=\"/modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js\"></script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResetPasswordModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
