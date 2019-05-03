using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Liga.Models;
namespace Liga.Controllers
{
    public class LeagueTablesController : Controller
    {
        // GET: LeagueTables
        public ActionResult Index()
        {

            List<LeagueTable> results = new List<LeagueTable>();

            LeaguesManagerDbContext dbM = new LeaguesManagerDbContext();
            LeaguesManagerDbContext dbC = new LeaguesManagerDbContext();

            var matches = dbM.Matches
                .Include(m => m.AwayClubs)
                .Include(m => m.HomeClubs);

            var clubs = dbC.Clubs
                .Include(c => c.League)
                .Include(c => c.Manager)
                .Include(c => c.Stadium);

            if (clubs.Count() > 0)
            {
                foreach (Club c in clubs)
                {
                    LeagueTable res = new LeagueTable();
                    res.TeamID = c.ID;
                    res.TeamName = c.Name;

                    var wins = 0;
                    var losses = 0;
                    var draws = 0;

                    var goalsFor = 0;
                    var goalsAgainst = 0;

                    var points = 0;

                    var allTeamMatches = matches
                        .Where(x => x.HomeTeamID == c.ID || x.AwayTeamID == c.ID);

                    var allTeamHomeMatches = allTeamMatches
                        .Where(x => x.HomeTeamID == c.ID);
                    var allTeamAwayMatches = allTeamMatches
                        .Where(x => x.AwayTeamID == c.ID);

                    foreach (Match m in allTeamHomeMatches)
                    {
                        if (m.GoalsScoredHomeTeam > m.GoalsScoredAwayTeam)
                        {
                            wins++;
                            points += 3;
                        }
                        if (m.GoalsScoredHomeTeam < m.GoalsScoredAwayTeam)
                        {
                            losses++;
                        }
                        if (m.GoalsScoredHomeTeam == m.GoalsScoredAwayTeam)
                        {
                            draws++;
                            points += 1;
                        }

                        goalsFor += m.GoalsScoredHomeTeam;
                        goalsAgainst += m.GoalsScoredAwayTeam;

                    }

                    foreach (Match m in allTeamAwayMatches)
                    {
                        if (m.GoalsScoredAwayTeam > m.GoalsScoredHomeTeam)
                        {
                            wins++;
                            points += 3;
                        }
                        if (m.GoalsScoredAwayTeam < m.GoalsScoredHomeTeam)
                        {
                            losses++;
                        }
                        if (m.GoalsScoredHomeTeam == m.GoalsScoredAwayTeam)
                        {
                            draws++;
                            points += 1;
                        }

                        goalsFor += m.GoalsScoredAwayTeam;
                        goalsAgainst += m.GoalsScoredHomeTeam;

                    }

                    res.Wins = wins;
                    res.Losses = losses;
                    res.Draws = draws;
                    res.GoalsFor = goalsFor;
                    res.GoalsAgainst = goalsAgainst;
                    res.GoalDifference = goalsFor - goalsAgainst;
                    res.Points = points;

                    results.Add(res);
                }
            }


            return View(results.OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ThenByDescending(x => x.GoalsFor)
                .ThenBy(x => x.GoalsAgainst));
        }






        // GET: LeagueTables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeagueTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeagueTables/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LeagueTables/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeagueTables/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LeagueTables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeagueTables/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
