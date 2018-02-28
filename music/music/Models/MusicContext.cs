using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace music.Models
{
    public class MusicContext : DbContext
    {

        public MusicContext(DbContextOptions<MusicContext> options)
                : base(options)
        {
        }

        public DbSet<BaseModel> BaseObjects { get; set; } // not required I know.
        public DbSet<Song> SongObjects { get; set; }
        public DbSet<Album> AlbumObjects { get; set; }
        public DbSet<Artist> ArtistObjects { get; set; }
    }
}
