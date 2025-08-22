using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            int RecipeID = 0;
            string Title = "";
            string Descripton = "";

            var table = new DataTable();
            string queryString = "Select RecipeID ,Title ,Descripton from dbo.Recipes";
            //string dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            string connectionString = "Data Source=LAPTOP-NM1U63FH; Initial Catalog=Scentsy;Integrated Security=True;";
            List<RecipeViewModel> recipeListVM = new List<RecipeViewModel>();
            List<Recipe> recipeList = new List<Recipe>();
            //Recipe recipe = new Recipe();
            try
            {
                using (var da = new SqlDataAdapter(queryString, connectionString))
                {
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Recipe recipe = new Recipe();
                        RecipeID = (int)row["RecipeID"];
                        Title = row["Title"].ToString();
                        Descripton = row["Descripton"].ToString().Trim();
                        recipe.RecipeId = RecipeID;
                        recipe.Title = Title;
                        recipe.Descripton = Descripton;

                        recipeList.Add(recipe);

                        //Movie.Add(new Movie(RecipeID, Title, Descripton));
                    }
                }
            }
            catch
            {

            }
            var recipeViewModel = new RecipeViewModel
            {
                //Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Recipes = recipeList
            };
            return View(recipeViewModel);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public IActionResult Create([Bind("Title,Descripton")] Recipe recipe)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-NM1U63FH; Initial Catalog=Scentsy;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Do work here.  
                }

                //string queryString = "INSERT INTO Recipes " +
                //   "(Title, Descripton) Values('test1', 'test d1')";

                //SqlCommand command = new SqlCommand(queryString, connection);
                //Int32 recordsAffected = command.ExecuteNonQuery();

                ////var updateString = "INSERT INTO[dbo].[Recipes] ([Title],[Descripton]) VALUES ('Test', 'Description of Recipe')";
                //return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
