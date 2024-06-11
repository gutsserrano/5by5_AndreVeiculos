using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OperationService
    {
        private GenericRepository _genericRepository { get; set; }

        public OperationService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(List<Operation> operations)
        {
            return _genericRepository.Insert(Operation.INSERT, operations);
        }

        public List<Operation> GetAll()
        {
            return _genericRepository.GetAll<Operation>(Operation.GETALL);
        }

        public Operation? Get(int id)
        {
            return GetAll().Find(o => o.Id == id);
        }
    }
}
