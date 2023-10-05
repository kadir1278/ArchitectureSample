using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.User;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfUserDal : EfEntityRepository<User, UserAddDto,UserUpdateDto, UserGetDto, SystemContext>, IUserDal
    {
        public EfUserDal(SystemContext context) : base(context)
        {

        }
    }
}
