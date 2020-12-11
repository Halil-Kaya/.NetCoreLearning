using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace UdemyIdentityServer.AuthServer
{
    //! buranın yaptığı iş şu hangi api için hangi izinler var
    public static class Config
    {
        //inan bana çok basit!
        /*Öncelikle burda özetlemem lazım neyin ne olduğunu
            burda 3 tane fonksiyonumuz var ondan önce sana bunların neden yapıldığını anlatmam daha iyi olur böylece kafanda
            hayal etmiş olursun
            bir client hangi api ye hangi endpointlerine istek atma yetkisi olduğunu ayarlamak için arada bir identityServer katmanımız var
            burda yaptığımız şu client önce buraya istek atıyor burdan bir token alıyor şimdi asıl meseleye geliyoruz kişiye verilen bu tokenin içinde ne var?
            işte aşağıda tanımladığımız ayarladağımız işler
            GetClients -> bu fonksiyonda identity serverdan token alabilecek client bilgileri bulunuyor diyelim ki client1 olarak istek atsın
            client1 in içinde
                                ClientId = "Client1",
                    ClientName="Client 1 app uygulaması",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= {"api1.read"}
                    bilgileri var burda clientId = Client1 olduğu için burasıyla eşleşti burda AllowedScopes kısmı önemli
                    çünkü orda cliente api1.read iznini alabileceğini söyledik bunu tokenin içine yazıp tokenı cliente gönderdik
                    tokenı okursak eğer aud olarak resource_api1 i görücez yani bu resource_api1 in amacı izinleri derli toplu göstermekj
            amaç bir düzende gözüksün resource_api1 in içinde => api1.read, api1.write, api1.update var
            tokenin içindeki scope kısmında ise yetkileri yani api.read bilgisi var

            eğer Client2 yi gönderirsek bu sefer scope kısmında 

                new Client()
                {
                    ClientId = "Client2",
                    ClientName="Client 2 app uygulaması",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= {"api1.read" ,"api2.write","api2.update"}
                }

                olduğu için api1.read, api2.write ve api2.update yetkisi olucak
            bu seferde aud kısmında ise resource_api1 ve resource_api2 olucak bunun sebebi api1.read resource_api1 in içindeyken
            api2.update ve api2.write resource_api2 nin içinde olması bu yüzden aud yani dağıtıcısında 2 side var

            Peki bunları nerde kullanıyoruz? diye soracak olursan claim olarak yani policy olarak api programında alıp endpoinlerin başına yazıyorum
            böylece yetki işlemlerini halletmiş oluyorum zekice dimi

        */

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1"){

                    Scopes={ "api1.read","api1.write","api1.update" },
                    //şifre verebiliyorum
                    ApiSecrets = new []{new Secret("secretapi1".Sha256())} 
                    
                
                },
                new ApiResource("resource_api2"){
                
                    Scopes={ "api2.read","api2.write","api2.update"},
                    ApiSecrets = new []{new Secret("secretapi2".Sha256())} 
                
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                
                new ApiScope("api1.read","API 1 için okuma izni"),
                new ApiScope("api1.write","API 1 için yazma izni"),
                new ApiScope("api1.update","API 1 için güncelleme izni"),
                
                new ApiScope("api2.read","API 2 için okuma izni"),
                new ApiScope("api2.write","API 2 için yazma izni"),
                new ApiScope("api2.update","API 2 için güncelleme izni"),

            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId = "Client1",
                    ClientName="Client 1 app uygulaması",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= {"api1.read"}
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName="Client 2 app uygulaması",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= {"api1.read","api1.update" ,"api2.write","api2.update"}
                },

                //Client1 programı için bir client
                new Client()
                {
                    ClientId = "Client1-Mvc",
                    RequirePkce = false,
                    ClientName="Client 1 app mvc uygulaması",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.Hybrid,
                    //client1 login olduktan sonra token bilgileri nereye gitcek burdaki url ye gidecek
                    RedirectUris = new List<string>(){"https://localhost:44315/signin-oidc"},
                    //client1 çıkış yaptığını nasıl anlıyacak buraya giderek
                    PostLogoutRedirectUris = new List<string>(){"https://localhost:44315/signout-callback-oidc"},
                    AllowedScopes= {IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,"api1.read",IdentityServerConstants.StandardScopes.OfflineAccess},
                    AccessTokenLifetime = 2*60*60,
                    AllowOfflineAccess = true,
                    //ReUse seçeneğinin anlamı refresh tokenı kullandığımda refresh token değişmiyor
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,

                    //hangi bilgiler paylasilacak onu gosteriyor yani onay sayfasi aslinda
                    RequireConsent = true
                
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources(){
            
            return new List<IdentityResource>(){

                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),

            };
        }

        public static IEnumerable<TestUser> GetUsers(){

            return new List<TestUser>(){

                new TestUser(){
                    
                    SubjectId = "1",Username = "halil",Password = "password",Claims = new List<Claim>(){
                    new Claim("given_name","Halil"),
                    new Claim("family_name","Kaya")
                    }
                },

                new TestUser(){
                    
                    SubjectId = "2",Username = "ahmet",Password = "password",Claims = new List<Claim>(){
                    new Claim("given_name","Ahmet"),
                    new Claim("family_name","Ak")
                    }
                }


            };
        }

    }
}