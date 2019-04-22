using JsonPlaceholder.Managers;
using JsonPlaceholder.Managers.Contracts;
using JsonPlaceholder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonPlaceholder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly IRequester _requester;
        public JsonController(IRequester requester)
        {
            _requester = requester;
        }
        // GET: api/Placeholder
        [HttpGet("GetAlbum/{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {

            return _requester.GetAlbum(id);
        }

        // GET: api/Placeholder
        [HttpGet("GetAlbum")]
        public async Task<ActionResult<List<Album>>> GetAlbums()
        { 
            return _requester.GetAlbums();
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            var users = _requester.GetUser();
            var preparedUsers = Crypt.DecryptUsers(ref users);
            return preparedUsers;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {   
            var user = _requester.GetUser(id);
            if (user != null)
            {
                user.Email = Crypt.EncryptString(user.Email, user.Name + user.Phone.GetHashCode());
                return user;
            }
            else
            {
                return new User();
            }
        }

        [HttpGet("GetUserAlbums/{id}")]
        public async Task<ActionResult<List<Album>>> GetUserAlbums(int id)
        {
            return _requester.GetUserAlbums(id);
        }

        

    }
}
