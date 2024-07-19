using System;
using dotnet_study.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_study.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<SuperHero> SuperHeroes { get; set; }
	}
}

