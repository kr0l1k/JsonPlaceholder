using JsonPlaceholder.Models;
using System.Collections.Generic;

namespace JsonPlaceholder.Managers.Contracts
{
    /// <summary>
    /// Data getter from JsonPlaceHolder
    /// </summary>
    public interface IRequester
    {
        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        List<User> GetUser();
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUser(int userId);
        /// <summary>
        /// Get all albums
        /// </summary>
        /// <returns></returns>
        List<Album> GetAlbums();
        /// <summary>
        /// Get album by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Album GetAlbum(int id);
        /// <summary>
        /// Get all albums of User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Album> GetUserAlbums(int userId);
        
    }
}
