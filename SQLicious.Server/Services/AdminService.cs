﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model.DTOs.Admin;
using SQLicious.Server.Model;
using SQLicious.Server.Options;
using SQLicious.Server.Services.IServices;
using System.Security.Claims;
using SQLicious.Server.Options.Email.IEmail;
using SQLicious.Server.Data.Repository;
using SQLicious.Server.Model.DTOs.Booking;

namespace SQLicious.Server.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IEmailSender _emailSender;
        private readonly AuthenticationService _authService;

        public AdminService(IAdminRepository adminRepository, IEmailSender emailSender, AuthenticationService authService)
        {
            _adminRepository = adminRepository;
            _emailSender = emailSender;
            _authService = authService;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            try
            {
                var listOfAdmins = await _adminRepository.GetAllAdminsAsync();

                return listOfAdmins.Select(a => new Admin
                {
                    Id = a.Id,
                    Email = a.Email,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _adminRepository.GetAdminById(id);
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var admin = await _adminRepository.GetAdminByEmailAsync(email);

            if (admin == null)
            {
                return new LoginResult { Success = false, ErrorMessage = "Invalid email or password." };
            }

            if (!admin.EmailConfirmed)
            {
                return new LoginResult { Success = false, ErrorMessage = "The Email is not confirmed, please check your email for a confirmation link!" };
            }

            
            var result = await _adminRepository.LoginAsync(email, password);

            if (!result.Success)
            {
                return new LoginResult { Success = false, ErrorMessage = "Invalid email or password." };
            }

            // Generate JWT token
            var token = _authService.GenerateToken(admin);

            return new LoginResult { Success = true, Token = token };
        }


        public async Task<AccountCreationResult> CreateAdminAsync(CreateAccountRequestDTO request)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.EmailConfirmed) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.PasswordConfirmed))
            {
                return new AccountCreationResult
                {
                    Success = false,
                    Errors = new List<string> { "All fields are required." }
                };
            }

            // Ensure Email and EmailConfirmed match
            if (request.Email != request.EmailConfirmed)
            {
                return new AccountCreationResult
                {
                    Success = false,
                    Errors = new List<string> { "Emails do not match." }
                };
            }

            // Ensure Password and PasswordConfirmed match
            if (request.Password != request.PasswordConfirmed)
            {
                return new AccountCreationResult
                {
                    Success = false,
                    Errors = new List<string> { "Passwords do not match." }
                };
            }

            // Check if email already exists
            var existingAdmin = await _adminRepository.GetAdminByEmailAsync(request.Email);
            if (existingAdmin != null)
            {
                return new AccountCreationResult
                {
                    Success = false,
                    Errors = new List<string> { "Email is already taken." }
                };
            }

            // Create new admin
            var admin = new Admin
            {
                Email = request.Email,
                // Set other properties as needed
            };

            // Save the new admin to the database
            var result = await _adminRepository.CreateAdminAsync(admin, request.Password);

            if (result.Succeeded)
            {
                // Send confirmation email
                var emailResult = await _emailSender.SendEmailAsync(
                    request.Email,
                    "Account Created",
                    "<p>Your admin account has been created successfully!</p>");

                // Generate JWT token
                var token = _authService.GenerateToken(admin);

                return new AccountCreationResult
                {
                    Success = true,
                    Token = token
                };
            }

            // If the IdentityResult fails, return error messages
            return new AccountCreationResult
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }



        public async Task<IdentityResult> UpdateAdminAsync(Admin admin)
        {
            return await _adminRepository.UpdateAdminAsync(admin);
        }

        public async Task<IdentityResult> DeleteAdminAsync(string password, ClaimsPrincipal currentUser)
        {
            return await _adminRepository.DeleteAdminAsync(password, currentUser);
        }

        //public async Task<LoginResult> LoginAsync(string email, string password)
        //{
        //    var admin = await _adminRepository.GetAdminByEmailAsync(email);

        //    if (admin == null)
        //    {
        //        return new LoginResult { Success = false, ErrorMessage = "Invalid email or password." };
        //    }

        //    // Verify the password (assuming your repository handles password verification)
        //    var result = await _adminRepository.LoginAsync(email, password);

        //    if (!result.Success)
        //    {
        //        return new LoginResult { Success = false, ErrorMessage = "Invalid email or password." };
        //    }

        //    // Uses authentication service and the method for token generation
        //    var token = _authService.GenerateToken(admin);

        //    return new LoginResult { Success = true, Token = token };
        //}


        public async Task<IdentityResult> SendEmailVerificationAsync(string userId, string code)
        {
            return await _adminRepository.SendEmailVerificationAsync(userId, code);
        }
    }
}
