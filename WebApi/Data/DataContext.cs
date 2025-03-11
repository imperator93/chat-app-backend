using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data;

public class DataContext : DbContext

{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<ChatGroup> ChatGroups { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Messages).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Message>().HasOne(m => m.ChatGroup).WithMany(m => m.Messages).HasForeignKey(m => m.ChatGroupId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<User>().HasMany(u => u.ChatGroups).WithMany(u => u.Users).UsingEntity<UserChatGroup>();
    }

}