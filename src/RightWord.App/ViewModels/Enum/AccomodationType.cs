using System.ComponentModel;

namespace RightWord.App.ViewModels
{
    public enum AccomodationType
    {
        No,
        [Description("Yes, Student Accomodation")]
        Student,
        [Description("Yes, Host Family")]
        HostFamily
    }
}