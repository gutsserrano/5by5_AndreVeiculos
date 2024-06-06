using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class OperationController
    {
        private OperationService _operationService { get; set; }

        public OperationController()
        {
            _operationService = new OperationService();
        }

        public bool Insert(List<Operation> operations)
        {
            return _operationService.Insert(operations);
        }

        public List<Operation> GetAll()
        {
            return _operationService.GetAll();
        }
    }
}
