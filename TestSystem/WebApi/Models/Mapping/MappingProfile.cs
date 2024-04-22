using AutoMapper;
namespace TestSystem.WebApi.Models.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            this.CreateMap<TokenModel, TokenModel>();
        }
    }
}
