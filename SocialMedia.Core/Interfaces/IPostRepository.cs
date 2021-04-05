using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces {
  public interface IPostRepository {
    Task<IEnumerable<Post>> GetPosts();
    Task<Post> GetPostById(int Id);
  }
}
