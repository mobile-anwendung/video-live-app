using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveVideoApp
{
    public partial class HomePage : TabbedPage
    {
        Grid controlGrid;
        Grid controlGrid_Anfrage;
        List<User> ListeUser = new List<User>();
        Dictionary<int, User> ListFriends = new Dictionary<int, User>();
        Dictionary<int, User> ListFriendsToConfirm = new Dictionary<int, User>();


        User aktUser;

        Request request;
        public HomePage(User user)
        {
            request = new Request("", "");

            aktUser = user;

            ListeUser.Add(new User("Daniel", true));
            ListeUser.Add(new User("Danielle", true));
            ListeUser.Add(new User("Brandon", false));
            ListeUser.Add(new User("Michelle", true));
            ListeUser.Add(new User("Homo", false));
            ListeUser.Add(new User("Goltrand", false));

            InitializeComponent();

            initializeGrid();
            initialize();
            test();
            //initializeAnfrage();
        }

        void initializeGrid()
        {
            controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

            controlGrid_Anfrage = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

            controlGrid_Anfrage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid_Anfrage.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300) });
            controlGrid_Anfrage.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
        }

        int index_home = 0;
        void initialize()
        {

            foreach (var IdFriend in aktUser.Friends)
            {
                User Friend = new User();
                Friend.Id = IdFriend;

                //Request get friend info

                if (!ListFriends.ContainsKey(IdFriend))
                {
                    ListFriends.Add(IdFriend, Friend);
                }

                AddOneElementGridHome(Friend);
            }

            //stack_home.Children.Add(controlGrid);
            Scroll_Home.Content = controlGrid;
        }

        void AddOneElementGridHome(User user)
        {
            controlGrid.Children.Add(new Label() { Text = user.Benutzername, FontSize = 40, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.Start, HorizontalTextAlignment = TextAlignment.Center }, 0, index_home);

            Color color_goto = user.Live == true ? Color.Blue : Color.Gray;
            ButtonUser button = new ButtonUser() { IdUser = user.Id, Text = "gotolive", FontSize = 15, TextColor = color_goto, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand };
            button.Clicked += gotolive_clicked;
            //controlGrid.Children.Add(new Label() {  Text = "gotolive", FontSize = 25, TextColor = color_goto, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, HorizontalTextAlignment = TextAlignment.Center }, 1, i);
            controlGrid.Children.Add(button, 1, index_home);
            button = new ButtonUser();

            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            index_home++;
        }

        void gotolive_clicked(object sender, EventArgs e)
        {
            ButtonUser button = sender as ButtonUser;

            //Request go to live 
        }

        int index_Anfrage = 0;
        void initializeAnfrage()
        {
            foreach (var IdFriend in aktUser.ToConfirm)
            {
                User _user = new User();
                _user.Id = IdFriend;

                //Request get user info

                if (!ListFriends.ContainsKey(IdFriend))
                {
                    ListFriends.Add(IdFriend, _user);
                }

                AddOneElementGridAnfrage(_user);
            }

        }

        void AddOneElementGridAnfrage(User user)
        {
            controlGrid_Anfrage.Children.Add(new Label() { Text = user.Benutzername, FontSize = 40, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.Start, HorizontalTextAlignment = TextAlignment.Center }, 0, index_Anfrage);

            Color color_goto = user.Live == true ? Color.Blue : Color.Gray;
            ButtonUser button = new ButtonUser() { IdUser = user.Id, Text = "Add", FontSize = 15, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand };
            button.Clicked += Add_clicked;
            button = new ButtonUser();
            controlGrid_Anfrage.Children.Add(button, 1, index_Anfrage);

            controlGrid_Anfrage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            index_Anfrage++;
        }

        void test()
        {
            List<User> people = new List<User>();

            foreach (var key in ListFriends.Keys)
            {
                people.Add(ListFriends[key]);
            }

            people.Add(new User() { Benutzername = "Daniel" });
            people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });
			people.Add(new User() { Benutzername = "Daniel" });

            var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.FontSize = 25;
                var button_add = new ButtonUser { Text = "Add" };

                nameLabel.SetBinding(Label.TextProperty, "Benutzername");
                grid.Children.Add(nameLabel);
                grid.Children.Add(button_add, 2, 0);

                return new ViewCell { View = grid };
            });

            Scroll_Home_Anfrage.Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                new ListView { ItemsSource = people, ItemTemplate = personDataTemplate, Margin = new Thickness(0, 20, 0, 0) }
            }
            };
        }

        async void Add_clicked(object sender, EventArgs e)
        {
            ButtonUser button = sender as ButtonUser;

            string json = request.CreateJsonObject(RequestTyp.ConfirmDemand, aktUser, button.IdUser);
            await DisplayAlert("Josn", json, "Ok");
            object repo = request.Execute(json);

            Responce responce = (Responce)repo;
            string result = request.GetResponceObject(responce).ToString();

            if (responce.Executed)
            {
                button.IsEnabled = false;
                AddOneElementGridHome(ListFriendsToConfirm[button.IdUser]);
            }
            else
            {
                await DisplayAlert("Error", "Keine Verbindung mit dem Server", "Ok");
            }
        }
    }
}
