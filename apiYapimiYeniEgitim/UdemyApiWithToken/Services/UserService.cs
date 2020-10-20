using System;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Repositories;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork){
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public BaseResponse<User>  AddUser(User user)
        {
            try{
                this._userRepository.AddUser(user);
                this._unitOfWork.Complete();
                return new BaseResponse<User>(user);
            }catch(Exception e){
                return new BaseResponse<User>($"kullanici eklenirken bir hata oldu: {e.Message}");
            }
        }

        public BaseResponse<User> FindByEmailAndPassword(string email, string password)
        {

            try{
                User user = this._userRepository.FindByEmailAndPassword(email,password);

                if(user == null){

                    return new BaseResponse<User>("böyle bir kullanici bulunamadi");
                }
            
                return new BaseResponse<User>(user);

            }catch(Exception e){


                return new BaseResponse<User>($"kullanici bulunurken bir hata oldu: {e.Message}");

            }

        }

        public BaseResponse<User> FindById(int userId)
        {

            try{

                User user = this._userRepository.FindById(userId);

                if(user == null){
                    return new BaseResponse<User>("Kullanici bulunamadi");
                }

                return new BaseResponse<User>(user);

            }catch(Exception e){
                
                return new BaseResponse<User>($"Kullanici bulunurken bir hata oldu {e.Message}");


            }

        }

        public BaseResponse<User> GetUserWithRefreshToken(string refreshToken)
        {

            try{

                User user = this._userRepository.GetUserWithRefreshToken(refreshToken);

                if(user == null){
                    return new BaseResponse<User>("kullanici bulunamadi");
                }

                return new BaseResponse<User>(user);

            }catch(Exception e){

                return new BaseResponse<User>($"kullanici bulunurken bir hata oldu: " + e.Message);

            }

        }

        public void RemoveRefreshToken(User user)
        {

            try{

                this._userRepository.RemoveRefreshToken(user);
                this._unitOfWork.Complete();

            }catch(Exception){
                //loglama yapilabilir
            }

        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {

            try{
                
                this._userRepository.SaveRefreshToken(userId,refreshToken);
                this._unitOfWork.Complete();

            }catch(Exception){
                //loglama yapilabilir
            }
        }
    }
}