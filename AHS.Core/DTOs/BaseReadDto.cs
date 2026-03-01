using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace AHS.Core.DTOs
{
    internal class BaseReadDto
    {
        [Browsable(false)]
        public int Id { get; set; }
    }
}
