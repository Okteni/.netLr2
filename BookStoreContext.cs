using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public BookStoreContext()
        {
            
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ConsoleApp4;Username=postgres;Password=1234");
        }
    }
    // Модель книги
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

    // Модель покупателя
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

     
    }

    // Модель заказа
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }

  


    }

    // Модель деталей заказа
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Book Book { get; set; }

       

    }


}
