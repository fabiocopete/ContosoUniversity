﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private SchoolContext schoolContext;
        public EnrollmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;

        }
        public new async Task<List<Enrollment>> GetAll()
        {
            var listEnrollments = await schoolContext.Enrollments.Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();


            return await schoolContext.Enrollments.ToListAsync();
        }
    }
}
