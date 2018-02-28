using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class Album : BaseModel
    {
        public int YearReleased { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        // in theory i could write some proper way to add songs to a album
    }
}
