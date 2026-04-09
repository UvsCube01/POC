using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StudentManagement.MVVM.Models.StudentList
{
    public partial class Student : ObservableObject
    {
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _department;
    }
}
