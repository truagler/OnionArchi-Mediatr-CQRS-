using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archi.Application.Handlers.Commands;
using Archi.Application.Handlers.Commands.UpdateBook;
using Archi.Application.Handlers.Queries;
using Archi.Application.Handlers.Queries.GetBook;
using Archi.Domain.Model;
using Archi.Framework.Dto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;

namespace Archi.Framework.Controller
{
    public class BookController: ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/getbooks")]
        public async Task<Task<List<Book>>> GetBooks()
        {
            return await _mediator.Send(new GetBooksQuery());
        }

        [HttpGet]
        [Route("/getbook/{id?}")]
        public async Task<Task<Book>> GetBook(Guid id)
        {
            return await _mediator.Send(new GetBookQuery(id));
        }

        [HttpPost]
        [Route("/addbook")]
        public async Task<Book> AddBook([FromBody] BookDto bookDto)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, Book>());

            Mapper mapper = new Mapper(config);

            Book book = mapper.Map<Book>(bookDto);
            
            return await _mediator.Send(new AddBookCommand(book));
        }

        [HttpPost]
        [Route("/updatebook")]
        public async Task<Book> UpdateBook([FromBody] BookDto bookDto)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, Book>());

            Mapper mapper = new Mapper(config);

            Book book = mapper.Map<Book>(bookDto);
            
            return await _mediator.Send(new UpdateBookCommand(book));
        }
    }
}