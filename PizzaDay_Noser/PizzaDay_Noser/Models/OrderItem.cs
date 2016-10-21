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

        public List<DescriptionItem> Description { get; set; }

        public string DescriptionText { get
            {
                var text = "";
                foreach(var item in Description)
                {
                    if(text != "")
                    {
                        text += ", ";
                    }
                    text += item.Name;
                }
                return text;
            }
        }

        public decimal Price { get; set; }

        public String ImageUrl { get; set; }
    }


    
}

