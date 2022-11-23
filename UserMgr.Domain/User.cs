using Catel;
using UserMgr.Domain.ValueObject;

namespace UserMgr.Domain
{
    public record User:IAggregateRoot
    {
        public Guid Id { get; set; }

        //手机号
        public PhoneNumber PhoneNumber { get; private set; }

        private string? passwordHash;

        public UserAccessFail UserAccessFail { get; private set; }

        private User()
        {

        }

        public User(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Id = Guid.NewGuid();
            this.UserAccessFail = new UserAccessFail(this);
        }

        public bool HasPassword()
        {
            return !string.IsNullOrEmpty(passwordHash);
        }
        public string ChangePassword(string password)
        {
            if(password.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("密码长度必须大于3");
            }
            this.passwordHash = HashHelper
        }

    }
}