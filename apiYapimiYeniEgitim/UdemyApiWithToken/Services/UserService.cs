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

        public UserResponse AddUser(User user)
        {
            try{
                this._userRepository.AddUser(user);
                this._unitOfWork.Complete();
                return new UserResponse(user);
            }catch(Exception e){
                return new UserResponse($"kullanici eklenirken bir hata oldu: {e.Message}");
            }
        }

        public UserResponse FindByEmailAndPassword(string email, string password)
        {

            try{

                User user = this._userRepository.FindByEmailAndPassword(email,password);

                if(user == null){

                    return new UserResponse("böyle bir kullanici bulunamadi");

                }

                return new UserResponse(user);

            }catch(Exception e){

                return new UserResponse($"kullanici bulunurken bir hata oldu: {e.Message}");

            }

        }

        public UserResponse FindById(int userId)
        {

            try{

                User user = this._userRepository.FindById(userId);

                if(user == null){
                    return new UserResponse("Kullanici bulunamadi");
                }

                return new UserResponse(user);

            }catch(Exception e){
                
                return new UserResponse($"Kullanici bulunurken bir hata oldu {e.Message}");


            }

        }

        public UserResponse GetUserWithRefreshToken(string refreshToken)
        {

            try{

                User user = this._userRepository.GetUserWithRefreshToken(refreshToken);

                if(user == null){
                    return new UserResponse("kullanici bulunamadi");
                }

                return new UserResponse(user);

            }catch(Exception e){

                return new UserResponse($"kullanici bulunurken bir hata oldu: " + e.Message);

            }

        }

        public void RemoveRefreshToken(User user)
        {

            try{

                this._userRepository.RemoveRefreshToken(user);

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