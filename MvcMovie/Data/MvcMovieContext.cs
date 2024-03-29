﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MvcMovie.Models.Tea> Tea { get; set; } = default!;

        public DbSet<MvcMovie.Models.Book> Book { get; set; } = default!;

        public DbSet<MvcMovie.Models.Dream> Dream { get; set; } = default!;
    }
}
