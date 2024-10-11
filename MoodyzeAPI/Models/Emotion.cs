using System.Runtime.InteropServices.JavaScript;

namespace MoodyzeAPI.Models;

public class Emotion
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string EmotionName { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}