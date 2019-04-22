using JsonPlaceholder.Models;
using System.Collections.Generic;

namespace JsonPlaceholder.Managers.Contracts
{
    public interface IRequester
    {
        List<User> GetUser();
        User GetUser(int userId);
        List<Album> GetAlbums();
        List<Album> GetUserAlbums(int userId);
        Album GetAlbum(int id);
    }
}
