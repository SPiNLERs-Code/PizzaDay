using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaDay_Noser.Models
{
    public class OrderItem
    {
      
        public String Name { get; set; }

        public ImageSource Image { get { return ImageSource.FromUri(new Uri(ImageUrl)); } }

        public String Description { get; set; }

        public String ImageUrl { get; set; }
    }
}
