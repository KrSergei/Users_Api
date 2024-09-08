using Users_Api.Dto;

namespace Users_Api.Repo
{
    public interface IUserRepository
    {
        public void AddUser(UserDto userDto);
        public bool ExistsUser(string email);
        public bool ExistsUser(Guid? id);
    }
}
