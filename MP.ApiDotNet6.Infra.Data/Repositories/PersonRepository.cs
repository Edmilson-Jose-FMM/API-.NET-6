using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
              
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
             
        }

        public Task<Person> GetByIdAsync(int id)
        {
            return _db.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.Person.ToListAsync();
        }
    }
}
