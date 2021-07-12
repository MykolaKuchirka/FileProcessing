using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System.Linq;

namespace FileProcessingDB.Services
{
	public class UserServices: IUserServices
	{
		private readonly FileProcessingDBContext _database;

		public UserServices() =>
			_database = new FileProcessingDBContext();
		public int AddUser(User newUser)
		{
			_database.Users.Add(newUser);
			_database.SaveChanges();
			return newUser.Id;
		}
		public bool CheckUser(AuthorizationDTO authorization)
		{
			return _database.Users.Any(f => (f.Email == authorization.Email) && (f.Password == authorization.Password));
		}
		public User GetUser(AuthorizationDTO authorization)
		{
			return _database.Users.FirstOrDefault(f => (f.Email == authorization.Email) && (f.Password == authorization.Password));
		}
	}
}
