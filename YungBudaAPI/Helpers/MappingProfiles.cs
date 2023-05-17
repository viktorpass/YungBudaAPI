using AutoMapper;
using YungBudaAPI.Dto;
using YungBudaAPI.Models;

namespace YungBudaAPI.Helpers {
    public class MappingProfiles : Profile {

        public MappingProfiles() {
            CreateMap<Phrases, PhraseDto>().ReverseMap();
        }


    }
}
