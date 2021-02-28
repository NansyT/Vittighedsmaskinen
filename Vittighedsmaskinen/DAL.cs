using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vittighedsmaskinen
{
    public static class DAL
    {
        static List<string> yoMamaJokes = new List<string>()
        {
            "Hvorfor skød Hitler sig selv? Han så din mor!",
            "Din mor er så fed, at hver gang hun vender sig har hun fødselsdag.",
            "Din mor er så dum, at hun prøvede at klatre Mountain Dew.",
            "Din mor er så fedt, at selv Dora ikke kunne udforske hende.",
            "Din mor er så fed, at vis hun satte sig iPhone ville det blive til en iPad.",
            "Din mor er så stor at hun kan udfylde den mur, som Trump vil bygge.",
            "Din mor er mere åben end 7-Eleven.",
            "Din mor er så fed at når hun skal se fodboldkamp skal hun bestille hele sydsiden af brøndbystadion."
        };
        static List<string> dadJokes = new List<string>()
        {
            "Hvordan bliver man ekspert i tordenvejr? \n – Man tager et lynkursus",
            "Hvad hedder verdens fattigste konge? \n – Kong Kurs",
            "Hvad er det, der går rundt i en spand og siger Dav dav? \n – Det er da en spandauer!",
            "To lamper står og snakker dirty til hinanden. Så spørger den ene efter lidt tid – er du tændt?",
            "Hvilket dyr er det, der elsker at samle efter flasker? \n – Det er panteren",
            "Hvilken reaktion får man, hvis man fortæller en sjov joke til sin motorcykel? – Yamahahaha",
            "Hvad kalder man grise der befinder sig oppe på mars? – Man kalder dem marssvin"
        };
        static List<string> allTheKidsJokes = new List<string>()
        {
            "Alle børnene kom hjem fra Kina – Undtagen Mona, hun fik corona",
            "Alle børnene kom ud af den brændende bøsseklub – Undtagen Søren, han sad fast i Jørgen",
            "Alle børnene kom sikkert ud af fabrikken – Undtagen Fin, Bo og Asker de blev til skin sko og tasker",
            "Alle børnene løb over marken – Undtagen Bo han blev voldtaget af en ko",
            "Alle børnene gik over broen – Undtagen Kaj han faldte ned og blev ædt af en haj",
            "Alle børnene trak sig tilbage da løven åbnede gabet – Undtagen Finn, han stak hovedet ind",
            "Alle børn kikkede bag bussen – Undtagen Jesper han var spændt efter",
            "Alle børnene kom ud fra planteskolen undtagen Rasmus – Han døde af en kaktus",
            "Alle børnene havde respekt for læreren. Undtagen Max – Han stak hende ned med en saks",
            "Alle børnene gik ud af skoven undtagen Camilla – Hun blev ædt af en gorilla"
        };
        static List<string> enJokes = new List<string>()
        {
           "Where does the General keep his armies? In his sleevies.",
           "How does a squid go into battle? Well-armed.",
           "What's the best thing about Switzerland? I don't know, but their flag is a huge plus.",
           "Why aren't koalas actual bears? They don't meet the koalafications.",
           "How do you make holy water? You boil the hell out of it.",
           "I was wondering why the ball was getting bigger. Then it hit me."
        };
        static List<string> noJokes = new List<string>() { "Denne kategori har vi ikke" };
        static List<string> categories = new List<string>()
        {
            "yoMamaJokes",
            "dadJokes",
            "allTheKidsJokes",
            "enJokes"
        };
        public static List<string> GetJokeCategory(string category)
        {
            if (category == "yoMammaJokes")
            {
                return yoMamaJokes;
            }
            else if (category == "dadJokes")
            {
                return dadJokes;
            }
            else if (category == "allTheKidsJokes")
            {
                return allTheKidsJokes;
            }
            else if (category == "enJokes")
            {
                return allTheKidsJokes;
            }
            else
            {
                return noJokes;
            }
        }
        public static List<string> GetCategoryList()
        {
            return categories;
        }

        public static string GetRandomJoke(string category)
        {
            List<string> jokes = DAL.GetJokeCategory(category);
            Random rnd = new Random();
            int index = rnd.Next(0, jokes.Count);
            string joke = jokes[index];
            return joke;
        }
    }
}
