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
using System.Reflection.Metadata;
using System.Net;

namespace Client.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApiClient _client;

        public CoursesController(ApiClient client)
        {
            _client = client;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync<List<CourseViewModel>>("/api/courses/");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = response.Data;

            return View(model);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var response = await _client.GetAsync<CourseViewModel>("/api/courses/" + id);

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

        // GET: Courses/Create
        public async Task<IActionResult> Create()
        {
            var model = new CourseViewModel();
            var response = await _client.GetAsync<List<TeacherViewModel>>("/api/teachers");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            model.AvailableTeachers = response.Data;

            return View(model);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Points, StartDate, EndDate, TeacherId")] CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PostAsync<CourseViewModel, CourseViewModel>("/api/courses/", model);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }                
            }
            
            return RedirectToAction("Index");
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var coursesResponse = await _client.GetAsync<CourseViewModel>("/api/courses/" + id);

            if (coursesResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            var model = coursesResponse.Data;

            if (model != null)
            {
                var teachersResponse = await _client.GetAsync<List<TeacherViewModel>>("/api/teachers");

                if (teachersResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }

                model.AvailableTeachers = teachersResponse.Data;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name, Points, StartDate, EndDate, TeacherId")] CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.PutAsync<CourseViewModel, CourseViewModel>("/api/courses/", model);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("Login", "Users");
                }
            }
            
            return RedirectToAction("Index");
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var response = await _client.GetAsync<CourseViewModel>("/api/courses/" + id);

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

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _client.DeleteAsync<CourseViewModel>("/api/courses/" + id);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "Users");
            }

            return RedirectToAction("Index");
        }
    }
}