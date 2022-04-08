using EduHome.Models;
using EduHome.Models.TeacherRel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region DbSetClasses
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetails> TeachersDetails { get; set; }
        public DbSet<TeacherContactInfo> TeacherContactInfos { get; set; }
        public DbSet<TeacherSocialMedia> TeacherSocialMedias { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Skill> Skills { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeacherSkill>()
                .HasKey(tc => new { tc.TeacherId, tc.SkillId});
            modelBuilder.Entity<TeacherSkill>()
                .HasOne(tc => tc.Teacher)
                .WithMany(tc => tc.TeacherSkills)
                .HasForeignKey(tc => tc.TeacherId);
            modelBuilder.Entity<TeacherSkill>()
                .HasOne(tc => tc.Skill)
                .WithMany(tc => tc.TeacherSkills)
                .HasForeignKey(tc => tc.SkillId);
        }
    }
}
