using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult RoleAssign(string id){
            
            //kullanicinin id sini tempte sakliyorum bunun post işleminde bana lazim olucak
            TempData["userId"] = id;

            AppUser user = _userManager.FindByIdAsync(id).Result;

            ViewBag.userName = user.UserName;
            


            //bütün rolleri getiriyorum
            IQueryable<AppRole> roles = _roleManager.Roles;
            
            //kullanıcının rollerini getiriyorum
            List<string> userRoles =  _userManager.GetRolesAsync(user).Result as List<string>;

            //webe döneceğim yapı
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            //bütün rolleri dolaşıyorum
            foreach (var role in roles)
            {
                //yeni roleri göstereceğim obje oluşturuyorum
                RoleAssignViewModel r = new RoleAssignViewModel();

                r.RoleId = role.Id;
                r.RoleName = role.Name;
                
                //eğer kullanıcıda bu rol varsa true yapıyorum yoksa false yapıyorum
                if(userRoles.Contains(role.Name)){

                    r.Exist = true;
                
                }else{

                    r.Exist = false;

                }

                roleAssignViewModels.Add(r);
                
            }

            //bütün rolleri kullanıcıya göre ayarlanmış bir şekilde döndürüyorum
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> roleAssignViewModels){

            AppUser user = _userManager.FindByIdAsync(TempData["userId"].ToString()).Result;


            foreach (var role in roleAssignViewModels)
            {

                if(role.Exist){

                    await _userManager.AddToRoleAsync(user,role.RoleName);

                }else{
                    await _userManager.RemoveFromRoleAsync(user,role.RoleName);
                }
                
            }


            return RedirectToAction("Users");
        }
    

    }
}