using PizzaDay_Noser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDay_Noser.DemoDatas
{
    public class DemoData
    {
        private static DemoData _demoDataInstance;

        private DescriptionItem _tomatenSauce;
        private DescriptionItem _mozzarella;
        private DescriptionItem _oregano;
        private DescriptionItem _ananas;
        private DescriptionItem _artischocken;
        private DescriptionItem _auberginen;
        private DescriptionItem _blattspinat;
        private DescriptionItem _broccoli;
        private DescriptionItem _champignons;
        private DescriptionItem _crevetten;
        private DescriptionItem _ei;
        private DescriptionItem _gorgonzola;
        private DescriptionItem _hinterschinken;
        private DescriptionItem _kapern;
        private DescriptionItem _knoblauch;
        private DescriptionItem _mais;
        private DescriptionItem _mascarpone;
        private DescriptionItem _meeresfrüchte;
        private DescriptionItem _mozzarellaExtra;
        private DescriptionItem _oliven;
        private DescriptionItem _granaPadano;
        private DescriptionItem _peperoncini;
        private DescriptionItem _peperoni;
        private DescriptionItem _pouletFleisch;
        private DescriptionItem _rindFleisch;
        private DescriptionItem _rohschinkenSanDaniele;
        private DescriptionItem _rucola;
        private DescriptionItem _salami;
        private DescriptionItem _sardellen;
        private DescriptionItem _scharfeSalami;
        private DescriptionItem _speck;
        private DescriptionItem _steinpilze;
        private DescriptionItem _thon;
        private DescriptionItem _tomatenScheiben;
        private DescriptionItem _zwiebeln;

        private OrderItem _margherita;
        private OrderItem _stromboli;
        private OrderItem _napoli;
        private OrderItem _proscuitto;
        private OrderItem _funghi;
        private OrderItem _proscuittoEFunghi;
        private OrderItem _quattroStagioni;
        private OrderItem _rustica;
        private OrderItem _salame;
        private OrderItem _piccante;
        private OrderItem _gamberetti;
        private OrderItem _tonno;
        private OrderItem _fruttiDiMare;
        private OrderItem _gorgonzolaPizza;
        private OrderItem _quattroFormaggi;
        private OrderItem _kickiricki;


        private Restaurant _dieci;
        private Restaurant _pizzaBlitz;

        public static DemoData DemoDataInstance
        {
            get
            {
                if (_demoDataInstance == null)
                {
                    _demoDataInstance = new DemoData();
                }

                return _demoDataInstance;
            }
        }
            

        private DemoData()
        {
            InitializeDescriptionItems();
            InitializeOrderItems();
            InitializeRestaurants();

            SetDefaultRestaurants();
            SetDefaultUsers();
            SetBulkOrders();

            SetDemoDatas();
        }

        public List<Restaurant> SavedRestaurants;
        public List<BulkOrder> SavedBulkOrders;
        public List<User> SavedUsers;

        public List<DescriptionItem> GetAllDescriptionItems()
        {
            return new List<DescriptionItem>()
            {
                _tomatenSauce,
                _mozzarella,
                _oregano,
                _ananas,
                _artischocken,
                _auberginen,
                _blattspinat,
                _broccoli,
                _champignons,
                _crevetten,
                _ei,
                _gorgonzola,
                _hinterschinken,
                _kapern,
                _knoblauch,
                _mais,
                _mascarpone,
                _meeresfrüchte,
                _mozzarellaExtra,
                _oliven,
                _granaPadano,
                _peperoncini,
                _peperoni,
                _pouletFleisch,
                _rindFleisch,
                _rohschinkenSanDaniele,
                _rucola,
                _salami,
                _sardellen,
                _scharfeSalami,
                _speck,
                _steinpilze,
                _thon,
                _tomatenScheiben,
                _zwiebeln
            };
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return new List<OrderItem>()
            {
                _margherita,
                _stromboli,
                _napoli,
                _proscuitto,
                _funghi,
                _proscuittoEFunghi,
                _quattroStagioni,
                _rustica,
                _salame,
                _piccante,
                _gamberetti,
                _tonno,
                _fruttiDiMare,
                _gorgonzolaPizza,
                _quattroFormaggi,
                _kickiricki
        };
        }


        public List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>() { _dieci, _pizzaBlitz };
        }

        public List<OrderItem> GetAllOrderItemsFromRestaurant(int restaurantId)
        {
            var restaurant = GetAllRestaurants().Where(x => x.Id == restaurantId).FirstOrDefault();

            return restaurant.OrderItems;
        }

        public void SetNewRestaurant(Restaurant restaurant)
        {
            int maxId = SavedRestaurants.Select(x => x.Id).Max();
            restaurant.Id = maxId + 1;
            SavedRestaurants.Add(restaurant);
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            if (restaurant.Id == 0) { return false; }
            var restaurantToEdit = SavedRestaurants.Where(x => x.Id == restaurant.Id).FirstOrDefault();
            if (restaurantToEdit == null) { return false; }

            restaurantToEdit.Name = restaurant.Name;
            restaurantToEdit.OrderItems = restaurant.OrderItems;

            return true;
        }

        public void SetNewBulkOrder(BulkOrder bulkOrder)
        {
            int maxId = SavedRestaurants.Select(x => x.Id).Max();
            bulkOrder.Id = maxId + 1;
            SavedBulkOrders.Add(bulkOrder);
        }

        public bool UpdateBulkOrder(BulkOrder bulkOrder)
        {
            if (bulkOrder.Id == 0) { return false; }
            var bulkOrderToEdit = SavedBulkOrders.Where(x => x.Id == bulkOrder.Id).FirstOrDefault();
            if (bulkOrderToEdit == null) { return false; }

            bulkOrderToEdit.Creator = bulkOrder.Creator;
            bulkOrderToEdit.DeliveryTime = bulkOrder.DeliveryTime;
            bulkOrderToEdit.Description = bulkOrder.Description;
            bulkOrderToEdit.IsOrdering = bulkOrder.IsOrdering;
            bulkOrderToEdit.Items = bulkOrder.Items;
            bulkOrderToEdit.OrderDeadline = bulkOrder.OrderDeadline;
            bulkOrderToEdit.Restaurant = bulkOrder.Restaurant;

            return true;
        }

        public bool AddItemToBulkOrder(int bulkOrderId, Order order )
        {
            if (bulkOrderId == 0) { return false; }
            var bulkOrderToAdd = SavedBulkOrders.Where(x => x.Id == bulkOrderId).FirstOrDefault();
            if (bulkOrderToAdd == null) { return false; }

            bulkOrderToAdd.Items.Add(order);
            return true;
        }

        private void InitializeDescriptionItems()
        {
            _zwiebeln = new DescriptionItem { Id = 1, Name = "Zwiebeln", Price = (decimal)1.00 };
            _tomatenSauce = new DescriptionItem { Id = 2, Name = "Tomatensauce", Price = (decimal)0.00 };
            _mozzarella = new DescriptionItem { Id = 3, Name = "Mozzarella", Price = (decimal)0.00 };
            _oregano = new DescriptionItem { Id = 4, Name = "Oregano", Price = (decimal)0.00 };
            _ananas = new DescriptionItem { Id = 5, Name = "Ananans", Price = (decimal)1.00 };
            _artischocken = new DescriptionItem { Id = 6, Name = "Artischocken", Price = (decimal)2.00 };
            _auberginen = new DescriptionItem { Id = 7, Name = "Auberginen", Price = (decimal)2.00 };
            _blattspinat = new DescriptionItem { Id = 8, Name = "Blattspinat", Price = (decimal)2.00 };
            _broccoli = new DescriptionItem { Id = 9, Name = "Broccoli", Price = (decimal)2.00 };
            _champignons = new DescriptionItem { Id = 10, Name = "Champignons", Price = (decimal)2.00 };
            _crevetten = new DescriptionItem { Id = 11, Name = "Crevetten Black Tiger", Price = (decimal)3.00 };
            _ei = new DescriptionItem { Id = 12, Name = "Ei", Price = (decimal)2.00 };
            _gorgonzola = new DescriptionItem { Id = 13, Name = "Gorgonzola", Price = (decimal)2.00 };
            _hinterschinken = new DescriptionItem { Id = 14, Name = "Hinterschinken", Price = (decimal)3.00 };
            _kapern = new DescriptionItem { Id = 15, Name = "Kapern", Price = (decimal)1.00 };
            _knoblauch = new DescriptionItem { Id = 16, Name = "Knoblauch", Price = (decimal)1.00 };
            _mais = new DescriptionItem { Id = 17, Name = "Mais", Price = (decimal)1.00 };
            _mascarpone = new DescriptionItem { Id = 18, Name = "Mascarpone", Price = (decimal)2.00 };
            _meeresfrüchte = new DescriptionItem { Id = 19, Name = "Meeresfrüchte", Price = (decimal)3.00 };
            _mozzarellaExtra = new DescriptionItem { Id = 20, Name = "Mozzarella extra", Price = (decimal)2.00 };
            _oliven = new DescriptionItem { Id = 21, Name = "Oliven", Price = (decimal)1.00 };
            _granaPadano = new DescriptionItem { Id = 22, Name = "Grana Padano", Price = (decimal)2.00 };
            _peperoncini = new DescriptionItem { Id = 23, Name = "Peperoncini", Price = (decimal)1.00 };
            _peperoni = new DescriptionItem { Id = 24, Name = "Peperoni", Price = (decimal)1.00 };
            _pouletFleisch = new DescriptionItem { Id = 25, Name = "Pouletfleisch", Price = (decimal)3.00 };
            _rindFleisch = new DescriptionItem { Id = 26, Name = "Rindfleisch", Price = (decimal)3.00 };
            _rohschinkenSanDaniele = new DescriptionItem { Id = 27, Name = "Rohschinken San Daniele", Price = (decimal)5.00 };
            _rucola = new DescriptionItem { Id = 28, Name = "Rucola", Price = (decimal)2.00 };
            _salami = new DescriptionItem { Id = 29, Name = "Salami", Price = (decimal)3.00 };
            _sardellen = new DescriptionItem { Id = 30, Name = "Sardellen", Price = (decimal)2.00 };
            _scharfeSalami = new DescriptionItem { Id = 31, Name = "Scharfe Salami", Price = (decimal)3.00 };
            _speck = new DescriptionItem { Id = 32, Name = "Speck", Price = (decimal)3.00 };
            _steinpilze = new DescriptionItem { Id = 33, Name = "Steinpilze", Price = (decimal)3.00 };
            _thon = new DescriptionItem { Id = 34, Name = "Thon", Price = (decimal)3.00 };
            _tomatenScheiben = new DescriptionItem { Id = 35, Name = "Tomatenscheiben", Price = (decimal)2.00 };
        }

        private void InitializeOrderItems()
        {
            _margherita = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/1.jpg", Name = "Margherita", Price = (decimal)16.00, Description = new List<DescriptionItem> {_tomatenSauce, _mozzarella, _oregano } };
            _stromboli = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/2.jpg", Name = "Stromboli", Price = (decimal)17.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _peperoncini, _oliven } };
            _napoli = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/3.jpg", Name = "Napoli", Price = (decimal)18.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _kapern, _sardellen } };
            _proscuitto = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/4.jpg", Name = "Prosciutto", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _hinterschinken } };
            _funghi = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/5.jpg", Name = "Funghi", Price = (decimal)19.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _champignons } };
            _proscuittoEFunghi = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/6.jpg", Name = "Prosciutto e Funghi", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _hinterschinken, _champignons} };
            _quattroStagioni = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/7.jpg", Name = "Quattro stagioni", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _hinterschinken, _artischocken, _champignons, _peperoni } };
            _rustica = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/8.jpg", Name = "Rustica", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _hinterschinken, _speck, _zwiebeln, _knoblauch } };

            _salame = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/9.jpg", Name = "Salame", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano , _salami} };
            _piccante = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/10.jpg", Name = "Piccante", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _scharfeSalami, _peperoncini } };
            _gamberetti = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/11.jpg", Name = "Gamberetti", Price = (decimal)21.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano , _crevetten } };
            _tonno = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/12.jpg", Name = "Tonno", Price = (decimal)19.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _thon, _kapern } };
            _fruttiDiMare = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/13.jpg", Name = "Frutti di mare", Price = (decimal)20.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _meeresfrüchte } };
            _gorgonzolaPizza = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/14.jpg", Name = "Gorgonzola", Price = (decimal)19.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano , _gorgonzola} };
            _quattroFormaggi = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/15.jpg", Name = "Quattro fromaggi", Price = (decimal)21.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano, _granaPadano, _gorgonzola, _mascarpone } };
            _kickiricki = new OrderItem { ImageUrl = "http://www.dieci.ch/kurier/images/16.jpg", Name = "Kickiricki", Price = (decimal)19.00, Description = new List<DescriptionItem> { _tomatenSauce, _mozzarella, _oregano , _pouletFleisch} };
        }

        private void InitializeRestaurants()
        {
            _dieci = new Restaurant() {Id = 1, Name = "Dieci", OrderItems = new List<OrderItem>() { _margherita, _stromboli, _napoli, _proscuitto, _funghi, _proscuittoEFunghi, _quattroStagioni, _rustica, _salame, _piccante, _gamberetti, _tonno, _fruttiDiMare, _gorgonzolaPizza, _quattroFormaggi, _kickiricki } };
            _pizzaBlitz = new Restaurant() { Id = 2, Name = "Pizza Blitz", OrderItems = new List<OrderItem>() { _margherita, _stromboli, _napoli, _proscuitto, _funghi, _tonno, _fruttiDiMare, _gorgonzolaPizza, _quattroFormaggi, _kickiricki } };


        }


        private void SetDefaultUsers()
        {
            SavedUsers = new List<User>();
            User demoUser = new User { Id = 1, Name = "Bryan Albrecht" };
            SavedUsers.Add(demoUser);
        }

        private void SetDefaultRestaurants()
        {
            SavedRestaurants = new List<Restaurant>();

            SavedRestaurants.Add(_dieci);
        }

        private void SetBulkOrders()
        {
            SavedBulkOrders = new List<BulkOrder>();
        }

        private void SetDemoDatas()
        {
            BulkOrder bulkOrder = new BulkOrder()
            {
                Creator = SavedUsers.Where(x => x.Id == 1).FirstOrDefault(),
                DeliveryTime = new DateTime(2016, 12, 10),
                Description = "Demo Bestellung",
                IsOrdering = true,
                OrderDeadline = new DateTime(2016, 12, 9),
                Restaurant = _pizzaBlitz,
                Items = new List<Order>()
            };

            SetNewBulkOrder(bulkOrder);
        }
    }
}