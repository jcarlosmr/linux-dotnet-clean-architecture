using System.Collections.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;
using SocialMedia.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infraestructure.Repositories {
  public class PostRepository : IPostRepository {

    public readonly SocialMediaContext _context;
    public PostRepository(SocialMediaContext context) {
      _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts() {
      var posts = await _context.Posts.ToListAsync();
      return posts;
    }
    public async Task<Post> GetPostById(int Id) {
      var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == Id);
      return post;
    }
  }
}
