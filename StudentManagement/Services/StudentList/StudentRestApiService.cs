using StudentManagement.MVVM.Models.StudentList;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace StudentManagement.Services.StudentList
{
    public class StudentRestApiService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://69df312fd6de26e11928b581.mockapi.io/api/v1/Student";

        public StudentRestApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Student>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<List<Student>>();
                    return users ?? new List<Student>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching users: {ex.Message}");
            }
            return new List<Student>();
        }

        public async Task<Student> GetById(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching user {id}: {ex.Message}");
            }
            return null;
        }

        public async Task<Student> Add(Student user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, user);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding user: {ex.Message}");
            }
            return null;
        }

        public async Task<Student> Update(Student user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{user.Id}", user);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating user {user.Id}: {ex.Message}");
            }
            return null;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting user {id}: {ex.Message}");
            }
            return false;
        }
    }
}
