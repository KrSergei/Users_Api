using AutoMapper;
using Users_Api.Db;
using Users_Api.Dto;

namespace Users_Api.Repo
{
    public class UserRepository : IUserRepository
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public UserRepository(IMapper mapper, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _context = appDbContext;
        }
        public void AddUser(UserDto userDto)
        {
            using (_context)
            {
                User userDb = _mapper.Map<User>(userDto);
                _context.Users.Add(_mapper.Map<User>(userDb));
                _context.SaveChanges();
            }
        }

        public bool ExistsUser(string email)
        {
            using (_context)
            {
               return _context.Users.Any(x => x.Active && x.Email == email);
            }
        }

        public bool ExistsUser(Guid? id)
        {
            using (_context)
            {
                return _context.Users.Any(x => x.Active && x.Id == id);
            }
        }
    }
}
