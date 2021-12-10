using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeMoMVCNetCore.Data;
using DeMoMVCNetCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DeMoMVCNetCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDBContext _context;
        ExcelProcess  _excelPro = new ExcelProcess();   
         
         public IConfiguration Configuration {get;}
        public CategoriesController(ApplicationDBContext context)
        {
            _context = context;    
        }        
        private int WriteDatatableToDatabase(DataTable dt)
        {
            try
            {
            var con = Configuration.GetConnectionString("ApplicationDBContext");
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "Categories";
            bulkCopy.ColumnMappings.Add(1, "CategoryName");
            bulkCopy.ColumnMappings.Add(2, "quanity");
            bulkCopy.ColumnMappings.Add(3, "CategoryDate");
            bulkCopy.ColumnMappings.Add(4, "CategoryNote");

            bulkCopy.WriteToServer(dt);

            }
            catch
            {
                return 0;
            }
            return dt.Rows.Count;
        }       

 
        // GET: Categories
        // [HttpPost]      
        //     public string Index(string keySearch, bool notUsed)
        //     {
        //         return "From [HttpPost]Index: filter on " + keySearch;
        //     }
        public async Task<IActionResult> Index(string movieGenre ,string keySearch)
        {
            IQueryable<string> genreQuery = from m in _context.Categories
                                            orderby m.CategoryName
                                            select m.CategoryName;


            var model = from m in _context.Categories
                 select m;

            if (!String.IsNullOrEmpty(keySearch))
            {
                model = model.Where(s => s.CategoryName.Contains(keySearch));
            }
             if (!string.IsNullOrEmpty(movieGenre))
            {
                model = model.Where(x => x.CategoryName == movieGenre);
            }

            var cateTest = new TestSearch
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                CateTest = await model.ToListAsync()
            };

            return View(cateTest);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Categorynote,quantity,CategoryDate")] Category category)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(category);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(category);
        // }
       [HttpPost] 
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Categorynote,quantity,CategoryDate")]Category category,IFormFile abc) 
        {
            if (abc!=null)
            {
                string fileExtension = Path.GetExtension(abc.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = ".NetCore";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (abc.Length > 0)
                        {
                            _context.Add(category);
                            await _context.SaveChangesAsync();
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await abc.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database                            
                                if (category.CategoryID==0)
                                {
                                    WriteDatatableToDatabase (dt);
                                }
                                else
                                {
                                    WriteDatatableToDatabase (dt);
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            return View();
        }
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,Categorynote,quantity,CategoryDate")] Category category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
