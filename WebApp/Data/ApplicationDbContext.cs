﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApp.Models.ClientViewModel> ClientViewModel { get; set; }
        public DbSet<WebApp.Models.PetViewModel> PetViewModel { get; set; }
        public DbSet<WebApp.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
        public DbSet<WebApp.Models.StoreViewModel> StoreViewModel { get; set; }
    }
}
