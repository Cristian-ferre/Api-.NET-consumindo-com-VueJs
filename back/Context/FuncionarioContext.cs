using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionarioApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioApi.Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {}

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}