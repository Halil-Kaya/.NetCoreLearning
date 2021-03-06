#pragma checksum "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d666e61a831bf4890b9194c8ab652613263e5bab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
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
#line 4 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/_ViewImports.cshtml"
using identityLearning;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/_ViewImports.cshtml"
using identityLearning.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/_ViewImports.cshtml"
using identityLearning.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/_ViewImports.cshtml"
using identityLearning.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d666e61a831bf4890b9194c8ab652613263e5bab", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"658e6a65976c31b6fc3a921a7927601f76c55188", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Member/_MemberLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3 class=\"text-center\">Kullanıcı Bilgileri</h3>\n<div class=\"row\">\n\n    <div class=\"col-sm-3\">\n\n        <img");
            BeginWriteAttribute("src", " src=\"", 221, "\"", 241, 1);
#nullable restore
#line 12 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
WriteAttributeValue("", 227, Model.Picture, 227, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100%;height: 100%;\">\n\n    </div>\n    <div class=\"col-sm-9\">\n\n        <table class=\"table table-bordered table-striped\">\n\n            <tr>\n                <th>Kullanıcı Ismi</th>\n                <td>");
#nullable restore
#line 21 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
               Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n            <tr>\n                <th>E-posta</th>\n                <td>");
#nullable restore
#line 25 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n            <tr>\n                <th>Telefon No</th>\n                <td>");
#nullable restore
#line 29 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
               Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n            <tr>\n                <th>City</th>\n                <td>\n                    \n");
#nullable restore
#line 35 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                     if(string.IsNullOrEmpty(@Model.City)){


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span> belirtilmemiş</span>\n");
#nullable restore
#line 38 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"

                    }else{

                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                   Write(Model.City);

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                                   

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n            <tr>\n                <th>Doğum Tarihi</th>\n                <td>\n\n");
#nullable restore
#line 51 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                     if(Model.BirthDay != null){
                    
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                   Write(Model.BirthDay?.ToShortDateString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
                                                            
                    
                    }else{


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span> belirtilmemiş</span>\n");
#nullable restore
#line 58 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n            <tr>\n                <th>Cinsiyet</th>\n                <td>");
#nullable restore
#line 65 "/home/ubunter/Desktop/NetCoreLearning/identityLearning/Views/Member/Index.cshtml"
               Write(Model.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n\n        </table>\n\n    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
