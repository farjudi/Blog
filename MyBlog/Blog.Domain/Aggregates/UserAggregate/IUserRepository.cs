

namespace Blog.Domain.Aggregates.UserAggregate
{
    public interface IUserRepository
    {


        #region Query Method

        Task<User?> GetByIdAsync(UserId id);

        Task<User?> GetByEmailAsync(Email email);

        Task<bool> EmailExistAsync(Email email);
        /// <summary>
        /// گرفتن تمام کاربران فعال
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllActiveUsersAsync();
        /// <summary>
        /// گرفتن تمام ادمین ها 
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllAdminsAsync();
        #endregion



        #region command Methods

        Task<User> AddAsync(User user);

        Task  UpdateAsync(User user);
        Task DeleteAsync(User user);

        #endregion
    }
}
