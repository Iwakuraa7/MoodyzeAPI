using MoodyzeAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodyzeAPI.Dtos.Emotion;
using MoodyzeAPI.Interfaces;
using MoodyzeAPI.Mappers;
using MoodyzeAPI.Models;
using System.Security.Claims;

namespace MoodyzeAPI.Controllers
{
    [Route("api/emotions")]
    [ApiController]
    public class EmotionController : ControllerBase
    {
        private readonly IEmotionRepository _emotionRepo;
        private readonly UserManager<AppUser> _userManager;

        public EmotionController(IEmotionRepository emotionRepo, UserManager<AppUser> userManager)
        {
             _emotionRepo = emotionRepo;
              _userManager = userManager;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetEmotions()
        {
            var emotions = await _emotionRepo.GetEmotions();
            
             return Ok(emotions.Select(e => e.FromEmotionToDto()));
        }
    
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> CreateEmotion([FromBody] CreateEmotionDto emotionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appUser = await _userManager.FindByIdAsync(userId);

            var emotionModel = emotionDto.FromCreateToEmotionModel();
            emotionModel.AppUserId = appUser.Id;
            await _emotionRepo.Create(emotionModel);

            return Ok(emotionModel.FromEmotionToDto());
        }

        [Authorize]
        [HttpGet("getAccountCalendar")]
        public async Task<IActionResult> GetUserEmotions()
        {
            var appUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(appUserId == null)
                return NotFound("User does not exist!");

            var appUser = await _userManager.FindByIdAsync(appUserId);

            var emotions = await _emotionRepo.GetUserEmotions(appUser);

            return Ok(emotions.Select(e => e.FromEmotionToDto()));
        }
    }
}