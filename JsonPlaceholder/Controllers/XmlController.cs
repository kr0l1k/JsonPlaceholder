using JsonPlaceholder.Managers;
using JsonPlaceholder.Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JsonPlaceholder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        private readonly IRequester _requester;
        public XmlController(IRequester requester)
        {
            _requester = requester;
        }
        // GET: api/Placeholder
        [HttpGet("GetAlbum/{id}")]
        public async Task<ActionResult<string>> GetAlbum(int id)
        {
            var album = _requester.GetAlbum(id);
            var res = SerializeObject(album);
            return res;
        }

        [HttpGet("GetAlbum")]
        public async Task<ActionResult<string>> GetAlbums()
        {
            var albums = _requester.GetAlbums();
            var res = SerializeObject(albums);
            return res;
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<string>> GetUser()
        {
            var users = _requester.GetUser();
            if (users.Count != 0)
            {
                var preparedUsers = Crypt.DecryptUsers(ref users);
                var res = SerializeObject(preparedUsers);
                return res;
            }
            else
            {
                return string.Empty;
            }

        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<string>> GetUser(int id)
        {
            var user = _requester.GetUser(id);
            if(user != null)
            {
                user.Email = Crypt.EncryptString(user.Email, user.Name + user.Phone.GetHashCode());
                var res = SerializeObject(user);
                return res;
            }
            else
            {
                return string.Empty;
            }
            
        }

        [HttpGet("GetUserAlbums/{id}")]
        public async Task<ActionResult<string>> GetUserAlbums(int id)
        {
            var albums = _requester.GetUserAlbums(id);
            var res = SerializeObject(albums);
            return res;
        }

        private string SerializeObject<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
