using AutoMapper;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Domain.Responses.EmotionalState;

namespace EmotionalSeesaw_Presentation.Common.Mappers;

public class EmotionalStateMapper : Profile
{
    public EmotionalStateMapper()
    {
        CreateMap<EmotionalStateEntity, EmotionalStateResponse>();

    }
}
