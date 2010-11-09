﻿using System;
using System.Web.Mvc;
using myDojo.Commands.Users;
using myDojo.Infrastructure.Web;
using MyDojo.Query.Queries;
using myDojo.Web.Models;

namespace myDojo.Web.Controllers
{
    public class UserController : DefaultController
    {
        public ActionResult Register()
        {
            return View(new RegisterUserForm());
        }
        [HttpPost]
        public CommandActionResult<RegisterUser> Register(RegisterUserForm form)
        {
            return Command(new RegisterUser(form.EmailAddress, null), () => RedirectToAction("Edit", new {email = form.EmailAddress}));
        }
        public ActionResult Edit(string email)
        {
            return MappedQuery<GetMartialArtistDetailsByEmail,EditMartialArtistForm>(s =>s.EmailAddress = email);
        }
        public ActionResult Details(Guid id)
        {
            return Query<MartialArtistDetailsById>(q => q.Id = id);
        }
        [HttpPost]
        public CommandActionResult<EditMartialArtistInfo> Edit(EditMartialArtistForm model)
        {
            return Command(new EditMartialArtistInfo(model.Id, model.Name, model.Biography), () => RedirectToAction("List"));
        }
        public ActionResult List()
        {
            return Query<AllMatialArtists>();
        }

    }

   
}
