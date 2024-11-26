using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApiDapper.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation {  get; set; }

        public string Contact {  get; set; }

        public string State { get; set; }

        public string Country { get; set; }

    }
}
