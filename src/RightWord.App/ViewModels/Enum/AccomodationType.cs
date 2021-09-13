using System.ComponentModel;

namespace RightWord.App.ViewModels
{
    public enum AccommodationType
    {
        No,
        [Description("Yes, Student Accommodation")]
        Student,
        [Description("Yes, Host Family")]
        HostFamily
    }
}