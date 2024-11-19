using System.Reflection.Metadata.Ecma335;
using NinetiesTV;

List<Show> shows = DataLoader.GetShows();

ResultPrinter.Print("All Names", Names(shows));
ResultPrinter.Print("Alphabetical Names", NamesAlphabetically(shows));
ResultPrinter.Print("Ordered by Popularity", ShowsByPopularity(shows));
ResultPrinter.Print("Shows with an '&'", ShowsWithAmpersand(shows));
ResultPrinter.Print("Latest year a show aired", MostRecentYear(shows));
ResultPrinter.Print("Average Rating", AverageRating(shows));
ResultPrinter.Print("Shows only aired in the 90s", OnlyInNineties(shows));
ResultPrinter.Print("Top Three Shows", TopThreeByRating(shows));
ResultPrinter.Print("Shows starting with 'The'", TheShows(shows));
ResultPrinter.Print("All But the Worst", AllButWorst(shows));
ResultPrinter.Print("Shows with Few Episodes", FewEpisodes(shows));
ResultPrinter.Print("Shows Sorted By Duration", ShowsByDuration(shows));
ResultPrinter.Print("Comedies Sorted By Rating", ComediesByRating(shows));
ResultPrinter.Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
ResultPrinter.Print("Most Episodes", MostEpisodes(shows));
ResultPrinter.Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
ResultPrinter.Print("Best Drama", BestDrama(shows));
ResultPrinter.Print("All But Best Drama", AllButBestDrama(shows));
ResultPrinter.Print("Good Crime Shows", GoodCrimeShows(shows));
ResultPrinter.Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
ResultPrinter.Print("Most Words in Title", WordieastName(shows));
ResultPrinter.Print("All Names", AllNamesWithCommas(shows));
ResultPrinter.Print("All Names with And", AllNamesWithCommasPlsAnd(shows));

/**************************************************************************************************
    The Exercises

    Above each method listed below, you'll find a comment that describes what the method should do.
    Your task is to write the appropriate LINQ code to make each method return the correct result.

**************************************************************************************************/

// 1. Return a list of each of show names.
static List<string> Names(List<Show> shows)
{
    return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
}

// 2. Return a list of show names ordered alphabetically.
static List<string> NamesAlphabetically(List<Show> shows)
{
    return shows.OrderBy(s => s.Name).Select(s => s.Name).ToList();
}

// 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
static List<Show> ShowsByPopularity(List<Show> shows)
{
    return shows.OrderByDescending(s => s.ImdbRating).ToList();
}

// 4. Return a list of shows whose title contains an & character.
static List<Show> ShowsWithAmpersand(List<Show> shows)
{
    return shows.Where(s => s.Name.Contains("&")).ToList();
}

// 5. Return the most recent year that any of the shows aired.
static int MostRecentYear(List<Show> shows)
{
    return shows.Max(s => s.StartYear);
}

// 6. Return the average IMDB rating for all the shows.
static double AverageRating(List<Show> shows)
{
    return shows.Average(s => s.ImdbRating);
}

// 7. Return the shows that started and ended in the 90s.
static List<Show> OnlyInNineties(List<Show> shows)
{
    return shows.Where(s => s.StartYear >= 1990 && s.EndYear < 2000).ToList();
}

// 8. Return the top three highest rated shows.
static List<Show> TopThreeByRating(List<Show> shows)
{
    return shows.OrderByDescending(s => s.ImdbRating).Take(3).ToList();
}

// 9. Return the shows whose name starts with the word "The".
static List<Show> TheShows(List<Show> shows)
{
    return shows.Where(s => s.Name.StartsWith("The")).ToList();
}

// 10. Return all shows except for the lowest rated show.
static List<Show> AllButWorst(List<Show> shows)
{
    return shows.OrderByDescending(s => s.ImdbRating).SkipLast(1).ToList();
}

// 11. Return the names of the shows that had fewer than 100 episodes.
static List<string> FewEpisodes(List<Show> shows)
{
    return shows.Where(s => s.EpisodeCount < 100).Select(s => s.Name).ToList();
}

// 12. Return all shows ordered by the number of years on air.
//     Assume the number of years between the start and end years is the number of years the show was on.
static List<Show> ShowsByDuration(List<Show> shows)
{
    return shows.OrderBy(s => s.EndYear - s.StartYear).ToList();
}

// 13. Return the names of the comedy shows sorted by IMDB rating.
static List<string> ComediesByRating(List<Show> shows)
{
    return shows.Where(s => s.Genres.Contains("Comedy")).OrderBy(s => s.ImdbRating).Select(s => s.Name).ToList();
}

// 14. Return the shows with more than one genre ordered by their starting year.
static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
{
    return shows.Where(s => s.Genres.Count() > 1).OrderBy(s => s.StartYear).ToList();
}

// 15. Return the show with the most episodes.
static Show MostEpisodes(List<Show> shows)
{
    return shows.First(s => s.EpisodeCount == shows.Max(s => s.EpisodeCount));
}

