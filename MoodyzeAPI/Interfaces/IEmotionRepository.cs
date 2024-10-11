using MoodyzeAPI.Models;

namespace MoodyzeAPI.Interfaces;

public interface IEmotionRepository
{
    Task<List<Emotion>> GetEmotions();
    Task<Emotion?> Create(Emotion emotion);
    Task<List<Emotion>> GetUserEmotions(AppUser appUser);
}