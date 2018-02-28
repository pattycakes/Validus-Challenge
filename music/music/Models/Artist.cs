using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class Artist : BaseModel
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
