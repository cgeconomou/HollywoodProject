using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        void DeleteAll();

        void DeleteBy(Expression<Func<Student,bool>> expression);    //x=>x.score>65

    }
}
