using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService
    {
        private GenericRepository _genericRepository { get; set; }

        public EmployeeService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Employee employee)
        {


            try
            {
                Object address = new { PostalCode = employee.Address.PostalCode, State = employee.Address.State, City = employee.Address.City, PublicPlace = employee.Address.PublicPlace, PublicPlaceType = employee.Address.PublicPlaceType, Number = employee.Address.Number, Neighborhood = employee.Address.Neighborhood, Complement = employee.Address.Complement };

                if (!_genericRepository.Insert(Address.INSERT, address))
                {
                    return false;
                }

                Object obj = new
                {
                    Document = employee.Document,
                    Name = employee.Name,
                    BirthDate = employee.BirthDate,
                    AddressId = _genericRepository.GetAll<Address>(Address.GETALL).Last().Id,
                    Phone = employee.Phone,
                    Email = employee.Email
                };

                Object position = new { Description = employee.Position.Description };

                if(!_genericRepository.Insert(Position.INSERT, position))
                {
                    return false;
                }

                var positionId = _genericRepository.GetAll<Position>(Position.GETALL).Last().Id;

                Object employeeObj = new
                {
                    Document = employee.Document,
                    PositionId = _genericRepository.GetAll<Position>(Position.GETALL).Last().Id,
                    ComissionValue = employee.ComissionValue,
                    Commission = employee.Commission
                };

            if (_genericRepository.Insert(Person.INSERT, obj))
                {
                    return _genericRepository.Insert(Employee.INSERTEMPLOYEE, employeeObj);
                }
        }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            var employeeResult = _genericRepository.GetAll<dynamic>(Employee.GETALL);

            foreach (var item in employeeResult)
            {

                item.Address = new Address
                {
                    Id = item.Id,
                    PostalCode = item.PostalCode,
                    State = item.State,
                    City = item.City,
                    PublicPlace = item.PublicPlace,
                    PublicPlaceType = item.PublicPlaceType,
                    Number = item.Number,
                    Neighborhood = item.Neighborhood,
                    Complement = item.Complement
                };

                Employee employee = new()
                {
                    Document = item.Document,
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    Position = item.Position.Id,
                    ComissionValue = item.ComissionValue,
                    Commission = item.Commission
                };

                employees.Add(employee);
            }

            return employees;
        }

        public Employee? Get(string id)
        {
            return GetAll().Find(e => e.Document == id);
        }
    }
}
