using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Model;
using WebApiTest.Model.Context;

namespace WebApiTest.Services.Implementattion
{
    public class PersonBusinessImple : IPersonBusiness
    {


        private MySQLContext _context;

        public PersonBusinessImple(MySQLContext context)
        {
            _context = context;
        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if(result != null)  _context.Person.Remove(result);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            //List<Person> persons = new List<Person>();
            //for (int i = 0; i < 5; i++)
            //{
            //    Person pessoa = new Person
            //    {
            //        Id = i,
            //        Nome = "esllen" + i,
            //        Sobrenome = "julio" + i,
            //        Endereco = "rua sem nome" + i,
            //        Genero = "Masculino" + i
            //    };
            //    persons.Add(pessoa);
            //}
            return _context.Person.ToList();
        }

        public Person FindById(long id)
        {
            //return new Person
            //{
            //    Id = 1,
            //    Nome = "esllen",
            //    Sobrenome = "julio",
            //    Endereco = "rua sem nome",
            //    Genero = "Masculino"

            //};
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(id));

            
            return result;


        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));

        }
    }
}
