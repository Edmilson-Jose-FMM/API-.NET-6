using AutoMapper;
using MP.ApiDotNet6.Application.DTO;
using MP.ApiDotNet6.Application.Service.Interface;
using MP.ApiDotNet6.Application.Validation;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper= mapper;
            _personRepository = personRepository;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");
            }
            var result = new PersonDTOValidation().Validate(personDTO);

            if (!result.IsValid)
            {
                return ResultService.RequestErrors<PersonDTO>("Problemas de validade",result);
            }

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }
    }
}
