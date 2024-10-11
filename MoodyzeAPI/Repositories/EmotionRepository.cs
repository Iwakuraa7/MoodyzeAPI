using Microsoft.EntityFrameworkCore;
using MoodyzeAPI.Data;
using MoodyzeAPI.Interfaces;
using MoodyzeAPI.Models;
using MoodyzeAPI.Mappers;

namespace MoodyzeAPI.Repositories;

public class EmotionRepository : IEmotionRepository
{
    private readonly ApplicationDbContext _context;

    public EmotionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Emotion>> GetEmotions()
    {
        var emotions = await _context.Emotions.ToListAsync();

        return emotions;
    }

    public async Task<Emotion?> Create(Emotion emotion)
    {
        await _context.AddAsync(emotion);
        await _context.SaveChangesAsync();

        return emotion;
    }

    public async Task<List<Emotion>> GetUserEmotions(AppUser appUser)
    {
        var userEmotions = await _context.Emotions.Where(e => e.AppUserId == appUser.Id).ToListAsync();

        return userEmotions;
    }
}