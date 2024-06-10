using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientService
    {
        private GenericRepository _genericRepository { get; set; }

        public ClientService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Client client)
        {
                

            try
            {
                Object address = new { PostalCode = client.Address.PostalCode, State = client.Address.State, City = client.Address.City, PublicPlace = client.Address.PublicPlace, PublicPlaceType = client.Address.PublicPlaceType, Number = client.Address.Number, Neighborhood = client.Address.Neighborhood, Complement = client.Address.Complement };

                if(!_genericRepository.Insert(Address.INSERT, address))
                {
                    return false;
                }

                Object obj = new 
                { 
                    Document = client.Document, 
                    Name = client.Name, 
                    BirthDate = client.BirthDate, 
                    AddressId = _genericRepository.GetAll<Address>(Address.GETALL).Last().Id, 
                    Phone = client.Phone, Email = client.Email 
                };

                if(_genericRepository.Insert(Person.INSERT, obj))
                {
                    return _genericRepository.Insert(Client.INSERTCLIENT, new { Document = client.Document, Income = client.Income, DocumentPdf = client.DocumentPdf });
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            var clientResult = _genericRepository.GetAll<dynamic>(Client.GETALL);

            foreach (var item in clientResult)
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

                Client client = new()
                {
                    Document = item.Document,
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    Income = item.Income,
                    DocumentPdf = item.DocumentPdf
                };
                // Id e IsDone vem do próprio CarOperation, pois ele que vem do FROM, os outros vem do INNER JOIN
                clients.Add(client);
            }

            return clients;
        }

        public Client? Get(string id)
        {
            return GetAll().Find(c => c.Document == id);
        }
    }
}
