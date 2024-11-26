using AspNetCoreWebApiDapper.Models;

namespace AspNetCoreWebApiDapper.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetEmpList();

        Task<List<EmployeeModel>> GetEmpbyId(string Name);

        Task<EmployeeModel> AddEmp(EmployeeModel employeeModel);

        Task<EmployeeModel> UpdateEmp(int Id, EmployeeModel employeeModel);

        Task<string> Delete(int Id);
    }
}
