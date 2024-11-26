using AspNetCoreWebApiDapper.Data;
using AspNetCoreWebApiDapper.Interface;
using AspNetCoreWebApiDapper.Models;
using Dapper;

namespace AspNetCoreWebApiDapper.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperDbContext _dapperDbContext;

        public EmployeeRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }
            
        public async Task<List<EmployeeModel>> GetEmpList()
        {
            string query = "Select * from Employees where isDeleted = 0";

            using(var connection = _dapperDbContext.CreateConnection())
            {
                var emplist = await connection.QueryAsync<EmployeeModel>(query);
                
                return emplist.ToList();
            }

        }

        public async Task<List<EmployeeModel>> GetEmpbyId(string Name)
        {
           
            string query = "Select * from Employees where name = @Name";

            using(var connection = _dapperDbContext.CreateConnection())
            {
                var empid = await connection.QueryAsync<EmployeeModel>(query, new { Name });

                return empid.ToList();
            }
        }

        public async Task<EmployeeModel> AddEmp(EmployeeModel employeeModel)
        {
            string response = string.Empty;

            string query = "insert into Employees(name,designation,contact,state,country) values (@name,@designation,@contact,@state,@country)";

            var parameter = new DynamicParameters();

            parameter.Add("name",employeeModel.Name);
            parameter.Add("designation", employeeModel.Designation);
            parameter.Add("contact", employeeModel.Contact);
            parameter.Add("state", employeeModel.State);
            parameter.Add("country", employeeModel.Country);


            using (var connection = _dapperDbContext.CreateConnection())
            {
                await connection.QueryAsync<EmployeeModel>(query, parameter);

                response = "pass";
            }

            return employeeModel;
        }


        public async Task<EmployeeModel> UpdateEmp(int Id, EmployeeModel employeeModel)
        {
            string res = "update Employees set name=@name, designation=@designation, contact=@contact, state=@state, country=@country where Id = @Id";

            var parameter = new DynamicParameters();

            parameter.Add("Id", employeeModel.Id);
            parameter.Add("name", employeeModel.Name);
            parameter.Add("designation", employeeModel.Designation);
            parameter.Add("contact", employeeModel.Contact);
            parameter.Add("state", employeeModel.State);
            parameter.Add("country", employeeModel.Country);


            using (var connection = _dapperDbContext.CreateConnection())
            {
                await connection.QueryAsync<EmployeeModel>(res,parameter);
            }

            return employeeModel;
        }


        //public async Task<string> Delete(int Id)
        //{
        //    string response = string.Empty;

        //    var res = "Delete from Employees where Id = @Id";

        //    using(var connection = _dapperDbContext.CreateConnection())
        //    {
        //        await connection.QueryAsync(res, new {Id});
        //        response = "Pass";
        //    }
        //    return response;
        //}

        public async Task<string> Delete(int Id)
        {
            string response = string.Empty;

            var res = "update Employees set isDeleted = 1 where Id = @Id";

            using (var connection = _dapperDbContext.CreateConnection())
            {
                await connection.QueryAsync(res, new { Id });
                response = "Pass";
            }
            return response;
        }

    }
}
