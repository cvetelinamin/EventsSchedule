namespace EventsSchedule.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TypicalAgeRange
    {
        [Display(Name = "Бебета и деца до 7 години")]
        BabiesAndTodlers = 1,

        [Display(Name = "Ученици в основно училище")]
        StudentsPrimarySchool = 2,

        [Display(Name = "Гимназисти и студенти")]
        StudentsHighSchool = 3,

        [Display(Name = "Възрастни")]
        Adults = 4,
    }
}
