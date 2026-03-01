using AHS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHS.Core.DTOs
{
    internal class CharacterReadDto : BaseReadDto, ISearchable, IName
    {
        public string Name {  get; set; }
        public string CastMember { get; set; }
        public string Season1Name { get; set; }
        public int numOfEps1 {  get; set; }
        public string Season2Name { get; set; }
        public int numOfEps2 { get; set; }
        [Browsable(false)]
        public string SearchString => $"{Name} {CastMember} {Season1Name} {Season2Name}";
    }
}
