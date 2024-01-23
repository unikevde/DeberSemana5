﻿namespace DeberSemana5
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.bbdd());
            PersonRepo = personRepository;

        }
    }
}
