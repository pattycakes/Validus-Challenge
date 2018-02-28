using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class Song : BaseModel
    {
        public int Track { get; set; }
        public string Name { get; set; }
    }
}
