using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.Company.Response
{
    public record CompanyGetByIdResponseDto : IDto
    {
        public string Name { get; set; }

        public CompanyGetByIdResponseDto(string name)
        {
            Name = name;
        }
    }
}
