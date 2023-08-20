using Microsoft.EntityFrameworkCore;
using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class Ctx : DbContext
{
    private readonly IConfiguration _cfg;
    public Ctx(IConfiguration cfg)
    {
        _cfg = cfg;
    }
    
    public virtual DbSet<User>? Users { get; set; }
    public virtual DbSet<Comment>? Comments { get; set; }
    public virtual DbSet<Post>? Posts { get; set; }
    public virtual DbSet<Follow>? Follows { get; set; }
    public virtual DbSet<Like>? Likes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //to choose db
            optionsBuilder
                .UseNpgsql(_cfg.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Comment>().HasKey(c => c.CommentId);
        modelBuilder.Entity<Post>().HasKey(p => p.PostId);
        modelBuilder.Entity<Like>().HasKey(l => l.LikeId);
        modelBuilder.Entity<Follow>().HasKey(f => f.Id);
    }
    
}