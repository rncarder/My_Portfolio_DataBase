using AHS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHS.Core.DTOs
{
    internal class EpisodeReadDto : BaseReadDto, ISearchable, IName
    {
        public string Name { get; set; }
        public string seasonName { get; set; }
        [Browsable(false)]
        public string SearchString => $"{Name} {seasonName}";
    }
}
