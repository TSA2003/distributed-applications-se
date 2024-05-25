using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Client.Helpers;
using Client.Models;
using System.Text.Json;
using System.Net;

namespace Client.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApiClient _client;

        public TeachersController(ApiClient client)
        {
            _client = client;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync<List<TeacherViewModel>>("/api/teachers");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            return View(model);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var response = await _client.GetAsync<TeacherViewModel>("/api/teachers/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Age, Salary, EmploymentDate, Experience")] TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsync("/api/teachers/", model);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            
            return RedirectToAction("Index");
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var response = await _client.GetAsync<TeacherViewModel>("/api/teachers/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, FirstName, LastName, Age, Salary, EmploymentDate, Experience")] TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PutAsync("/api/teachers/", model);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            
            return RedirectToAction("Index");
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var response = await _client.GetAsync<TeacherViewModel>("/api/teachers/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _client.DeleteAsync<TeacherViewModel>("/api/teachers/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            return RedirectToAction("Index");
        }
    }
}
