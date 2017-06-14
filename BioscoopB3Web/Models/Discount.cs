using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Entities
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public decimal StudentDiscount { get; set; }
        public decimal ChildDiscount { get; set; }
        public decimal ElderlyDiscount { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal PopcornArrangementPrice { get; set; }
        public Order Order { get; set; }
        public HallMovie Hallmovie { get; set; }
        public Movie Movie { get; set; }

        public Discount(Order order, HallMovie hallmovie, Movie movie)
        {
            this.Order = order;
            this.Hallmovie = hallmovie;
            this.Movie = movie;
            this.StudentDiscount = 1.50m;
            this.ChildDiscount = 1.50m;
            this.ElderlyDiscount = 1.50m;
            this.PopcornArrangementPrice = 3.00m;

            if (movie.Length < 120)
            {
                this.StandardPrice = 8.50m;
            }
            else
            {
                this.StandardPrice = 9.00m;
            }
            if (movie.ThreeD == true)
            {
                this.StandardPrice += 2.50m;
            }
        }

        public decimal calcStudentDiscount()
        {
            if ((int)Hallmovie.DateTime.DayOfWeek == 1 || (int)Hallmovie.DateTime.DayOfWeek == 2 || (int)Hallmovie.DateTime.DayOfWeek == 3 || (int)Hallmovie.DateTime.DayOfWeek == 4)
            {
                decimal discountedPrice = (Order.StudentTickets * StandardPrice) - (Order.StudentTickets * this.StudentDiscount);
                return discountedPrice;
            }
            else
            {
                decimal price = Order.StudentTickets * StandardPrice;
                return price;
            }
        }

        public decimal calcChildDiscount()
        {
            if ((Movie.Language == "Nederlands") && (Hallmovie.DateTime.TimeOfDay.TotalHours < 16))
            {
                decimal discountedPrice = (Order.ChildTickets * StandardPrice) - (Order.ChildTickets * ChildDiscount);
                return discountedPrice;
            }
            else
            {
                decimal price = Order.ChildTickets * StandardPrice;
                return price;
            }
        }

        public decimal calcElderlyDiscount()
        {
            DateTime ChristmasStart = new DateTime(2017, 12, 25, 0, 0, 0);
            DateTime ChristmasEnd = new DateTime(2017, 12, 25, 23, 59, 59);
            //TO DO: Add holiday check
            if (((int)Hallmovie.DateTime.DayOfWeek == 1 || (int)Hallmovie.DateTime.DayOfWeek == 2 || (int)Hallmovie.DateTime.DayOfWeek == 3 || (int)Hallmovie.DateTime.DayOfWeek == 4) && Hallmovie.DateTime < ChristmasStart || Hallmovie.DateTime > ChristmasEnd)
            {
                decimal discountedPrice = (Order.ElderlyTickets * StandardPrice) - (Order.ElderlyTickets * this.ElderlyDiscount);
                return discountedPrice;
            }
            else
            {
                decimal price = Order.ElderlyTickets * StandardPrice;
                return price;
            }
        }

        public decimal calcNoDiscount()
        {
            decimal price = Order.NormalTickets * StandardPrice;
            return price;
        }

        public decimal calcTotalPrice()
        {
            if (Hallmovie.LadiesNight == false) {
                return calcChildDiscount() + calcElderlyDiscount() + calcNoDiscount() + calcStudentDiscount() + calcPopcornArrangementPrice();
            }
            else
            {
                return calcLadiesNight();
            }
        }

        public decimal calcPopcornArrangementPrice()
        {

            return Order.PopcornArrangement * PopcornArrangementPrice;
        }

        public decimal calcLadiesNight()
        {
            return Order.TotalTickets * 15.45m;
        }
    }
}
