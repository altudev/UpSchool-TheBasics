using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Services
{
    public class UserManager:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _userRepository.GetAllAsync(cancellationToken);
        }

        public Task<User> GetByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            return _userRepository.GetByIdAsync(id,cancellationToken);
        }

        public async Task<Guid> AddAsync(string firstName, string lastName, int age, string email,CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Email = email
            };

            await _userRepository.AddAsync(user, cancellationToken);

            return user.Id;
        }

        public async Task<bool> DeleteAsync(Guid id,CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("id cannot be empty.");
            }

            var result = await _userRepository.DeleteAsync(x=>x.Id == id,cancellationToken);

           return result > 0;

        }

        public async Task<bool> UpdateAsync(User user,CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            if (user.Id == Guid.Empty)
            {
                throw new ArgumentException("User Id cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            var result = await _userRepository.UpdateAsync(user, cancellationToken);

            return result > 0;
        }
    }
}
