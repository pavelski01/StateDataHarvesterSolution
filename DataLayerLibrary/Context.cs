using DtoLibrary.Gus;
using DtoLibrary.Mf;
using System.Data.Entity;

namespace DataLayerLibrary
{
    public class Context : DbContext
    {
        public DbSet<GusDataDto> GusDomain { get; set; }
        public DbSet<MfSubjectDto> MfDomain { get; set; }
    }
}
