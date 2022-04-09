using EduHome.Models;
using EduHome.Models.EventRel;
using EduHome.Models.TeacherRel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region DbSetClasses

        //Teachers related tables
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetails> TeachersDetails { get; set; }
        public DbSet<TeacherContactInfo> TeacherContactInfos { get; set; }
        public DbSet<TeacherSocialMedia> TeacherSocialMedias { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Skill> Skills { get; set; }

        //Courses related tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Teachers => Skills : Many to many
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

            //Courses => Speakers : Many to many
            modelBuilder.Entity<EventSpeaker>()
                .HasKey(cs => new { cs.EventId, cs.SpeakerId });
            modelBuilder.Entity<EventSpeaker>()
                .HasOne(cs => cs.Event)
                .WithMany(cs => cs.EventSpeakers)
                .HasForeignKey(cs => cs.EventId);
            modelBuilder.Entity<EventSpeaker>()
                .HasOne(cs => cs.Speaker)
                .WithMany(cs => cs.EventSpeakers)
                .HasForeignKey(cs => cs.SpeakerId);
        }
    }
}
