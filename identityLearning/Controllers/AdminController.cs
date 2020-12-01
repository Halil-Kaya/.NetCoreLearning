using System.Linq;
using identityLearning.Models;
using identityLearning.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identityLearning.Controllers
{
    public class AdminController : BaseController
    {


        public AdminController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager):base(userManager,roleManager){}


        public IActionResult Index(){
            return View();
        }

        public IActionResult Users(){
            return View(_userManager.Users.ToList());
        }
        
        public IActionResult RoleCreate(){
            return View();
        }


        [HttpPost]
        public IActionResult RoleCreate(RoleViewModel roleViewModel){

            AppRole role = new AppRole();
            
            role.Name = roleViewModel.Name;

            //role oluşturuyorum
            IdentityResult result = _roleManager.CreateAsync(role).Result;

            if(result.Succeeded){
                return RedirectToAction("Roles");
            }

            AddModelError(result);


            return View(roleViewModel);
        }


        public IActionResult Roles(){
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult RoleDelete(string id){
            
            AppRole role = _roleManager.FindByIdAsync(id).Result;
            
            if(role != null){

                IdentityResult result = _roleManager.DeleteAsync(role).Result;

            }

            return RedirectToAction("Roles");

        }

        public IActionResult RoleUpdate(string id){
            
            AppRole role = _roleManager.FindByIdAsync(id).Result;
            
            if(role != null){
                
                return View(role.Adapt<RoleViewModel>());

            }

            return RedirectToAction("Roles");

        }


        [HttpPost]
        public IActionResult RoleUpdate(RoleViewModel roleViewModel){

            AppRole role = _roleManager.FindByIdAsync(roleViewModel.Id).Result;

            if(role != null){
                role.Name = roleViewModel.Name;

                IdentityResult result = _roleManager.UpdateAsync(role).Result;

                if(result.Succeeded){

                    return RedirectToAction("Roles");

                }

                AddModelError(result);
                


            }else{

                ModelState.AddModelError("","Güncelleme işi başarısız oldu");

            }

            return View(roleViewModel);
        }
    

    }
}