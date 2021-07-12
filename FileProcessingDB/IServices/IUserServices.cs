using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;

namespace FileProcessingDB.IServices
{
	public interface IUserServices
	{
		public int AddUser(User newUser);
		public bool CheckUser(AuthorizationDTO authorization);
		public User GetUser(AuthorizationDTO authorization);
	}
}
