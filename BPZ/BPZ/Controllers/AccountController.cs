﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPZ.Models;

namespace BPZ.Controllers
{
    public class AccountController : Controller
    {
        private BPZEntities _context;

        public AccountController()
        {
            _context = new BPZEntities();
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

       


    }
}