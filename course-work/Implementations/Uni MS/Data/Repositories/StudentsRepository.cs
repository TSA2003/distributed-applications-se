using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentsRepository : BaseRepository<Student, Guid>
    {
        public StudentsRepository(AppDbContext context) : base(context)
        {            
        }
    }
}
