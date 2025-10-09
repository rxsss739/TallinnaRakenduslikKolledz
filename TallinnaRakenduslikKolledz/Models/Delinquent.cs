using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public enum Violations
    {
        Mõrv,
        Rööv,
        Vandaliseerimine,
        Pangarööv,
        Kõndimine
    }

    public class Delinquent
    {
        [Key]
        public int DelinquentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violations Violation { get; set; }
        public string TeacherOrStudent { get; set; }
        public string Situation { get; set; }
    }
}
