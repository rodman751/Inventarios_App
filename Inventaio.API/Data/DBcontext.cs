using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entidades;

    public class DBcontext : DbContext
    {
        public DBcontext (DbContextOptions<DBcontext> options)
            : base(options)
        {
        }

        public DbSet<Entidades.Ajustes> Ajuste { get; set; } = default!;

public DbSet<Entidades.Auditoria> Auditoria { get; set; } = default!;


public DbSet<Entidades.Productos> Productos { get; set; } = default!;

public DbSet<Entidades.Roles> Roles { get; set; } = default!;

public DbSet<Entidades.Usuarios> Usuarios { get; set; } = default!;
    }
