using EduHome.Data;
using EduHome.Models;
using EduHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _context;
        public TeacherService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Teacher>> GetTeachers(int takeTeachers, int after)
        {
            try
            {
                if (takeTeachers == -1)
                {
                    List<Teacher> teachers = await _context.Teachers
                    .Where(t => t.Id < after && t.IsDeleted == false)
                    .Include(t => t.TeacherDetails)
                    .Include(t => t.TeacherContactInfo)
                    .Include(t => t.TeacherSocialMedia)
                    .Include(t => t.TeacherSkills)
                    .Include(t => t.Faculty)
                    .Include(t => t.Position)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    return teachers;
                }
                else
                {
                    List<Teacher> teachers = await _context.Teachers
                    .Where(t => t.Id < after && t.IsDeleted == false)
                    .Take(takeTeachers)
                    .Include(t => t.TeacherDetails)
                    .Include(t => t.TeacherContactInfo)
                    .Include(t => t.TeacherSocialMedia)
                    .Include(t => t.TeacherSkills)
                    .Include(t => t.Faculty)
                    .Include(t => t.Position)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();
                    return teachers;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
