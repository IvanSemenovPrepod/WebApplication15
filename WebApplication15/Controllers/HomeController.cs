using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        createdb db;
        public HomeController(createdb context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.tablephonebook.ToList());
        }

        public ActionResult Details(int id)
        {
            List<tablephonebook> tfb = db.tablephonebook.ToList();
            tablephonebook c = tfb.FirstOrDefault(user => user.id == id);
            if (c != null)
                return PartialView(c);
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                tablephonebook user = await db.tablephonebook.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create(tablephonebook user)
        {
            db.tablephonebook.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(tablephonebook user)
        {
            db.tablephonebook.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                tablephonebook user = await db.tablephonebook.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                {
                    db.tablephonebook.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
    }
}
