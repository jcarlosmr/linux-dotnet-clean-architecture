using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.API.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : ControllerBase {

    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository) {
      _postRepository = postRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts() {
      var posts = await _postRepository.GetPosts();
      return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int Id) {
      var post = await _postRepository.GetPostById(Id);
      return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post) {
      await _postRepository.InserPost(post);
      return Ok(post);
    }
  }
}