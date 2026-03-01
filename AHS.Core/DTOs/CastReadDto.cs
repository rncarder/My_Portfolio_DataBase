using AHS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AHS.Core.DTOs
{
    internal class CastReadDto : BaseReadDto, ISearchable, IName
    {
        public string Name { get; set; }
        [Browsable(false)]
        public string SearchString => $"{Name}";
    }
}
