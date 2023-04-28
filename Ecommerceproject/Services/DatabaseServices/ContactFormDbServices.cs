using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Ecommerceproject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerceproject.Services.DatabaseServices
{
    public class ContactFormDbServices
    {
        private readonly ContactFormDbRepo _contactServices;

        public ContactFormDbServices(ContactFormDbRepo contactServices)
        {
            _contactServices = contactServices;
        }


        //Adds a contactform to the database
        public async Task AddContactFormAsync(ContactUsFormViewModel form)
        {
            ContactformEntity formEntity = form;
            await _contactServices.AddAsync(formEntity);
        }
    }
}
