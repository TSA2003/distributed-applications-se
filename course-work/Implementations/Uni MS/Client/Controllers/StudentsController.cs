using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Microsoft.Extensions.Options;
using Client.Helpers;
using System.Net.Http.Headers;
using System.Text.Json;
using Client.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Client.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApiClient _client;

        public StudentsController(ApiClient client)
        {
            _client = client;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync<List<StudentViewModel>>("/api/students");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            return View(model);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var response = await _client.GetAsync<StudentViewModel>("/api/students/" + id);

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

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            var model = new StudentViewModel();
            var response = await _client.GetAsync<List<CourseViewModel>>("/api/courses");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            model.AvailableCourses = response.Data;
            return View(model);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName,LastName,Age,AverageGrade,CourseId")] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsync<StudentViewModel, StudentViewModel>("/api/students/", model);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var studentsResponse = await _client.GetAsync<StudentViewModel>("/api/students/" + id);

            if (studentsResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = studentsResponse.Data;

            if (model != null)
            {
                var coursesResponse = await _client.GetAsync<List<CourseViewModel>>("/api/courses");

                if (coursesResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }
;
                model.AvailableCourses = coursesResponse.Data;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, FirstName,LastName,Age,AverageGrade,CourseId")] StudentViewModel model)
        {
            var response = await _client.PutAsync<StudentViewModel, StudentViewModel>("/api/students/", model);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var response = await _client.GetAsync<StudentViewModel>("/api/students/" + id);

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

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _client.DeleteAsync<StudentViewModel>("/api/students/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            return RedirectToAction("Index");
        }
    }
}
