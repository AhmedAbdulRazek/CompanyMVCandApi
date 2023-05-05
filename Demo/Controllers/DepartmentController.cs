using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.BL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.DAL.Entity;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {


        #region Fields

        //DepartmentRep department = new DepartmentRep();

        //Loosly Coupled
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        //Tightly Coupled
        //DepartmentRep department;

        #endregion



        #region ctor

        public DepartmentController(IDepartmentRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }

        #endregion



        #region Actions 


        

        public IActionResult Index()
        {
            var data = department.Get();
            var model = mapper.Map<IEnumerable<DepartmentVM>>(data);//mapping from entity to view model

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);//mapping from entity to view model
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);//mapping from view model to entity 
                    department.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);//mapping from entity to view model
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);//mapping from view model to entity 
                    department.Edit(data);
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch (Exception ex)
            {

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentVM>(data);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var data = mapper.Map<Department>(model);
                department.Delete(data);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View(model);
            }
        }




        #endregion








    }
}
