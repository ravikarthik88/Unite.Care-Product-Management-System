﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Models
{

    #region Authentication
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AuthResponseViewModel
    {
        public string Token { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    #endregion

    #region User
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
    public class UpdateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ProfileViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
    }
    public class UpdateProfileViewModel
    {
        [DataType(DataType.Text)]
        public string Company { get; set; }
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required, DataType(DataType.Text)]
        public string Location { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public IFormFile file { get; set; }
    }
    public class UpdateProfilePictureViewModel
    {
        public string UserId { get; set; }
        public IFormFile file { get; set; }
    }
    public class ChangePasswordViewModel
    {
        public string UserId { get; set; }
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare("NewPassword"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    #endregion

    #region Role
    public class RoleViewModel
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
    }

    public class CreateRoleViewModel
    {
        public string Name { get; set; }
    }

    public class UpdateRoleViewModel
    {
        public string Name { get; set; }
    }
    #endregion

    #region UserRole

    public class UserInRoleViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
    public class UpdateUserInRoleViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
    public class UserRoleViewModel
    {
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
    public class AssignUserToRoleViewModel
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }

    #endregion

    #region DashBoard

    public class DashBoardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalRoles { get; set; }
        public int TotalActiveUsers { get; set; }
        public int TotalDeletedUsers { get; set; }
        public int TotalAssignedRoles { get; set; }
    }
    #endregion

    #region Permission

    public class PermissionViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdatePermissionViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    #endregion

    #region RolePermission

    public class RolePermissionViewModel
    {
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> Permissions { get; set; }
    }
    public class PermissionInRoleViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Permissions { get; set; }
    }
    public class UpdatePermissionInRoleViewModel
    {
        public string RoleName { get; set; }
        public List<SelectListItem> Permissions { get; set; }
        public string PermissionName { get; set; }
    }
    public class AssignRolePermissionViewModel
    {
        public string RoleName { get; set; }
        public string PermissionName { get; set; }
    }

    #endregion

    #region Product
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductExpiry { get; set; }
        public List<SelectListItem> ProductType { get; set; }
        public int ProductPrice { get; set; }
        public string Company { get; set; }
        public string SelectedProductType { get; set; }
    }

    public class ProductTypeViewModel
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    }

    #endregion
}
