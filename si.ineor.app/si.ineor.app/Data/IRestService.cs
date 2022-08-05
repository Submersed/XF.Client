using si.ineor.app.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace si.ineor.app.Data
{
	public interface IRestService
	{

		Task<AuthenticateResponse> Login(AuthenticateRequest request);
	}
}
