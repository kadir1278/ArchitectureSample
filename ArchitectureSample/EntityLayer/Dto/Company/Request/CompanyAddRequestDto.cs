using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.Company.Request
{
    public record CompanyAddRequestDto:IDto
    {
        public string Name { get; set; }

        public CompanyAddRequestDto(string name)
        {
            Name = name;
        }
    }
}
