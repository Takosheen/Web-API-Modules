using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface  ICourseRepository
    {
      /*IEnumerable<Organization> GetAllOrganizations(bool trackChanges);
        Organization GetOrganization(Guid companyId, bool trackChanges);*/

        IEnumerable<Course> GetAllCourses(bool trackChanges);
        Course GetCourse(Guid courseId, bool trackChanges);
    }
}
