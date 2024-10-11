using MoodyzeAPI.Dtos.Emotion;
using MoodyzeAPI.Models;

namespace MoodyzeAPI.Mappers;

public static class EmotionMappers
{
    public static EmotionDto FromEmotionToDto(this Emotion emotion)
    {
        return new EmotionDto()
        {
            Id = emotion.Id,
            Color = emotion.Color,
            Description = emotion.Description,
            EmotionName = emotion.EmotionName,
            Timestamp = emotion.Timestamp
        };
    }

    public static Emotion FromCreateToEmotionModel(this CreateEmotionDto emotionDto)
    {
        return new Emotion()
        {
            Color = emotionDto.Color,
            Description = emotionDto.Description,
            EmotionName = emotionDto.EmotionName,
        };
    }
}