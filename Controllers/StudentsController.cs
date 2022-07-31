using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UniReg.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniReg.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniRegContext _db;

    public StudentsController(UniRegContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student, int CourseId)
    {
        _db.Students.Add(student);
        _db.SaveChanges();
        if (CourseId != 0)
        {
            _db.Attendance.Add(new Attendance() { CourseId = CourseId, StudentId = student.StudentId });
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
        .Include(student => student.JoinEntities)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
        var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
        return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Item student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.Attendance.Add(new Attendance() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCategory(int id)
    {
        var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
        ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
        return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
        if (CourseId != 0)
        {
          _db.Attendance.Add(new Attendance() { CourseId = CourseId, StudentId = student.CourseId });
          _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCategory(int joinId)
    {
        var joinEntry = _db.Attendance.FirstOrDefault(entry => entry.AttendaceId == joinId);
        _db.Attendance.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}