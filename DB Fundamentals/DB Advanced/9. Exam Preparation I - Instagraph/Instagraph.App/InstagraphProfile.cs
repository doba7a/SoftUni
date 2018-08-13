using AutoMapper;
using Instagraph.DataProcessor.Dto.Import;
using Instagraph.Models;

namespace Instagraph.App
{
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<ImportUserDto, User>()
                .ForMember(
                    dest => dest.ProfilePicture,
                    opt => opt.Ignore());
        }
    }
}
