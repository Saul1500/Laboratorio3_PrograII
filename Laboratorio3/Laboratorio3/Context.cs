﻿using Laboratorio3;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContextDB : DbContext
{
    public DbSet<equipos> equipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ\\SQLEXPRESS;Database=lab3;Trusted_Connection=True;");

    }
}

