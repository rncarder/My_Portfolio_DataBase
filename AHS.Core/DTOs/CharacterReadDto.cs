using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHS.Core.DTOs
{
    internal class CharacterReadDto : BaseReadDto
    {
        public string CastMember { get; set; }
        public string Season1Name { get; set; }
        public int numOfEps1 {  get; set; }
        public string Season2Name { get; set; }
        public int numOfEps2 { get; set; }
    }
}
