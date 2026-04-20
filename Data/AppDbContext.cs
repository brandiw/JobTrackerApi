using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;

namespace JobTrackerApi.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<JobApplication> Applications => Set<JobApplication>();
    public DbSet<InterviewNote> InterviewNotes => Set<InterviewNote>();
}