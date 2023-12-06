﻿using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfRoleDal : EfEntityRepository<Role, SystemContext>, IRoleDal
    {
        public EfRoleDal(SystemContext context) : base(context)
        {

        }
    }
}