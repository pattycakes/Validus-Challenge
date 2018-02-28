using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
