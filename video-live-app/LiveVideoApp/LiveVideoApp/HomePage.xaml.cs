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


        public HomePage()
        {
            ListeUser.Add(new User("Daniel", true));
            ListeUser.Add(new User("Danielle", true));
            ListeUser.Add(new User("Brandon", false));
            ListeUser.Add(new User("Michelle", true));
            ListeUser.Add(new User("Homo", false));
            ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Daniel", true));
			ListeUser.Add(new User("Danielle", true));
			ListeUser.Add(new User("Brandon", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Daniel", true));
			ListeUser.Add(new User("Danielle", true));
			ListeUser.Add(new User("Brandon", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Daniel", true));
			ListeUser.Add(new User("Danielle", true));
			ListeUser.Add(new User("Brandon", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
			ListeUser.Add(new User("Daniel", true));
			ListeUser.Add(new User("Danielle", true));
			ListeUser.Add(new User("Brandon", false));
			ListeUser.Add(new User("Michelle", true));
			ListeUser.Add(new User("Homo", false));
			ListeUser.Add(new User("Goltrand", false));
            InitializeComponent();

            initializeGrid();
            initialize();
            initializeAnfrage();
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

        void initialize()
        {
            for (int i = 0; i < ListeUser.Count; i++)
			{
                User aktUser = ListeUser[i];

                Label la = new Label();

                controlGrid.Children.Add(new Label() { Text = aktUser.Username, FontSize = 40, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.Start, HorizontalTextAlignment = TextAlignment.Center }, 0, i);

                Color color_goto =  aktUser.Status == true  ? Color.Blue : Color.Gray;
                controlGrid.Children.Add(new Label() {  Text = "gotolive", FontSize = 25, TextColor = color_goto, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, HorizontalTextAlignment = TextAlignment.Center }, 1, i);

				controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			}

            //stack_home.Children.Add(controlGrid);
            Scroll_Home.Content = controlGrid;
        }

		void initializeAnfrage()
		{
			for (int i = 0; i < ListeUser.Count; i++)
			{
				User aktUser = ListeUser[i];

				Label la = new Label();

				controlGrid_Anfrage.Children.Add(new Label() { Text = aktUser.Username, FontSize = 40, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.Start, HorizontalTextAlignment = TextAlignment.Center }, 0, i);

				Color color_goto = aktUser.Status == true ? Color.Blue : Color.Gray;
                controlGrid_Anfrage.Children.Add(new Button() { Text = "Add", FontSize = 25, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.StartAndExpand}, 1, i);

				controlGrid_Anfrage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			}

			stack_home_Anfrage.Children.Add(controlGrid_Anfrage);
		}
    }
}
