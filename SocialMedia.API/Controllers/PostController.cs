using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Filters;

namespace SocialMedia.API.Controllers {
  // Implementacion del filtro en el scope del controlador
  // [ServiceFilter(typeof(ControllerFilterExample))]
  [Route("api/[controller]")]
  [ApiController]

  public class PostController : ControllerBase {

    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostController(IPostRepository postRepository, IMapper mapper) {
      _postRepository = postRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts() {
      var posts = await _postRepository.GetPosts();
      var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
      return Ok(postsDto);
    }

    [HttpGet("{id}")]
    // Implementacion del filtro en el scope de la acción
    // [ServiceFilter(typeof(ValidationFilter))]
    public async Task<IActionResult> GetPostById(int Id) {
      var post = await _postRepository.GetPostById(Id);
      var postDto = _mapper.Map<PostDto>(post); ;
      return Ok(postDto);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PostDto postDto) {
      var post = _mapper.Map<Post>(postDto);
      await _postRepository.InserPost(post);
      return Ok(post);
    }
  }
}