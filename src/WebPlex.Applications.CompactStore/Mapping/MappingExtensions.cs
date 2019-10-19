namespace WebPlex.Applications.CompactStore.Mapping {
    using AutoMapper;
    using WebPlex.Applications.CompactStore.Models;

    public static class MappingExtensions {
        public static CustomerModel ToCustomer(this RegisterModel register) {
            return Mapper.Map<RegisterModel, CustomerModel>(register);
        }
    }
}
