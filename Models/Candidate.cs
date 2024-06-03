namespace resume.Models
{
    public class Candidate
    {
        public string FullName { get; set;}
        public string City { get; set;}
        public string CityZip { get; set;}
        public string Phone { get; set;}
        public string Email { get; set;}

        public string[] Skills { get; set; }
        public string[] Employers { get; set; }
        public string[] Locations { get; set; }
        public string[] Roles { get; set; }
        public string[] RoleStarts { get; set; }
        public string[] RoleEnds { get; set; }
        public string[] RoleDescriptions { get; set; }

        public string[] Universitys { get; set; }
        public string[] UniversityLocations { get; set; }
        public string[] Programs { get; set; }
        public string[] Completions { get; set; }
        public string[] Remarks { get; set; }

        public string[] Titles { get; set; }
        public string[] CertDescriptions { get; set; }
        public string[] Links { get; set; }

        public string[] Projects { get; set; }
        public string[] ProjectDescriptions { get; set; }
    }
}
