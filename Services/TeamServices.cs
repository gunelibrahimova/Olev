using DataAccess;
using Entities;
using Helper.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeamServices
    {
        private readonly OleevDbContext _context;

        public TeamServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<TeamLanguage> GetAll()
        {
            var team = _context.teamLanguages.Include(x => x.Team).Where(x => x.LangCode == "Az").ToList();
            return team;
        }

        public Team Ccreate(Team team)
        {
            _context.teams.Add(team);
            _context.SaveChanges();
            return team;
        }

        public void CreateTeam(int TeamID, string Title, string Description, string SubTitle, string Info, string LangCode, string SEO, string PhotoURL)
        {
            TeamLanguage teamLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SubTitle = SubTitle,
                Info = Info,
                SEO = SEO,
                TeamID = TeamID
            };
            _context.teamLanguages.Add(teamLanguages);


            _context.SaveChanges();
        }


        public List<TeamLanguage> GetById(int id)
        {
            return _context.teamLanguages.Where(x => x.TeamID == id).ToList();
        }

        public Team GetTeamById(int id)
        {

            return _context.teams.FirstOrDefault(x => x.Id == id);
        }

        public void EditTeamList(Team team, TeamLanguage teamLanguage)
        {
            teamLanguage.SEO = "asdfg";
            team.PhotoURL = "asdfg";
            _context.teamLanguages.Update(teamLanguage);
            _context.teams.Update(team);
            _context.SaveChanges();
        }

        public void EditTeam(Team team, int TeamID, int LangID, string Title, string Description, string SubTitle, string info, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            team.PhotoURL = PhotoURL;



            _context.teams.Update(team);


            TeamLanguage teamLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                Info = info,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                TeamID = TeamID
            };
            var updatedEntity = _context.Entry(teamLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
