using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CoursesRepository : BaseRepository<Course, Guid>
    {
        public CoursesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
