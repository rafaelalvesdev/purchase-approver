using AutoMapper;
using Safeweb.PurchaseApprover.Common.Extensions;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Services.Enums;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Messages;
using SafeWeb.PurchaseApprover.Services.Results;
using SafeWeb.PurchaseApprover.Services.Extensions;
using SafeWeb.PurchaseApprover.Resources;
using SafeWeb.PurchaseApprover.Infrastructure.Strategies;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository Repository { get; set; }
        private IUserProfileRepository ProfileRepository { get; set; }

        public UserService(IUserRepository repository, IUserProfileRepository profileRepository)
        {
            this.Repository = repository;
            this.ProfileRepository = profileRepository;
        }

        public ServiceResult Save(SaveUserMessage message)
        {
            User user;
            CrudOperation operation;
            if (message.ID.HasValidIdValue())
            {
                user = Repository.GetById(message.ID);
                operation = CrudOperation.Update;
                if (user == null)
                    return new ServiceResult().SetInvalid().WithMessage(ValidationResources.User_NotFound);

                Mapper.Map(message, user);
            }
            else
            {
                user = Mapper.Map<User>(message);
                operation = CrudOperation.Create;
            }

            if (message.UserProfileID.HasValidIdValue())
                user.UserProfile = ProfileRepository.GetById(message.UserProfileID);

            var validation = new UserValidator().Execute(user);
            if (!validation.IsValid)
                return Mapper.Map<ServiceResult>(validation);

            switch (operation)
            {
                case CrudOperation.Create:
                    Repository.Create(user);
                    break;
                case CrudOperation.Update:
                    Repository.Update(user);
                    break;
            }

            return user.AsServiceResultWithID().SetValid();
        }

        public ServiceResult Get(int id)
        {
            var user = Repository.Get<UserWithProfileFetchStrategy>().FirstOrDefault(x => x.ID == id);

            if (user == null)
                new ServiceResult().SetInvalid().WithMessage(ValidationResources.User_NotFound);

            return user.AsServiceResultWithEntity().SetValid();
        }

        public ServiceResult Delete(int id)
        {
            var user = Repository.GetById(id);

            Repository.DeleteLogically(user);

            return new ServiceResult().SetValid();
        }

        public ServiceResult GetUserByUsernameAndPassword(string username, string password)
        {
            var user = Repository.Get<UserWithProfileFetchStrategy>()
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
                return user.AsServiceResultWithEntity().SetValid();
            else
                return new ServiceResult().SetInvalid();
        }
    }
}
