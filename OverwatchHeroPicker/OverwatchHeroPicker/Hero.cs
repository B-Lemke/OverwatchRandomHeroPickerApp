using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OverwatchHeroPicker
{
    public class Hero
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string FileName { get; set; }

        public Hero(string name, string role, string fileName)
        {
            Name = name;
            Role = role;
            FileName = fileName;
        }

        public Hero()
        {

        }
    }

    public class Filter
    {
        public string FilterName { get; set; } = "Not Set";

        public List<Hero> HeroList { get; set; }

        public Filter()
        {
            HeroList = new List<Hero>(); //Instantiate list in constructor
        }

        public void Seed()
        {
            //Popular with all of the heros
            Hero Ana = new Hero("Ana", "Support", "ana.png");
            this.HeroList.Add(Ana);

            Hero Ashe = new Hero("Ashe", "Damage", "ashe.png");
            this.HeroList.Add(Ashe);

            Hero Bastion = new Hero("Bastion", "Damage", "bastion.png");
            this.HeroList.Add(Bastion);

            Hero Brigitte = new Hero("Brigitte", "Support", "brigitte.png");
            this.HeroList.Add(Brigitte);

            Hero Dva = new Hero("D.va", "Tank", "dva.png");
            this.HeroList.Add(Dva);

            Hero Doomfist = new Hero("Doomfist", "Damage", "doomfist.png");
            this.HeroList.Add(Doomfist);

            Hero Genji = new Hero("Genji", "Damage", "genji.png");
            this.HeroList.Add(Genji);

            Hero Hanzo = new Hero("Hanzo", "Damage", "hanzo.png");
            this.HeroList.Add(Hanzo);

            Hero Junkrat = new Hero("Junkrat", "Damage", "junkrat.png");
            this.HeroList.Add(Junkrat);

            Hero Lucio = new Hero("Lucio", "Support", "lucio.png");
            this.HeroList.Add(Lucio);

            Hero Mccree = new Hero("McCree", "Damage", "mccree.png");
            this.HeroList.Add(Mccree);

            Hero Mei = new Hero("Mei", "Damage", "mei.png");
            this.HeroList.Add(Mei);

            Hero Mercy = new Hero("Mercy", "Support", "mercy.png");
            this.HeroList.Add(Mercy);

            Hero Moira = new Hero("Moira", "Support", "moira.png");
            this.HeroList.Add(Moira);

            Hero Orisa = new Hero("Orisa", "Tank", "orisa.png");
            this.HeroList.Add(Orisa);

            Hero Pharah = new Hero("Pharah", "Damage", "pharah.png");
            this.HeroList.Add(Pharah);

            Hero Reaper = new Hero("Reaper", "Damage", "reaper.png");
            this.HeroList.Add(Reaper);

            Hero Reinhardt = new Hero("Reinhardt", "Tank", "reinhardt.png");
            this.HeroList.Add(Reinhardt);

            Hero Roadhog = new Hero("Roadhog", "Tank", "roadhog.png");
            this.HeroList.Add(Roadhog);

            Hero Soldier = new Hero("Soldier 76", "Damage", "soldier.png");
            this.HeroList.Add(Soldier);

            Hero Sombra = new Hero("Sombra", "Damage", "sombra.png");
            this.HeroList.Add(Sombra);

            Hero Symmetra = new Hero("Symmetra", "Damage", "symmetra.png");
            this.HeroList.Add(Symmetra);

            Hero Torb = new Hero("Torbjörn", "Damage", "torb.png");
            this.HeroList.Add(Torb);

            Hero Tracer = new Hero("Tracer", "Damage", "tracer.png");
            this.HeroList.Add(Tracer);

            Hero Widowmaker = new Hero("Widowmaker", "Damage", "widowmaker.png");
            this.HeroList.Add(Widowmaker);

            Hero Winston = new Hero("Winston", "Tank", "winston.png");
            this.HeroList.Add(Winston);

            Hero Wreckingball = new Hero("Wrecking Ball", "Tank", "wreckingball.png");
            this.HeroList.Add(Wreckingball);

            Hero Zarya = new Hero("Zarya", "Tank", "zarya.png");
            this.HeroList.Add(Zarya);

            Hero Zenyatta = new Hero("Zenyatta", "Support", "zenyatta.png");
            this.HeroList.Add(Zenyatta);

        }
    }

    public class Filters : List<Filter>
    {

    }

}
