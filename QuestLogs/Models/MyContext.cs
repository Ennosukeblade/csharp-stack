#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace QuestLogs.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    // ! Don't forget to add all tables
    public DbSet<User> Users { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<UserQuest> UserQuests { get; set; }
}