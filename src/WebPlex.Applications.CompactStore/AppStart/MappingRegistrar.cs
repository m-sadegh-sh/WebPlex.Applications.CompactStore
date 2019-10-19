using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (MappingCreator), "CreateMaps")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using AutoMapper;
    using WebPlex.Applications.CompactStore.Models;

    public static class MappingCreator {
        public static void CreateMaps() {
            CreateAccountMaps();
        }

        private static void CreateAccountMaps() {
            Mapper.CreateMap<RegisterModel, CustomerModel>()
                  .ForMember(c => c.SecuredSalt, mce => mce.Ignore())
                  .ForMember(c => c.SecuredPassword, mce => mce.Ignore());
        }
    }
}
