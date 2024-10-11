namespace MoodyzeAPI.Dtos.Emotion;

public class EmotionDto
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string EmotionName { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }    
}