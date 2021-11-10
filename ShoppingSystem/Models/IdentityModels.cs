using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ShoppingSystem.Models;

namespace ShoppingSystem.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OriginCountry> OriginCountries { get; set; }
        public DbSet<PrdImage> PrdImages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
    public class CartItem
    {
        public string CartItemId { get; set; }

        public string CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Total
        {
            get
            {
                return Quantity * Product.Price;
            }
        }
        public System.DateTime DateCreated { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
    public class Product
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Feature { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CatId { get; set; }
        //public int ColorID { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public string VideoPath { get; set; }
        [ForeignKey("OriginCountry")]
        public int OriginId { get; set; }
        public string Warranty { get; set; }
        public decimal Price { get; set; }
        public string FeaturedPic { get; set; }
        public List<string> ImageList { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }


        public virtual ICollection<PrdImage> PrdImages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public OriginCountry OriginCountry { get; set; }
    }
    public enum PayMethod
    {
        Bkash = 1, Roket, Nogod, CreditCard
    }
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderqTY { get; set; }
        [ForeignKey("Product")]
        public int PrdID { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Customer")]
        public int CusId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(15)]
        public string ConactNo { get; set; }
        [MaxLength]
        public string ShippingAddress { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Delivery
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderqTY { get; set; }
        public int PrdID { get; set; }
        public int DeliveryBy { get; set; }
    }
    public class ReturnPolicy
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

    }
    public class OriginCountry
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OriginCountryName { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class PrdReturnPolicy
    {
        public int Id { get; set; }
        public int PrdId { get; set; }
        public int RetPolicyId { get; set; }

    }
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Model> Model { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
    public class Color
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
    public class PrdImage
    {
        public int Id { get; set; }
        [Required]

        public string ImagePath { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    public class PrdOffer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OfferName { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public int Rate { get; set; }
        public decimal OfferAmout { get; set; }
    }
}

#region Helpers
namespace ShoppingSystem
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
