#pragma checksum "/home/minter/Desktop/netCoreLearning/netCoreLearning/apiYapimiYeniEgitim/SpaWebApplication/Views/Home/Spa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e127815ca625e4b84307ded8a19e69032f39ccc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Spa), @"mvc.1.0.view", @"/Views/Home/Spa.cshtml")]
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
#line 1 "/home/minter/Desktop/netCoreLearning/netCoreLearning/apiYapimiYeniEgitim/SpaWebApplication/Views/_ViewImports.cshtml"
using SpaWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/minter/Desktop/netCoreLearning/netCoreLearning/apiYapimiYeniEgitim/SpaWebApplication/Views/_ViewImports.cshtml"
using SpaWebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e127815ca625e4b84307ded8a19e69032f39ccc", @"/Views/Home/Spa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a07f28db99759fbd470db43f65c2032568156f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Spa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    \n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script> 
        
        $(document).ready(function(){
            

            var token = localStorage.getItem(""token"");

            if(token == null){
                $("".loginDiv"").show()
                $("".userDiv"").hide()
            }else{

                $("".loginDiv"").hide()
                $("".userDiv"").show()
            

            }


            $(""#btnSave"").click(function(){

                let name = $(""#Name"").val()
                let surName = $(""#SurName"").val()
                let email = $(""#Email"").val()
                let password = $(""#Password"").val()

                let user = 
                    {
                        ""Name"":name,
                        ""SurName"" : surName,
                        ""Email"" : email,
                        ""Password"" : password
                    }


                var url = ""https://localhost:5001/api/user""

                $.ajax({

                    type:""POST"",
                    crossDomain : true,
                   ");
                WriteLiteral(@" url : url,
                    data : JSON.stringify(user),
                    success : function(data){
                        console.table(data)
                    },
                    error : function(error){

                    },
                    contentType : ""application/json"",
                    dataType : ""json""
                })

            })

            getUserDataRefreshToken(){

                let refreshToken  = localStorage.getItem(""refreshToken"")

                var data = {""RefreshToken"" : refreshToken}

                let url = ""https://localhost:5001/api/login/RefreshToken""

                $.ajax({
                    type: ""POST"",
                    url : url,
                    async : false,
                    crossDomain : true,
                    data : JSON.stringify(data),
                    success : function(){

                        
                        localStorage.setItem(""token"",data.token)
                        localStorage.setItem(""refreshToke");
                WriteLiteral(@"n"",data.refreshToken)
                        getUserData()

                    },
                    error : function(){

                    },
                    contentType : ""application/json""
                    dataType : ""json""
                })
            }

            function getUserData(){

                var url = ""https://localhost:5001/api/user""

                let accessToken  = localStorage.getItem(""token"")

                $.ajax({
                    type : ""GET"",
                    url:url,
                    async : false,
                    crossDomain : true,
                    beforeSend: function(xhr){
                        xhr.setRequestHeader(""Authorization"",""Bearer "" + accessToken)
                    },
                    statusCode : {

                        401: function(){
                            getUserDataRefreshToken()
                        },
                        
                    },
                    success : function(data){

               ");
                WriteLiteral(@"         $("".loginDiv"").hide()
                        $("".userDiv"").show().html("""").append(`
                        <table class=""table"">
                            <tr> 
                                <th>Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Email</th>
                            </tr>
                            <tr>
                                <td>${data.id}</td>
                                <td>${data.name}</td>
                                <td>${data.surname}</td>
                                <td>${data.email}</td>
                            </tr>    
                        </table>`)        

                    },
                    error : function(err){

                    },
                    
                    contentType : ""application/json"",
                    dataType : ""json""
                
                })

            }

            $(""#btnLogin"").click(f");
                WriteLiteral(@"unction(){

                let email = $(""#LoginEmail"").val()
                let password = $(""#LoginPassword"").val()

                let user = 
                    {
                        ""Email"" : email,
                        ""Password"" : password
                    }


                var url = ""https://localhost:5001/api/login/AccessToken""

                $.ajax({
                    type:""POST"",
                    crossDomain : true,
                    url : url,
                    data : JSON.stringify(user),
                    success : function(data){
                        console.table(data)
                        localStorage.setItem(""token"",data.token)
                        localStorage.setItem(""refreshToken"",data.refreshToken)
                        getUserData()
                    },
                    error : function(error){

                    },
                    contentType : ""application/json"",
                    dataType : ""json""
                })

            })");
                WriteLiteral("\n\n\n\n\n        })\n\n    </script>\n\n");
            }
            );
            WriteLiteral("\n\n<div class=\"container\">\n\n    <div class=\"row\">\n\n        <div class=\"col-md-6\">\n\n            <h2>Üye Kayıt formu</h2>\n\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e127815ca625e4b84307ded8a19e69032f39ccc8993", async() => {
                WriteLiteral(@"

                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" id=""Name"" placeholder=""isminiz"" value=""halil"">
                </div>
                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" id=""SurName"" placeholder=""soy isminiz"" value=""kaya"">
                </div>
                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" id=""Email"" placeholder=""email"" value=""hlk@gmail.com"">
                </div>
                <div class=""form-group"">
                    <input type=""password"" class=""form-control"" id=""Password"" placeholder=""sifreniz"" value=""1234"">
                </div>

                <button type=""button"" id=""btnSave"" class=""btn btn-primary"">Kaydet</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n        </div>\n\n        <div class=\"col-md-6\">\n            \n\n            <div class=\"userDiv\">\n\n            </div>\n\n            <div class=\"loginDiv\" style=\"display: none;\">\n                <h2>Üye Giriş Formu</h2>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e127815ca625e4b84307ded8a19e69032f39ccc11320", async() => {
                WriteLiteral(@"

                    <div class=""form-group"">
                        <input type=""text"" class=""form-control"" id=""LoginEmail"" placeholder=""email"" value=""hlk@gmail.com"">
                    </div>
                    <div class=""form-group"">
                        <input type=""password"" class=""form-control"" id=""LoginPassword"" placeholder=""sifreniz"" value=""1234"">
                    </div>
                    <button type=""button"" class=""btn btn-success"" id=""btnLogin"">Giriş</button>

                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </div>\n        </div>\n\n    </div>\n\n</div>");
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
