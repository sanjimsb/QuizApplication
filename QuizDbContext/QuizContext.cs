namespace QuizDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuizModels;

public class QuizContext : IdentityDbContext
{
    public QuizContext(DbContextOptions<QuizContext> options)
        : base(options)
    { }

    public DbSet<Module>? Module { get; set; }
    public DbSet<Quiz>? Quiz { get; set; }
    public DbSet<User>? User { get; set; }
    public DbSet<UserAnswer>? UserAnswer { get; set; }
    public DbSet<UserStatus>? UserStatus { get; set; }
    public DbSet<ModuleDetails>? ModuleDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}