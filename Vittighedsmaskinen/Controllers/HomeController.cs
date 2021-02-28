using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vittighedsmaskinen.ApiKeyFolder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vittighedsmaskinen.Controllers
{
    
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        [Route("/")]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "For at få dansk, gå til: https://localhost:44398/api/Home/lan?Language=dk",
                                        "For at få engelsk, gå til: https://localhost:44398/api/Home/lan?Language=en" };
        }

        [HttpGet]
        [Route("lan")]
        public IEnumerable<string> GetLang(string language)
        {
            List<string> temp = new List<string>();
            if (language != null)
            {
                CookieOptions co = new CookieOptions() { Expires = DateTime.Now.AddYears(1) };
                Response.Cookies.Append("Language", language, co);
            }
            temp.Add("Dit sprog er gemt");
            foreach (var item in GetCatList())
            {
                temp.Add("For at se " + item +", gå til: https://localhost:44398/api/Home/cat?Category=" + item);
            }
            return temp;
        }

        [HttpGet]
        [Route("cat")]
        public string GetCat(string category)
        {
            if (category != null)
            {
                Response.Cookies.Append("Category", category);
            }
            return "Din kategori er gemt. \n Gå til https://localhost:44398/api/Home/joke for at få en joke";
        }

        [HttpGet]
        [Route("joke")]
        public string GetJoke()
        {
            string joke = "";
            bool validJoke = false;

            while (validJoke == false)
            {
                string category = Request.Cookies["Category"];
                if (Request.Cookies["Language"] == "en")
                {
                    category = "enJokes";
                }
                joke = DAL.GetRandomJoke(category);
                if (HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes") == null)
                {
                    break;
                }
                else
                {
                    if (DAL.GetJokeCategory(category).Count == HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes").Count || DAL.GetJokeCategory(category).Count <= HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes").Count)
                    {
                        joke = "Ikke flere jokes";
                        validJoke = true;
                        break;
                    }
                    else
                    {
                        foreach (var item in HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes"))
                        {
                            if (joke == item)
                            {
                                validJoke = false;
                                break;
                            }
                            else
                            {
                                validJoke = true;
                            }
                        }
                        
                    }
                }
            }
            AddUsedJoke(joke);
            return joke;
        }

        [HttpGet]
        [Route("cat-li")]
        public IEnumerable<string> GetCatList()
        {
            List<string> categories = new List<string>();
            foreach (var item in DAL.GetCategoryList())
            {
            if (Request.Cookies["Language"] == "en")
            {
                    if (item == "enJokes")
                    {
                        categories.Add(item);
                    }
            }
                else
                {
                    if (item != "enJokes")
                    {
                        categories.Add(item);
                    }
                }
            }
            return categories;
        }

        [HttpGet]
        [Route("used")]
        public List<string> GetUsedJokes()
        {
            List<string> usedJokes = HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes");
            return usedJokes;
        }

        public void AddUsedJoke(string joke)
        {
            List<string> usedJokes = new List<string>();
            if (HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes") != null)
            {
                usedJokes = HttpContext.Session.GetObjectFromJson<List<string>>("UsedJokes");
            }
            usedJokes.Add(joke);
            HttpContext.Session.SetObjectAsJson("UsedJokes", usedJokes);
        }

        [HttpGet]
        [Route("pro")]
        [Authorize(Policy = Policies.OnlyProgrammer)]
        public string GetProgrammerJoke()
        {
            return "What is a ghost's favorite type? \n Booooooolean";
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
