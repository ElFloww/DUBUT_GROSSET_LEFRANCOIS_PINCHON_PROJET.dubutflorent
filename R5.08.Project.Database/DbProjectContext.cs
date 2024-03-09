using Microsoft.EntityFrameworkCore;

namespace R5._08.Project.Database
{
    public class DbProjectContext : R508projetContext
    {
        public DbProjectContext(DbContextOptions<DbProjectContext> p_Options) : base(p_Options)
        {

        }
    }
}
