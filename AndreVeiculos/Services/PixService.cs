using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PixService
    {
        private GenericRepository _genericRepository { get; set; }

        public PixService()
        {
            _genericRepository = new GenericRepository();
        }

        
    }
}