// 16. Order the shows by their ending year then return the first 
//     show that ended on or after the year 2000.
static Show EndedFirstAfterTheMillennium(List<Show> shows)
{
    return shows.OrderBy(s => s.EndYear).First(s => s.EndYear >= 2000);
}

// 17. Order the shows by rating (highest first) 
//     and return the first show with genre of drama.
static Show BestDrama(List<Show> shows)
{
    return shows.OrderByDescending(s => s.ImdbRating).First(s => s.Genres.Contains("Drama"));
}

// 18. Return all dramas except for the highest rated.
static List<Show> AllButBestDrama(List<Show> shows)
{
    return shows.Where(s => s.Genres.Contains("Drama")).OrderByDescending(s => s.ImdbRating).Skip(1).ToList();
}

// 19. Return the number of crime shows with an IMDB rating greater than 7.0.
static int GoodCrimeShows(List<Show> shows)
{
    return shows.Count(s => s.ImdbRating > 7 && s.Genres.Contains("Crime"));
}

// 20. Return the first show that ran for more than 10 years 
//     with an IMDB rating of less than 8.0 ordered alphabetically.
static Show FirstLongRunningTopRated(List<Show> shows)
{
    return shows.OrderBy(s => s.Name ).First(s => s.EndYear - s.StartYear > 10 && s.ImdbRating < 8);
}

// 21. Return the show with the most words in the name.
static Show WordieastName(List<Show> shows)
{
    return shows.First(s => s.Name.Split(" ").Count() == shows.Max(s => s.Name.Split(" ").Count() ));
}

// 22. Return the names of all shows as a single string seperated by a comma and a space.
static string AllNamesWithCommas(List<Show> shows)
{
    return string.Join(", ", shows.Select(s => s.Name));
}

// 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
static string AllNamesWithCommasPlsAnd(List<Show> shows)
{
    return string.Join(", ", shows.Select(s => s.Name).SkipLast(1)) + " and " + shows.Select(s => s.Name).Last();
}


/**************************************************************************************************
    CHALLENGES

    These challenges are very difficult and may require you to research LINQ methods that we haven't
    talked about. Such as:

    GroupBy()
    SelectMany()
    Count()

**************************************************************************************************/

// 1. Return the genres of the shows that started in the 80s.
ResultPrinter.Print("genres of shows in the 80s", genresofshowsin80s(shows));
static List<string> genresofshowsin80s(List<Show> shows)
{
    return shows.Where(s => s.StartYear >= 1980 && s.StartYear < 1990).SelectMany(s => s.Genres).Distinct().ToList();
}
// 2. Print a unique list of geners.
ResultPrinter.Print("Unique List of Genres", uniqueListOfGenres(shows));
static List<string> uniqueListOfGenres(List<Show> shows)
{
    return shows.SelectMany(s => s.Genres).Distinct().ToList();
}
// 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
ResultPrinter.Print("shows during 1987-2018", showcountspecific(shows));
static List<string>  showcountspecific(List<Show> shows)
{
    List<string> yearList = new List<string>();
    var showsPerYear = shows.Where(s => s.StartYear >= 1987 && s.StartYear <= 2018).OrderBy(s => s.StartYear).GroupBy(s => s.StartYear).Select(sy => new {Year = sy.Key, Count = sy.Count() }).ToList();
     for (int year = 1987 ; year <= 2018; year++)    
    {
        var showperyear = showsPerYear.FirstOrDefault(spy => spy.Year == year);
        if (showperyear != null)
        {
            yearList.Add($"{year} : {showperyear.Count}");
        }else
        {
            yearList.Add($"{year} : {0}");
        }
        
    };
    return yearList;
}
// 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
ResultPrinter.Print("length of all episodes for each show", showtotalduration(shows));
static List<string> showtotalduration(List<Show> shows)
{
    return shows.Select(show => 
    {
        bool isComedy = show.Genres.Contains("Comedy");
        return $"{show.Name} : {show.EpisodeCount * (isComedy ? 22 : 42 )}";

    }).ToList();
    
}
// 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.

ResultPrinter.Print("ratings for each year", YearRatings(shows));
static string YearRatings (List<Show> shows)
{
  return shows.SelectMany(show => Enumerable.Range(show.StartYear, show.EndYear - show.StartYear + 1)
                                    .Select(year => new {Year = year, Rating = show.ImdbRating}))
    .GroupBy(group => group.Year)
    .Select(group => new {Year = group.Key, Average = group.Average(x => x.Rating) })
    .OrderByDescending(group => group.Average).Select(year => $"{year.Year} : {year.Average}").First();
                                                    
}


/**************************************************************************************************
 There is no code to write or change below this line, but you might want to read it.
**************************************************************************************************/
class ResultPrinter
{
    public static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

    public static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

    public static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

    public static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

    public static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

    public static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
        Console.WriteLine("--------------------------------------------");
    }
}