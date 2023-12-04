using CoreLayer.DataAccess.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Absctract
{
    public interface IUserRoleDal : IEntityRepository<UserRole>
    {
    }
}
