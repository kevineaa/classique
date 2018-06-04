using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Classique.Models;

namespace Classique.Controllers
{
    public class Item
    {
        private Enregistrement en = new Enregistrement();

        public Enregistrement En
        {
          get { return en; }
          set { en = value; }
        }

        private int quantity;

        public int Quantity
        {
          get { return quantity; }
          set { quantity = value; }
        }

        public Item(){}

        public Item(Enregistrement en, int quantity){
            this.en = en;
            this.quantity = quantity;
        } 
    }
}