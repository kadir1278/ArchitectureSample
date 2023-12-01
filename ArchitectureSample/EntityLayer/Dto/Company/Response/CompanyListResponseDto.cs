﻿using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.Company.Response
{
    public record CompanyListResponseDto : IDto
    {
        public string Name { get; set; }

        public CompanyListResponseDto(string name)
        {
            Name = name;
        }
    }
}