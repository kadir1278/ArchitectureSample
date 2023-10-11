﻿using EntityLayer.Base;

namespace EntityLayer.Dto.ProjectOwner
{
    public class ProjectOwnerGetDto : BaseDto
    {
        public string ProjectName { get; set; }
        public string Owner { get; set; }
        public string Domain { get; set; }
        public DateTime StartDate { get; set; }
    }
}