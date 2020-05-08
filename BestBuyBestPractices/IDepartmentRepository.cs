using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    interface IDepartmentRepository
    {
        IEnumerable<Departments> GetAllDepartments(); //Stubbed out method
    }
}
