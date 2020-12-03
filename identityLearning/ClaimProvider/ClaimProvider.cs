using System;
using System.Security.Claims;
using System.Threading.Tasks;
using identityLearning.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace identityLearning.ClaimProvider
{
    public class ClaimProvider : IClaimsTransformation
    {

        //kisitlama islemlerinde policy diye bir adlandirma kullaniyorum kisitlandirmalari startup ta belirtiyorum

        private readonly UserManager<AppUser> _userManager;

        public ClaimProvider(UserManager<AppUser> userManager){
            this._userManager = userManager;
        }



        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            //principal aslinda User objesi!

            if(principal != null && principal.Identity.IsAuthenticated){

                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;

                AppUser user = await _userManager.FindByNameAsync(identity.Name);

                if(user != null){
                    
                    //sadece yasi 15 den buyuk olanlara bir sayfayi yada bir seyleri gostermek istiyorsun diyelim o zaman kisinin cookie sine 
                    //bir bilgi ekliyelim
                    if( user.BirthDay != null ){

                        var today = DateTime.Today;
                        var age = today.Year - user.BirthDay?.Year;
                        //yasi 15 den buyukse buraya girecek
                        if(age > 15){   

                            //yasi 15 den buyuk kisiler sisteme girdiginde cookie bilgisinin icinde Violence bilgisi olacak ben boylece kisi 15 den büyük mü küçük mü anlamış olucam
                            //ilk parametre bu claimin ismi, 2.parametre ise degeri, 3. nde ise bunun string oldugunu soyluyorum 4. ise dagıtıcı adını kafama gore bir isim girebilirim
                            //dagıtıcı ismi kafani karistirabilir onuda soyle anlatayim diyelim ki facebook ile giris yapti o zamanda dagitici ismi facebook olucak yani bu bilginin facebooktan geldigini
                            //anlamis olucam internal isminde ise bunu ben koydugumu anliyacam
                            Claim violenceClaim = new Claim("violence",true.ToString(),ClaimValueTypes.String,"Internal");

                            //claimi ekliyorum
                            identity.AddClaim(violenceClaim);

                        }






                    }



                    if( user.City != null){
                        
                        //kullanicida boyle bir claim var mi diye kontrol ediyorum eger boyle bir claim yoksa ekliyecem var ise eklememe gerek yok zaten var
                        //User.HasClaim olarak dusun zaten principal aslinda User Objesi
                        if( !principal.HasClaim(c => c.Type == "city") ){
                            //cookie ye city yi ekliyorum deger olarak da kisinin sehrini giriyorum
                            Claim cityClaim = new Claim("city",user.City,ClaimValueTypes.String,"Internal");

                            identity.AddClaim(cityClaim);

                        }

                    }

                }

            }

            return principal;

        }
    }
}