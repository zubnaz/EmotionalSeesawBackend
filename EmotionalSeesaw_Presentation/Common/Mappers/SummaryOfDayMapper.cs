using AutoMapper;
using EmotionalSeesaw_Domain.Entities;
using EmotionalSeesaw_Domain.Responses.EmotionalState;
using EmotionalSeesaw_Domain.Responses.Summary;

namespace EmotionalSeesaw_Presentation.Common.Mappers;

public class SummaryOfDayMapper : Profile
{
    public SummaryOfDayMapper()
    {
        CreateMap<SummaryOfDayEntity, SummaryOfDayResponse>()
            .ForMember(desp => desp.EmotionalStates, opt =>
            opt.MapFrom(src => src.EmotionalStates == null ? Array.Empty<EmotionalStateEntity>() : src.EmotionalStates.ToArray()));

        CreateMap<SummaryOfDayEntity, SummaryOfDayCollectionItemResponse>()
            .ForMember(desp => desp.Day, opt => opt.MapFrom(src => src.Date.Day));
    }
}
