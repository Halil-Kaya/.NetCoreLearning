using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identityLearning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace identityLearning.CustomTagHelpers
{
    //kendi tag helperimi Admin in içindeki Users ın içinde user-roles olarak kullandim

    //tag helpers bu class sayesinde kendi tag halpersimi olusturabilirim. Cok onemli bir olay degil ama kodu guzellestiriyor
    //Admin/users ın içindeki html kodunda td etiketinin içine user-roles tagini koydum bu benim tagim bunu alsin dedim
    [HtmlTargetElement( "td" , Attributes = "user-roles" )]
    public class UserRolesName : TagHelper
    {

        //kendi tagimda id yi gonderiyorum o kullanici bulmak icin userManageri kullaniyorum
        public UserManager<AppUser> _userManager { get; set; }
        
        //kullanicinin id si user-roles taginin icinde bu id UserId degiskeninin icine girsin diyiyorum
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }

        public UserRolesName(UserManager<AppUser> userManager){
            this._userManager = userManager;
        }


        //mu metodu override yapiyorum bu kisim bir cikti uretecek
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {  
            //kullaniciyi buluyorum
            AppUser user = await _userManager.FindByIdAsync(UserId);
            
            //kullanicinin rolelerini getiriyorum
            IList<string> roles = await _userManager.GetRolesAsync(user);

            //bir html de gostericem
            string html = string.Empty;

            //kullanicinin rollerini donup htmle ekliyorum
            roles.ToList().ForEach(x => {

                html += $"<span class='badge badge-info'> {x} </span>";

            });

            //cikti olarak veriyorum
            output.Content.SetHtmlContent(html);
        }

    }
}