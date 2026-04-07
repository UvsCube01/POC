using BindingDemo.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BindingDemo.ViewModel
{
    public partial class StudentViewModel : ObservableObject
    {
        #region Private Fields
        private Student _student;
        [ObservableProperty]
        private string _firstName;        
        [ObservableProperty]
        private string _lastName;        
        [ObservableProperty]
        private string _fullName = "Please Enter the Name";
        #endregion
         

        #region Constructor
        public StudentViewModel()
        {
            _student = new Student();
        }
        #endregion

        #region Private Methods
        [RelayCommand]
        private void GenerateName()
        {
            FullName = $"Hello,{FirstName} {LastName} Relay Command Working!";
        }
        #endregion
    }
}
