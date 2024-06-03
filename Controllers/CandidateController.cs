using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using resume.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace resume.Controllers;

public class CandidateController : Controller
{
    //private readonly

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Process(IFormCollection form)
    {
        string fullNameFetch = form["fullName"].ToString();
        string cityFetch = form["city"].ToString();
        string cityZipFetch = form["cityZip"].ToString();
        string phoneFetch = form["phone"].ToString();
        string emailFetch = form["email"].ToString();

        string skillsFetch = form["skillTags"].ToString();
        string[] tagArray = skillsFetch.Split(',');

        IEnumerable<string> employersEnumerable = form["employer"].ToArray();
        string[] employersArray = employersEnumerable.ToArray();

        IEnumerable<string> locationsEnumerable = form["location"].ToArray();
        string[] locationsArray = locationsEnumerable.ToArray();

        IEnumerable<string> rolesEnumerable = form["role"].ToArray();
        string[] rolesArray = rolesEnumerable.ToArray();

        IEnumerable<string> roleStartsEnumerable = form["roleStart"].ToArray();
        string[] roleStartsArray = roleStartsEnumerable.ToArray();

        IEnumerable<string> roleEndsEnumerable = form["roleEnd"].ToArray();
        string[] roleEndsArray = roleEndsEnumerable.ToArray();

        IEnumerable<string> roleDescriptionsEnumerable = form["roleDescription"].ToArray();
        string[] roleDescriptionsArray = roleDescriptionsEnumerable.ToArray();

        IEnumerable<string> universitysEnumerable = form["university"].ToArray();
        string[] universitysArray = universitysEnumerable.ToArray();

        IEnumerable<string> universityLocationsEnumerable = form["universityLocation"].ToArray();
        string[] universityLocationsArray = universityLocationsEnumerable.ToArray();

        IEnumerable<string> programsEnumerable = form["program"].ToArray();
        string[] programsArray = programsEnumerable.ToArray();

        IEnumerable<string> completionsEnumerable = form["completion"].ToArray();
        string[] completionsArray = completionsEnumerable.ToArray();

        IEnumerable<string> remarksEnumerable = form["remark"].ToArray();
        string[] remarksArray = remarksEnumerable.ToArray();

        IEnumerable<string> titlesEnumerable = form["title"].ToArray();
        string[] titlesArray = titlesEnumerable.ToArray();

        IEnumerable<string> certDescriptionsEnumerable = form["certDescription"].ToArray();
        string[] certDescriptionsArray = certDescriptionsEnumerable.ToArray();

        IEnumerable<string> linksEnumerable = form["link"].ToArray();
        string[] linksArray = linksEnumerable.ToArray();

        IEnumerable<string> projectsEnumerable = form["project"].ToArray();
        string[] projectsArray = projectsEnumerable.ToArray();

        IEnumerable<string> projectDescriptionsEnumerable = form["projectDescription"].ToArray();
        string[] projectDescriptionsArray = projectDescriptionsEnumerable.ToArray();

        /*List<string> employersFetch = new List<string>();
        List<string> locationsFetch = new List<string>();
        List<string> rolesFetch = new List<string>();
        List<string> roleStartsFetch = new List<string>();
        List<string> roleEndsFetch = new List<string>();
        List<string> roleDescriptionsFetch = new List<string>();
        
        foreach (var key in form.Keys)
        {
            /*if (key.StartsWith("employer"))
            {
                employersFetch.Add(form[key]);
            }
            if (key.StartsWith("location"))
            {
                locationsFetch.Add(form[key]);
            }
            if (key.StartsWith("role"))
            {
                rolesFetch.Add(form[key]);
            }
            if (key.StartsWith("roleStart"))
            {
                roleStartsFetch.Add(form[key]);
            }
            if (key.StartsWith("roleEnd"))
            {
                roleEndsFetch.Add(form[key]);
            }
            if (key.StartsWith("roleDescription"))
            {
                roleDescriptionsFetch.Add(form[key]);
            }
        }*/

        /*newCandidate.Employers = employersFetch.ToArray();
        newCandidate.Locations = locationsFetch.ToArray();
        newCandidate.Roles = rolesFetch.ToArray();
        newCandidate.RoleStarts = roleStartsFetch.ToArray();
        newCandidate.RoleEnds = roleEndsFetch.ToArray();
        newCandidate.RoleDescriptions = roleDescriptionsFetch.ToArray();*/

        //string[] employerArray = employersFetch.Split(',');



        Candidate newCandidate = new Candidate
        {
            FullName = fullNameFetch,
            City = cityFetch,
            CityZip = cityZipFetch,
            Phone = phoneFetch,
            Email = emailFetch,
            Skills = tagArray,
            Employers = employersArray,
            Locations = locationsArray,
            Roles = rolesArray,
            RoleStarts = roleStartsArray,
            RoleEnds = roleEndsArray,
            RoleDescriptions = roleDescriptionsArray,
            Universitys = universitysArray,
            UniversityLocations = universityLocationsArray,
            Programs = programsArray,
            Completions = completionsArray,
            Remarks = remarksArray,
            Titles = titlesArray,
            CertDescriptions = certDescriptionsArray,
            Links = linksArray,
            Projects = projectsArray,
            ProjectDescriptions = projectDescriptionsArray
        };

        List<Candidate> candidates = new List<Candidate>();
        // Add the newCandidate to the list
        candidates.Add(newCandidate);

        int employerSection = newCandidate.Employers.Length;
        int universitySection = newCandidate.Universitys.Length;
        int certSection = newCandidate.Titles.Length;
        int projectSection = newCandidate.Projects.Length;


        using (MemoryStream ms = new MemoryStream())
            {
                BaseFont TNR = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font infoNameTimes = new Font(TNR, 18, Font.BOLD);
                Font defaultTimes = new Font(TNR, 11);
                Font sectionTimes = new Font(TNR, 11, Font.BOLD);
                Font employerTimes = new Font(TNR, 12, Font.BOLD);
                Font dateTimes = new Font(TNR, 10);
                //document.SpacingAfter = 10f;

                Document document = new Document();
                PdfWriter.GetInstance(document, ms);
                document.Open();
                document.Add(new Paragraph(newCandidate.FullName, infoNameTimes));
                document.Add(new Paragraph(newCandidate.City + ", " + newCandidate.CityZip + " • " + newCandidate.Phone + " • " + newCandidate.Email, defaultTimes));

                LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 1); //100f
                document.Add(new Chunk(line));
                //document.Add(new Paragraph(""));

                document.Add(new Paragraph("SKILLS", sectionTimes));
                document.Add(new Paragraph(" "));
                foreach(string tag in newCandidate.Skills)
                {
                    document.Add(new Chunk(tag + ", ", defaultTimes));
                    //document.SpacingAfter = 10f; // Add space after the line
                    //document.Add(spacer);
                }
                document.Add(new Paragraph(" "));

                document.Add(new Chunk(line));

                document.Add(new Paragraph("EXPERIENCE", sectionTimes));
                document.Add(new Paragraph(" "));
                for (int i = 0; i < employerSection; i++) 
                {
                    document.Add(new Chunk(newCandidate.Employers[i] + " ", employerTimes));
                    document.Add(new Chunk(newCandidate.Locations[i] + " • ", defaultTimes));
                    document.Add(new Chunk(newCandidate.Roles[i], sectionTimes));
                    document.Add(new Paragraph(newCandidate.RoleStarts[i] + " - " + newCandidate.RoleEnds[i], dateTimes));
                    document.Add(new Paragraph(newCandidate.RoleDescriptions[i], defaultTimes));
                    document.Add(new Paragraph(" "));
                } 

                document.Add(new Chunk(line));

                document.Add(new Paragraph("EDUCATION AND CERTIFICATION", sectionTimes));
                document.Add(new Paragraph(" "));
                for (int i = 0; i < universitySection; i++) 
                {
                    document.Add(new Chunk(newCandidate.Universitys[i] + " ", employerTimes));
                    document.Add(new Chunk(newCandidate.UniversityLocations[i] + " • ", defaultTimes));
                    document.Add(new Chunk(newCandidate.Programs[i], sectionTimes));
                    document.Add(new Paragraph(newCandidate.Completions[i] + " • " + newCandidate.Remarks[i], dateTimes));
                    document.Add(new Paragraph(" "));
                }
                for (int i = 0; i < certSection; i++) 
                {
                    document.Add(new Chunk(newCandidate.Titles[i], employerTimes));
                    document.Add(new Chunk(": " + newCandidate.CertDescriptions[i], defaultTimes));
                    document.Add(new Paragraph(newCandidate.Links[i], defaultTimes));
                    document.Add(new Paragraph(" "));
                }

                document.Add(new Chunk(line));

                document.Add(new Paragraph("PROJECTS", sectionTimes));
                document.Add(new Paragraph(" "));
                for (int i = 0; i < projectSection; i++) 
                {
                    document.Add(new Chunk(newCandidate.Projects[i], employerTimes));
                    document.Add(new Paragraph(newCandidate.ProjectDescriptions[i], defaultTimes));
                }


                document.Close();

                return File(ms.ToArray(), "application/pdf", newCandidate.FullName + "_RESUME.pdf");
                //return View();
            }

        //Console.WriteLine(newCandidate.Phone);

        //return View();
    }
}