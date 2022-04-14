﻿using EduHome.Models;
using EduHome.Models.APrimary;
using EduHome.Models.BlogRel;
using EduHome.Models.CourseRel;
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

        //Events related tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }

        //Courses related tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssestment> CourseAssestments { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<CourseFeatures> CourseFeatures { get; set; }
        public DbSet<CourseImages> CourseImages { get; set; }
        public DbSet<CourseLanguage> CourseLanguages { get; set; }

        //Blogs related tables
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }

        //Settings table
        public DbSet<Setting> Settings { get; set; }

        ////DbView Tables
        //public DbSet<GetBlogsId> GetBlogsIds { get; set; }
        //public DbSet<GetCoursesId> GetCoursesIds { get; set; }
        //public DbSet<GetEventsId> GetEventsIds { get; set; }
        //public DbSet<GetTeachersId> GetTeachersIds { get; set; }



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

            //Configure Data Type To Property
            modelBuilder.Entity<CourseFeatures>()
                    .Property(cf => cf.Fee)
                    .HasColumnType("decimal(18,4)");

            ////map viewentity to dbview
            //modelbuilder.entity<getblogsid>()
            //    .toview(nameof(getblogsids))
            //    .haskey(bi => bi.id);
            //modelbuilder.entity<getcoursesid>()
            //    .toview(nameof(getcoursesids))
            //    .haskey(bi => bi.id);
            //modelbuilder.entity<geteventsid>()
            //    .toview(nameof(geteventsids))
            //    .haskey(bi => bi.id);
            //modelbuilder.entity<getteachersid>()
            //    .toview(nameof(getteachersids))
            //    .haskey(bi => bi.id);
        }
    }
}
