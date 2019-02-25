using System;

namespace NTier.BLL
{
    public class Security : BLL
    {
        private readonly IUserRepository _userRepository;

        public Security(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public Security() : this(new SqlUserRepository())
        //{}

        public int Login(String email, String password)
        {
            return _userRepository.GetByEmailPassword(email, password);
        }
    }
}